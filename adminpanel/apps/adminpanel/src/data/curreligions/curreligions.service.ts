import { CrudService, buildResourceEndpoints } from '@dkd-query';
import { UriString } from '@dkd-axios';
import type { CurReligionsDto } from './curreligions.models';


const curReligionsEndpoints = {
  ...buildResourceEndpoints<CurReligionsDto>(new UriString('api-admin-curreligionss').toPath()),
};

export class CurReligionsService extends CrudService<CurReligionsDto> {
  constructor() {
    super({
      baseUrl: new UriString('api-admin-curreligionss').toPath(),
      endpoints: curReligionsEndpoints,
    });
  }
}

export const curReligionsService = new CurReligionsService(); 