import type { IconName } from '../../Components/icons/IconMap';

export interface MenuMeta {
  title: string;
  icon: IconName | null;
}


export interface BaseMenuItem {
  id: number;
  parentId: number | null;
  code: string;
  pCode: string;
  component: string;
  name: string;
  ordinal: number;
  hidden: boolean;
  meta: MenuMeta;
}

export interface ThirdLevelMenuItem extends BaseMenuItem {
  path: string;
}

export interface SubMenuItem extends BaseMenuItem {
  path?: string;
  children?: ThirdLevelMenuItem[];
}

export interface MenuItem extends BaseMenuItem {
  path?: string;
  children?: SubMenuItem[];
}
