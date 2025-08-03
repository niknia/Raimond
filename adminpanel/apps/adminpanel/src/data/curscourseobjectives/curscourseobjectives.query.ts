import { useCrudQueries } from '@dkd-query';
import { curScourseobjectivesService } from './curscourseobjectives.service';

export const useCurScourseobjectives = () => useCrudQueries(curScourseobjectivesService); 