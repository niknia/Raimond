import { useCrudQueries } from '@dkd-query';
import { curDegreesService } from './curdegrees.service';

export const useCurDegrees = () => useCrudQueries(curDegreesService); 