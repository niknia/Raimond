import { useCrudQueries } from '@dkd-query';
import { curReligionsService } from './curreligions.service';

export const useCurReligions = () => useCrudQueries(curReligionsService); 