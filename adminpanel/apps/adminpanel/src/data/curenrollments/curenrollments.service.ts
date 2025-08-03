import { CrudService, buildResourceEndpoints } from '@dkd-query';
import { UriString } from '@dkd-axios';
import type { CurEnrollmentsDto } from './curenrollments.models';


const curEnrollmentsEndpoints = {
  ...buildResourceEndpoints<CurEnrollmentsDto>(new UriString('api-admin-curenrollmentss').toPath()),
};

export class CurEnrollmentsService extends CrudService<CurEnrollmentsDto> {
  constructor() {
    super({
      baseUrl: new UriString('api-admin-curenrollmentss').toPath(),
      endpoints: curEnrollmentsEndpoints,
    });
  }
}

export const curEnrollmentsService = new CurEnrollmentsService(); 