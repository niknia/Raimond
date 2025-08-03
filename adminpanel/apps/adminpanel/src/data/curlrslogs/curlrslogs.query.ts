import { useCrudQueries } from '@dkd-query';
import { curLrslogsService } from './curlrslogs.service';

export const useCurLrslogs = () => useCrudQueries(curLrslogsService); 