import { useCrudQueries } from '@dkd-query';
import { curCoursestandardsService } from './curcoursestandards.service';

export const useCurCoursestandards = () => useCrudQueries(curCoursestandardsService); 