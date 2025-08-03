import { useCrudQueries } from '@dkd-query';
import { curTeachersService } from './curteachers.service';

export const useCurTeachers = () => useCrudQueries(curTeachersService);