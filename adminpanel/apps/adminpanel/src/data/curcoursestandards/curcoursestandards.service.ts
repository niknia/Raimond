import { CrudService, buildResourceEndpoints } from '@dkd-query';
import { UriString } from '@dkd-axios';
import type { CurCoursestandardsDto } from './curcoursestandards.models';


const curCoursestandardsEndpoints = {
  ...buildResourceEndpoints<CurCoursestandardsDto>(new UriString('api-admin-curcoursestandardss').toPath()),
};

export class CurCoursestandardsService extends CrudService<CurCoursestandardsDto> {
  constructor() {
    super({
      baseUrl: new UriString('api-admin-curcoursestandardss').toPath(),
      endpoints: curCoursestandardsEndpoints,
    });
  }
}

export const curCoursestandardsService = new CurCoursestandardsService(); 