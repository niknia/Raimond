import { useCrudQueries } from '@dkd-query';
import { curQuestionsService } from './curquestions.service';

export const useCurQuestions = () => useCrudQueries(curQuestionsService); 