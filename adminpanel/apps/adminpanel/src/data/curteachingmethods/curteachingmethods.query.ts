import { useCrudQueries } from '@dkd-query';
import { curTeachingMethodsService } from './curteachingmethods.service';

export const useCurTeachingMethods = () => useCrudQueries(curTeachingMethodsService); 