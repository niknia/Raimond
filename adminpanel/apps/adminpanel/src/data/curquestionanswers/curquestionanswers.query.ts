import { useCrudQueries } from '@dkd-query';
import { curQuestionanswersService } from './curquestionanswers.service';

export const useCurQuestionanswers = () => useCrudQueries(curQuestionanswersService); 