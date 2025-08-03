import { useCrudQueries } from '@dkd-query';
import { curQualificationsService } from './curqualifications.service';

export const useCurQualifications = () => useCrudQueries(curQualificationsService); 