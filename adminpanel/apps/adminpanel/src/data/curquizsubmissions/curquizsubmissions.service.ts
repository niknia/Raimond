import { CrudService, buildResourceEndpoints } from '@dkd-query';
import { UriString } from '@dkd-axios';
import type { CurQuizsubmissionsDto } from './curquizsubmissions.models';


const curQuizsubmissionsEndpoints = {
  ...buildResourceEndpoints<CurQuizsubmissionsDto>(new UriString('api-admin-curquizsubmissionss').toPath()),
};

export class CurQuizsubmissionsService extends CrudService<CurQuizsubmissionsDto> {
  constructor() {
    super({
      baseUrl: new UriString('api-admin-curquizsubmissionss').toPath(),
      endpoints: curQuizsubmissionsEndpoints,
    });
  }
}

export const curQuizsubmissionsService = new CurQuizsubmissionsService(); 