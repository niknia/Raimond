import { useCrudQueries } from '@dkd-query';
import { curOrganizationsService } from './curorganizations.service';

export const useCurOrganizations = () => useCrudQueries(curOrganizationsService); 