import { useCrudQueries } from '@dkd-query';
import { curMaritalstatusesService } from './curmaritalstatuses.service';

export const useCurMaritalstatuses = () => useCrudQueries(curMaritalstatusesService); 