import { useCrudQueries } from '@dkd-query';
import { curQuizzesService } from './curquizzes.service';

export const useCurQuizzes = () => useCrudQueries(curQuizzesService); 