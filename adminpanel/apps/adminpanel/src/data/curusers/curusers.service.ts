import { CrudService, buildResourceEndpoints } from '@dkd-query';
import { UriString } from '@dkd-axios';
import type { CurUsersDto } from './curusers.models';


const curUsersEndpoints = {
  ...buildResourceEndpoints<CurUsersDto>(new UriString('api-admin-curuserss').toPath()),
};

export class CurUsersService extends CrudService<CurUsersDto> {
  constructor() {
    super({
      baseUrl: new UriString('api-admin-curuserss').toPath(),
      endpoints: curUsersEndpoints,
    });
  }
}

export const curUsersService = new CurUsersService(); 