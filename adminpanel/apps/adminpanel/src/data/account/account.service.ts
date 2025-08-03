import { CrudService,buildResourceEndpoints, buildCustomEndpoint } from '@dkd-query';
import { UriString, axiosConfig } from '@dkd-axios';
import type { UserLoginDto, UserRefreshTokenDto, UserTokenInfoDto, UserValidatedInfoDto, UserChangePwdDto, UserProfileDto } from './account.models';
import type { BaseEntity, Result } from '@dkd-query/src/types/base';

interface IAccountEntity extends BaseEntity {
  id: number;
  username: string;
  email: string;
  firstName: string;
  lastName: string;
  roles: string[];
  permissions: string[];
}

export interface IAccountEndpoints {
  loginEndpoint: any;
  changePasswordEndpoint: (id: number) => string;
  getPermissionsEndpoint: (stationId: number) => string;
}

const userEndpoints = {
  ...buildResourceEndpoints<IAccountEntity>('users'),
  loginEndpoint: buildCustomEndpoint('post-auth-api-session'),
  activate: (id: number) => buildCustomEndpoint('post-user-activate', id.toString()),
  UserProfile: () => buildCustomEndpoint('api-auth-session-profile'),

  planningSchedule: (stationId: number) => 
    buildCustomEndpoint(new UriString('post-planingschedule-api-sfrcircularstations'), stationId.toString())
};

export class AccountService extends CrudService<IAccountEntity, IAccountEndpoints> {
  constructor() {
    super({
      baseUrl: '/auth',
      endpoints: {
        ...userEndpoints,
        changePasswordEndpoint: (id: number) => buildCustomEndpoint('session/password', id.toString()),
        getPermissionsEndpoint: (stationId: number) => buildCustomEndpoint(`session/${stationId}/permissions`)
      }
    });
  }

  /**
 * Log in
 * @returns
 */
 async login(param: UserLoginDto) {
  console.log("this is return item",this.config.endpoints.loginEndpoint,param);
  return this.post<Result<UserTokenInfoDto>>(this.config.endpoints.loginEndpoint,param);
}

  async search(query: string): Promise<IAccountEntity[]> {
    return this.get<IAccountEntity[]>(this.config.endpoints.search(query));
  }

  async activateUser(id: number): Promise<void> {
    return this.post<void>(this.config.endpoints.activate(id));
  }

  async createPlanningSchedule(stationId: number): Promise<void> {
    return this.post<void>(this.config.endpoints.planningSchedule(stationId));
  }
  async getUserProfile():Promise<Result<UserProfileDto>> {
    return this.get<Result<UserProfileDto>>(this.config.endpoints.UserProfile());
  }
}

// export class AccountService extends CrudService<AccountEntity> {

//   private readonly loginEndpoint = new UriString('auth/api/session');
//   private readonly changePasswordEndpoint = new UriString('session/password');
//   private readonly getPermissionsEndpoint = (id: number) => new UriString(`session/${id}/permissions`);

//   constructor() {
//     const { baseUrl } = axiosConfig.getConfig();
//     super({
//       baseUrl,
//       endpoints: {
//         // Required endpoints that won't be used
//         getAll: new UriString(''),
//         getById: (id: unknown) => new UriString(`gtblines/${id}`),
//         create: new UriString(''),
//         update: (id: unknown) => new UriString(`gtblines/${id}`),
//         delete: new UriString(''),
//         getPaginated: (params: unknown) => new UriString(`gtblines/${params}`)
//       }
//     });

//     console.log('AccountService initialized with baseUrl:', this.baseUrl);
//   }
//   async login(data: UserLoginDto): Promise<Result<UserTokenInfoDto>> {
//     debug('Attempting login', { username: data.Account });
//     try {
//       const { baseUrl } = axiosConfig.getConfig();
//       const response = await fetch(`${baseUrl}/${this.loginEndpoint.toString()}`, {
//         method: 'POST',
//         headers: {
//           'Content-Type': 'application/json',
//         },
//         body: JSON.stringify(data),
//       });

//       if (!response.ok) {
//         throw new Error(`HTTP error! status: ${response.status}`);
//       }

//       const result = await response.json();
//       return result;
//     } catch (error) {
//       fatal('Login failed', { error });
//       throw error;
//     }
//   }

//   // async login(data: UserLoginDto): Promise<Result<UserTokenInfoDto>> {
//   //   const loginUrl = `${this.baseUrl}/auth/api/${this.loginEndpoint.toString()}`;
//   //   console.log('Attempting login to:', loginUrl);
//   //   console.log('Login request data:', { Account: data.Account, hasPassword: !!data.password });
    
//   //   try {
//   //     const result = await this.post<Result<UserTokenInfoDto>>(this.loginEndpoint, data);
      
//   //     console.log('Login response:', {
//   //       statusCode: result?.statusCode,
//   //       hasResult: !!result?.result,
//   //       resultType: result?.result ? typeof result.result : 'undefined'
//   //     });

//   //     if (!result) {
//   //       throw new Error('No response received from login endpoint');
//   //     }

//   //     if (result.statusCode !== 201) {
//   //       throw new Error(`Login failed with status code: ${result.statusCode}`);
//   //     }

//   //     if (!result.result) {
//   //       throw new Error('No result data received from login endpoint');
//   //     }

//   //     const resultType = typeof result.result;
//   //     const hasToken = result.result && typeof result.result === 'object' && 'token' in result.result;
      
//   //     if (!hasToken) {
//   //       throw new Error('Invalid response format: missing token');
//   //     }
      
//   //     console.log('Login successful');
//   //     return result;
//   //   } catch (error: unknown) {
//   //     const errorMessage = error instanceof Error ? error.message : 'Unknown error';
//   //     const errorName = error instanceof Error ? error.name : 'Unknown error type';
//   //     const errorStack = error instanceof Error ? error.stack : undefined;
      
//   //     console.error('Login failed', { 
//   //       username: data.Account, 
//   //       errorMessage, 
//   //       errorName,
//   //       errorStack 
//   //     });
//   //     throw error;
//   //   }
//   // }

//   // async logout(): Promise<void> {
//   //   return this.deleteRequest(this.endpoints.logout);
//   // }

//   // async refresh(data: UserRefreshTokenDto): Promise<UserTokenInfoDto> {
//   //   return this.put<UserTokenInfoDto>(this.endpoints.refresh, data);
//   // }

//   // async getInfo(): Promise<UserValidatedInfoDto> {
//   //   return this.get<UserValidatedInfoDto>(this.endpoints.getInfo);
//   // }

//   async changePassword(data: UserChangePwdDto): Promise<void> {
//     debug('Attempting password change');
//     try {
//       await this.put<void>(this.changePasswordEndpoint, data);
//       info('Password changed successfully');
//     } catch (error) {
//       debug('Password change failed', { error });
//       throw error;
//     }
//   }

//   async getPermissions(userId: number, requestPermissions?: string[], userBelongsRoleIds?: string): Promise<string[]> {
//     debug('Fetching user permissions', { userId, requestPermissions, userBelongsRoleIds });
//     try {
//       const result = await this.get<string[]>(this.getPermissionsEndpoint(userId), { requestPermissions, userBelongsRoleIds });
//       info('User permissions fetched successfully', { userId, permissions: result });
//       return result;
//     } catch (error) {
//       fatal('Failed to fetch user permissions', { userId, error });
//       throw error;
//     }
//   }
// } 