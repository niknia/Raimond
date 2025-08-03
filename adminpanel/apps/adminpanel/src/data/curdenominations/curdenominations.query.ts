import { useCrudQueries } from '@dkd-query';
import { curDenominationsService } from './curdenominations.service';

export const useCurDenominations = () => useCrudQueries(curDenominationsService); 