import { useCrudQueries } from '@dkd-query';
import { curEnrollmentsService } from './curenrollments.service';

export const useCurEnrollments = () => useCrudQueries(curEnrollmentsService); 