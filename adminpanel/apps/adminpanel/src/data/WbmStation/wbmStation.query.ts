import { useCrudQueries } from '@dkd-query';
import { wbmStationService } from './wbmStation.service';

export const useWbmStation = () => useCrudQueries(wbmStationService);