import { CrudService, buildResourceEndpoints } from '@dkd-query';
import { UriString } from '@dkd-axios';
import type { CurQuizzesDto } from './curquizzes.models';


const curQuizzesEndpoints = {
  ...buildResourceEndpoints<CurQuizzesDto>(new UriString('api-admin-curquizzess').toPath()),
};

export class CurQuizzesService extends CrudService<CurQuizzesDto> {
  constructor() {
    super({
      baseUrl: new UriString('api-admin-curquizzess').toPath(),
      endpoints: curQuizzesEndpoints,
    });
  }
}

export const curQuizzesService = new CurQuizzesService(); 