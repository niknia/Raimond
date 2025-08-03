import { CrudService, buildResourceEndpoints } from '@dkd-query';
import { UriString } from '@dkd-axios';
import type { CurQualificationsDto } from './curqualifications.models';


const curQualificationsEndpoints = {
  ...buildResourceEndpoints<CurQualificationsDto>(new UriString('api-admin-curqualificationss').toPath()),
};

export class CurQualificationsService extends CrudService<CurQualificationsDto> {
  constructor() {
    super({
      baseUrl: new UriString('api-admin-curqualificationss').toPath(),
      endpoints: curQualificationsEndpoints,
    });
  }
}

export const curQualificationsService = new CurQualificationsService(); 