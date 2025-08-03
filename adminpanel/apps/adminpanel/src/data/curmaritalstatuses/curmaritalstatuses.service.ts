import { CrudService, buildResourceEndpoints } from '@dkd-query';
import { UriString } from '@dkd-axios';
import type { CurMaritalstatusesDto } from './curmaritalstatuses.models';


const curMaritalstatusesEndpoints = {
  ...buildResourceEndpoints<CurMaritalstatusesDto>(new UriString('api-admin-curmaritalstatusess').toPath()),
};

export class CurMaritalstatusesService extends CrudService<CurMaritalstatusesDto> {
  constructor() {
    super({
      baseUrl: new UriString('api-admin-curmaritalstatusess').toPath(),
      endpoints: curMaritalstatusesEndpoints,
    });
  }
}

export const curMaritalstatusesService = new CurMaritalstatusesService(); 