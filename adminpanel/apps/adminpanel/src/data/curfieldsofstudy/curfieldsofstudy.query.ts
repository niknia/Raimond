import { useCrudQueries } from '@dkd-query';
import { curFieldsofstudyService } from './curfieldsofstudy.service';

export const useCurFieldsofstudy = () => useCrudQueries(curFieldsofstudyService); 