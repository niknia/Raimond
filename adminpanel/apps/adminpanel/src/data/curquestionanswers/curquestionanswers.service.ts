import { CrudService, buildResourceEndpoints } from '@dkd-query';
import { UriString } from '@dkd-axios';
import type { CurQuestionanswersDto } from './curquestionanswers.models';


const curQuestionanswersEndpoints = {
  ...buildResourceEndpoints<CurQuestionanswersDto>(new UriString('api-admin-curquestionanswerss').toPath()),
};

export class CurQuestionanswersService extends CrudService<CurQuestionanswersDto> {
  constructor() {
    super({
      baseUrl: new UriString('api-admin-curquestionanswerss').toPath(),
      endpoints: curQuestionanswersEndpoints,
    });
  }
}

export const curQuestionanswersService = new CurQuestionanswersService(); 