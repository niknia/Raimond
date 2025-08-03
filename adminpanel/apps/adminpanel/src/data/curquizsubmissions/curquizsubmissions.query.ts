import { useCrudQueries } from '@dkd-query';
import { curQuizsubmissionsService } from './curquizsubmissions.service';

export const useCurQuizsubmissions = () => useCrudQueries(curQuizsubmissionsService); 