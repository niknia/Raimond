import { CrudService, buildResourceEndpoints } from '@dkd-query';
import { UriString } from '@dkd-axios';
import type { CurDenominationsDto } from './curdenominations.models';


const curDenominationsEndpoints = {
  ...buildResourceEndpoints<CurDenominationsDto>(new UriString('api-admin-curdenominationss').toPath()),
};

export class CurDenominationsService extends CrudService<CurDenominationsDto> {
  constructor() {
    super({
      baseUrl: new UriString('api-admin-curdenominationss').toPath(),
      endpoints: curDenominationsEndpoints,
    });
  }
}

export const curDenominationsService = new CurDenominationsService(); 