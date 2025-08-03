import { useCrudQueries } from '@dkd-query';
import { curRelatedjobsService } from './currelatedjobs.service';

export const useCurRelatedjobs = () => useCrudQueries(curRelatedjobsService); 