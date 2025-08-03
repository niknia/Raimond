import { useCrudQueries } from '@dkd-query';
import { curCoursetypesService } from './curcoursetypes.service';

export const useCurCoursetypes = () => useCrudQueries(curCoursetypesService); 