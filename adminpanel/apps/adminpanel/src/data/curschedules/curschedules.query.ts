import { useCrudQueries } from '@dkd-query';
import { curSchedulesService } from './curschedules.service';

export const useCurSchedules = () => useCrudQueries(curSchedulesService); 