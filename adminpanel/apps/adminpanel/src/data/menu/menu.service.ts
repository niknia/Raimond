import { CrudService } from '@dkd-query';
import { createUriString, UriString, axiosConfig } from '@dkd-axios';
import type { MenuItem, MenuResult } from './menu.models';
import type { BaseEntity } from '@dkd-query';

interface MenuEntity extends BaseEntity {
  id: number;
  name: string;
  path: string;
  icon?: string;
  parentId?: number;
  order: number;
  children?: MenuEntity[];
}

// export class MenuService extends CrudService<MenuEntity> {
//   private readonly routersEndpoint = createUriString('get-usr-api-menus-routers');

//   constructor() {
//     const { baseUrl } = axiosConfig.getConfig();
//     super({
//       baseUrl,
//       endpoints: {
//         getAll: new UriString('usr/api/menus'),
//         getById: (id: unknown) => new UriString(`usr/api/menus/${id}`),
//         create: new UriString('usr/api/menus'),
//         update: (id: unknown) => new UriString(`usr/api/menus/${id}`),
//         delete: (id: unknown) => new UriString(`usr/api/menus/${id}`),
//         getPaginated: (params: unknown) => new UriString(`usr/api/menus/${params}`)
//       }
//     });
//   }

//   async getRouters(): Promise<MenuResult> {
//     try {
//       const result = await this.get(this.routersEndpoint);
//       debug("data result", result as MenuResult);
//       return result as MenuResult;
//     } catch (error) {
//       console.error('Failed to fetch routers:', error);
//       throw error;
//     }
//   }

//   async getAllMenus(): Promise<MenuResult> {
//     try {
//       const result = await this.getAll();
//       return result as unknown as MenuResult;
//     } catch (error) {
//       console.error('Failed to fetch menus:', error);
//       throw error;
//     }
//   }

//   async getMenuById(id: number): Promise<MenuResult> {
//     try {
//       const result = await this.getById(id);
//       return result as unknown as MenuResult;
//     } catch (error) {
//       console.error(`Failed to fetch menu with id ${id}:`, error);
//       throw error;
//     }
//   }

//   async createMenu(menu: Omit<MenuItem, 'id'>): Promise<MenuResult> {
//     try {
//       const result = await this.create(menu);
//       return result as unknown as MenuResult;
//     } catch (error) {
//       console.error('Failed to create menu:', error);
//       throw error;
//     }
//   }

//   async updateMenu(id: number, menu: Partial<MenuItem>): Promise<MenuResult> {
//     try {
//       const result = await this.update(id, menu);
//       return result as unknown as MenuResult;
//     } catch (error) {
//       console.error(`Failed to update menu with id ${id}:`, error);
//       throw error;
//     }
//   }

//   async deleteMenu(id: number): Promise<MenuResult> {
//     try {
//       const result = await this.delete(id);
//       return result as unknown as MenuResult;
//     } catch (error) {
//       console.error(`Failed to delete menu with id ${id}:`, error);
//       throw error;
//     }
//   }
// }
