import { useCrudQueries } from '@dkd-query';
import { curTeacherTypesService } from './curteachertypes.service';

export const useCurTeacherTypes = () => useCrudQueries(curTeacherTypesService);