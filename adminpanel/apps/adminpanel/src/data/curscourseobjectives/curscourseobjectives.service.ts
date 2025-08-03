import { CrudService, buildResourceEndpoints } from '@dkd-query';
import { UriString } from '@dkd-axios';
import type { CurScourseobjectivesDto } from './curscourseobjectives.models';


const curScourseobjectivesEndpoints = {
  ...buildResourceEndpoints<CurScourseobjectivesDto>(new UriString('api-admin-curscourseobjectivess').toPath()),
};

export class CurScourseobjectivesService extends CrudService<CurScourseobjectivesDto> {
  constructor() {
    super({
      baseUrl: new UriString('api-admin-curscourseobjectivess').toPath(),
      endpoints: curScourseobjectivesEndpoints,
    });
  }
}

export const curScourseobjectivesService = new CurScourseobjectivesService(); 