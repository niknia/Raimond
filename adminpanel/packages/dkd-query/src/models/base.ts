export interface UserLoginDto {
  account: string;
  password: string;
}

export interface UserTokenInfoDto {
  token: string | null;
  expire: string;
  refreshToken: string | null;
  refreshExpire: string;
}

export interface UserValidatedInfoDto {
  id: number;
  account: string | null;
  name: string | null;
  roleIds: string | null;
  status: number;
  validationVersion: string | null;
}

export interface UserChangePwdDto {
  oldPassword?: string;
  password: string;
  rePassword: string;
}

export interface UserRefreshTokenDto {
  refreshToken?: string;
}

export interface ProblemDetails {
  type?: string;
  title?: string;
  status?: number;
  detail?: string;
  instance?: string;
}

export interface PageModelDto<T> {
  data: T[] | null;
  rowsCount: number;
  pageIndex: number;
  pageSize: number;
  totalCount: number;
  pageCount: number;
  xData?: any;
} 