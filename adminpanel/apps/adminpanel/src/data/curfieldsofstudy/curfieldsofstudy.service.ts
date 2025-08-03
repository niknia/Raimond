import { CrudService, buildResourceEndpoints } from '@dkd-query';
import { UriString } from '@dkd-axios';
import type { CurFieldsofstudyDto } from './curfieldsofstudy.models';


const curFieldsofstudyEndpoints = {
  ...buildResourceEndpoints<CurFieldsofstudyDto>(new UriString('api-admin-curfieldsofstudys').toPath()),
};

export class CurFieldsofstudyService extends CrudService<CurFieldsofstudyDto> {
  constructor() {
    super({
      baseUrl: new UriString('api-admin-curfieldsofstudys').toPath(),
      endpoints: curFieldsofstudyEndpoints,
    });
  }
}

export const curFieldsofstudyService = new CurFieldsofstudyService(); 