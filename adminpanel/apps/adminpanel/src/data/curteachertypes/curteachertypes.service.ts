import { CrudService, buildResourceEndpoints } from '@dkd-query';
import { UriString } from '@dkd-axios';
import type { CurTeacherTypesDto } from './curteachertypes.models';


const curTeacherTypesEndpoints = {
  ...buildResourceEndpoints<CurTeacherTypesDto>(new UriString('api-admin-curteachertypess').toPath()),
};

export class CurTeacherTypesService extends CrudService<CurTeacherTypesDto> {
  constructor() {
    super({
      baseUrl: new UriString('api-admin-curteachertypess').toPath(),
      endpoints: curTeacherTypesEndpoints,
    });
  }
}

export const curTeacherTypesService = new CurTeacherTypesService();