import { CrudService, buildResourceEndpoints } from '@dkd-query';
import { UriString } from '@dkd-axios';
import type { CurOrganizationsDto } from './curorganizations.models';


const curOrganizationsEndpoints = {
  ...buildResourceEndpoints<CurOrganizationsDto>(new UriString('api-admin-curorganizationss').toPath()),
};

export class CurOrganizationsService extends CrudService<CurOrganizationsDto> {
  constructor() {
    super({
      baseUrl: new UriString('api-admin-curorganizationss').toPath(),
      endpoints: curOrganizationsEndpoints,
    });
  }
}

export const curOrganizationsService = new CurOrganizationsService(); 