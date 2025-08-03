import { CrudService, buildResourceEndpoints } from '@dkd-query';
import { UriString } from '@dkd-axios';
import type { SfrOwnerDto } from './sfrowners.models';


const sfrOwnerEndpoints = {
  ...buildResourceEndpoints<SfrOwnerDto>(new UriString('BaseInfo-api-sfrowners').toPath()),
};

export class SfrOwnerService extends CrudService<SfrOwnerDto> {
  constructor() {
    super({
      baseUrl: new UriString('BaseInfo-api-sfrowners').toPath(),
      endpoints: sfrOwnerEndpoints,
    });
  }
}

export const sfrOwnerService = new SfrOwnerService();