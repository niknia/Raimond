import { CrudService, buildResourceEndpoints } from '@dkd-query';
import { UriString } from '@dkd-axios';
import type { CurLrslogsDto } from './curlrslogs.models';


const curLrslogsEndpoints = {
  ...buildResourceEndpoints<CurLrslogsDto>(new UriString('api-admin-curlrslogss').toPath()),
};

export class CurLrslogsService extends CrudService<CurLrslogsDto> {
  constructor() {
    super({
      baseUrl: new UriString('api-admin-curlrslogss').toPath(),
      endpoints: curLrslogsEndpoints,
    });
  }
}

export const curLrslogsService = new CurLrslogsService(); 