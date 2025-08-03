import { CrudService, buildResourceEndpoints } from '@dkd-query';
import { UriString } from '@dkd-axios';
import type { CurQuestionsDto } from './curquestions.models';


const curQuestionsEndpoints = {
  ...buildResourceEndpoints<CurQuestionsDto>(new UriString('api-admin-curquestionss').toPath()),
};

export class CurQuestionsService extends CrudService<CurQuestionsDto> {
  constructor() {
    super({
      baseUrl: new UriString('api-admin-curquestionss').toPath(),
      endpoints: curQuestionsEndpoints,
    });
  }
}

export const curQuestionsService = new CurQuestionsService(); 