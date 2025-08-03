import { CrudService, buildResourceEndpoints } from '@dkd-query';
import { UriString } from '@dkd-axios';
import type { CurRelatedjobsDto } from './currelatedjobs.models';


const curRelatedjobsEndpoints = {
  ...buildResourceEndpoints<CurRelatedjobsDto>(new UriString('api-admin-currelatedjobss').toPath()),
};

export class CurRelatedjobsService extends CrudService<CurRelatedjobsDto> {
  constructor() {
    super({
      baseUrl: new UriString('api-admin-currelatedjobss').toPath(),
      endpoints: curRelatedjobsEndpoints,
    });
  }
}

export const curRelatedjobsService = new CurRelatedjobsService(); 