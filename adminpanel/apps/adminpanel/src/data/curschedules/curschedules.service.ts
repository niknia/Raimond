import { CrudService, buildResourceEndpoints } from '@dkd-query';
import { UriString } from '@dkd-axios';
import type { CurSchedulesDto } from './curschedules.models';


const curSchedulesEndpoints = {
  ...buildResourceEndpoints<CurSchedulesDto>(new UriString('api-admin-curscheduless').toPath()),
};

export class CurSchedulesService extends CrudService<CurSchedulesDto> {
  constructor() {
    super({
      baseUrl: new UriString('api-admin-curscheduless').toPath(),
      endpoints: curSchedulesEndpoints,
    });
  }
}

export const curSchedulesService = new CurSchedulesService(); 