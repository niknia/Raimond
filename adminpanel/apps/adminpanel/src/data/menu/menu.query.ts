import { useQuery, useMutation, useQueryClient } from '@tanstack/react-query';
//import { MenuService } from './menu.service';
import type { MenuItem, MenuQueryParams, MenuResult } from './menu.models';

//const menuService = new MenuService();
const MENU_QUERY_KEY = 'menus';


// export const useRouters = () => {
//   return useQuery<MenuResult>({
//     queryKey: ['routers'],
//     queryFn: () => menuService.getRouters()
//   });
// };

// export const useMenus = () => {
//   return useQuery<MenuResult>({
//     queryKey: [MENU_QUERY_KEY],
//     queryFn: () => menuService.getAllMenus()
//   });
// };

// export const useMenu = (id: number) => {
//   return useQuery<MenuResult>({
//     queryKey: [MENU_QUERY_KEY, id],
//     queryFn: () => menuService.getMenuById(id),
//     enabled: !!id
//   });
// };

// export const useCreateMenu = () => {
//   const queryClient = useQueryClient();

//   return useMutation<MenuResult, Error, Omit<MenuItem, 'id'>>({
//     mutationFn: (menu) => menuService.createMenu(menu),
//     onSuccess: () => {
//       queryClient.invalidateQueries({ queryKey: [MENU_QUERY_KEY] });
//     }
//   });
// };

// export const useUpdateMenu = () => {
//   const queryClient = useQueryClient();

//   return useMutation<MenuResult, Error, { id: number; menu: Partial<MenuItem> }>({
//     mutationFn: ({ id, menu }) => menuService.updateMenu(id, menu),
//     onSuccess: () => {
//       queryClient.invalidateQueries({ queryKey: [MENU_QUERY_KEY] });
//     }
//   });
// };

// export const useDeleteMenu = () => {
//   const queryClient = useQueryClient();

//   return useMutation<MenuResult, Error, number>({
//     mutationFn: (id) => menuService.deleteMenu(id),
//     onSuccess: () => {
//       queryClient.invalidateQueries({ queryKey: [MENU_QUERY_KEY] });
//     }
//   });
// };
