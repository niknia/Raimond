import { useCrudQueries } from '@dkd-query';
import { curSpecializationsService } from './curspecializations.service';

export const useCurSpecializations = () => useCrudQueries(curSpecializationsService); 