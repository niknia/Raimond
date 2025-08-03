import { CrudService, buildResourceEndpoints } from '@dkd-query';
import { UriString } from '@dkd-axios';
import type { CurDegreesDto } from './curdegrees.models';


const curDegreesEndpoints = {
  ...buildResourceEndpoints<CurDegreesDto>(new UriString('api-admin-curdegreess').toPath()),
};

export class CurDegreesService extends CrudService<CurDegreesDto> {
  constructor() {
    super({
      baseUrl: new UriString('api-admin-curdegreess').toPath(),
      endpoints: curDegreesEndpoints,
    });
  }
}

export const curDegreesService = new CurDegreesService(); 