import { useCrudQueries } from '@dkd-query';
import { curUsersService } from './curusers.service';

export const useCurUsers = () => useCrudQueries(curUsersService); 