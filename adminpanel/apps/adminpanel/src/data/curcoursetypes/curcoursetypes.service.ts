import { CrudService, buildResourceEndpoints } from '@dkd-query';
import { UriString } from '@dkd-axios';
import type { CurCoursetypesDto } from './curcoursetypes.models';


const curCoursetypesEndpoints = {
  ...buildResourceEndpoints<CurCoursetypesDto>(new UriString('api-admin-curcoursetypess').toPath()),
};

export class CurCoursetypesService extends CrudService<CurCoursetypesDto> {
  constructor() {
    super({
      baseUrl: new UriString('api-admin-curcoursetypess').toPath(),
      endpoints: curCoursetypesEndpoints,
    });
  }
}

export const curCoursetypesService = new CurCoursetypesService(); 