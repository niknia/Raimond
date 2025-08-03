import _ from 'lodash';
export interface UserLoginDto {
  Account: string;
  password: string;
}

export interface UserTokenInfoDto {
  token: string;
  expire: string;
  refreshToken: string;
  refreshExpire: string;
}

export interface UserValidatedInfoDto {
  id: number;
  username: string;
  email: string;
  firstName: string;
  lastName: string;
  roles: string[];
  permissions: string[];
}

export interface UserRefreshTokenDto {
  refreshToken: string;
}

export interface UserChangePwdDto {
  currentPassword: string;
  newPassword: string;
} 

export function getFirstOrdefult<T>(input: T | T[]): NonNullable<T> {
  if (Array.isArray(input)) {
    return _.head(input) ?? ({} as NonNullable<T>);
  }
  return input as NonNullable<T>;
}

/**
 * User Profile Information
 * @export
 * @interface UserProfileDto
 */
export interface UserProfileDto {
  /**
   * 
   * @type {number}
   * @memberof UserProfileDto
   */
  'id'?: number;
  /**
   * User Account
   * @type {string}
   * @memberof UserProfileDto
   */
  'account'?: string | null;
  /**
   * Department Name
   * @type {string}
   * @memberof UserProfileDto
   */
  'deptName'?: string | null;
  /**
   * Gender
   * @type {number}
   * @memberof UserProfileDto
   */
  'gender'?: number;
  /**
   * Email Address
   * @type {string}
   * @memberof UserProfileDto
   */
  'email'?: string | null;
  /**
   * Name
   * @type {string}
   * @memberof UserProfileDto
   */
  'name'?: string | null;
  /**
   * Mobile Number
   * @type {string}
   * @memberof UserProfileDto
   */
  'mobile'?: string | null;
  /**
   * Creation Time/Registration Time
   * @type {string}
   * @memberof UserProfileDto
   */
  'createTime'?: string;
  /**
   * Multiple Role Names
   * @type {string}
   * @memberof UserProfileDto
   */
  'roleNames'?: string | null;
  /**
   * 
   * @type {string}
   * @memberof UserProfileDto
   */
  'avatar'?: string | null;
}
