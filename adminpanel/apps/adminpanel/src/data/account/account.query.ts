'use client';

import { useQuery, useMutation } from '@tanstack/react-query';
import { AccountService } from './account.service';
import type { UserLoginDto, UserTokenInfoDto, UserChangePwdDto, UserProfileDto } from './account.models';
import type { Result } from '@dkd-query'

const accountService = new AccountService();

export function useAccountQueries() {
  const loginMutation = useMutation({
    mutationFn: (data: UserLoginDto) => accountService.login(data),
  });

  const useProfile = () => {
    return useQuery<Result<UserProfileDto>>({
      queryKey: ['USER_PROFILE_QUERY_KEY'],
      queryFn: () => accountService.getUserProfile(),
    })
  }
  

  // const changePasswordMutation = useMutation({
  //   mutationFn: (data: UserChangePwdDto) => accountService.changePassword(data),
  // });

  return {
    loginMutation,
    useProfile
    // changePasswordMutation,
  };
} 