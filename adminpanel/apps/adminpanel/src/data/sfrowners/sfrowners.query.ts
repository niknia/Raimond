import { useCrudQueries } from '@dkd-query';
import { sfrOwnerService } from './sfrowners.service';

export const useSfrOwner = () => useCrudQueries(sfrOwnerService);