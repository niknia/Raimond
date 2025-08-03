import { CrudService, buildResourceEndpoints } from '@dkd-query';
import { UriString } from '@dkd-axios';
import type { CurTeachersDto } from './curteachers.models';


const curTeachersEndpoints = {
  ...buildResourceEndpoints<CurTeachersDto>(new UriString('api-admin-curteachers').toPath()),
};

export class CurTeachersService extends CrudService<CurTeachersDto> {
  constructor() {
    super({
      baseUrl: new UriString('api-admin-curteachers').toPath(),
      endpoints: curTeachersEndpoints,
    });
  }
}

export const curTeachersService = new CurTeachersService();