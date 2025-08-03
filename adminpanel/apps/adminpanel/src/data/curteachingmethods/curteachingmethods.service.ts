import { CrudService, buildResourceEndpoints } from '@dkd-query';
import { UriString } from '@dkd-axios';
import type { CurTeachingMethodsDto } from './curteachingmethods.models';


const curTeachingMethodsEndpoints = {
  ...buildResourceEndpoints<CurTeachingMethodsDto>(new UriString('api-admin-curteachingmethodss').toPath()),
};

export class CurTeachingMethodsService extends CrudService<CurTeachingMethodsDto> {
  constructor() {
    super({
      baseUrl: new UriString('api-admin-curteachingmethodss').toPath(),
      endpoints: curTeachingMethodsEndpoints,
    });
  }
}

export const curTeachingMethodsService = new CurTeachingMethodsService(); 