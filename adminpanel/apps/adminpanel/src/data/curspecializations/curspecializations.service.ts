import { CrudService, buildResourceEndpoints } from '@dkd-query';
import { UriString } from '@dkd-axios';
import type { CurSpecializationsDto } from './curspecializations.models';


const curSpecializationsEndpoints = {
  ...buildResourceEndpoints<CurSpecializationsDto>(new UriString('api-admin-curspecializationss').toPath()),
};

export class CurSpecializationsService extends CrudService<CurSpecializationsDto> {
  constructor() {
    super({
      baseUrl: new UriString('api-admin-curspecializationss').toPath(),
      endpoints: curSpecializationsEndpoints,
    });
  }
}

export const curSpecializationsService = new CurSpecializationsService(); 