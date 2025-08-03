import { CrudService, buildResourceEndpoints } from '@dkd-query';
import { UriString } from '@dkd-axios';
import type { WbmStationDto } from './wbmStation.models';


const wbmStationEndpoints = {
  ...buildResourceEndpoints<WbmStationDto>(new UriString('api-admin-wbmstations').toPath()),
};

export class WbmStationService extends CrudService<WbmStationDto> {
  constructor() {
    super({
      baseUrl: new UriString('api-admin-wbmstations').toPath(),
      endpoints: wbmStationEndpoints,
    });
  }
}

export const wbmStationService = new WbmStationService();