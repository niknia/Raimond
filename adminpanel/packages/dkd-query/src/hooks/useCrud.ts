// src/hooks/useCrud.ts
import { useMutation, useQuery, useQueryClient } from '@tanstack/react-query';
import { CrudService } from '../services/crud';
import { BaseEntity } from '../types/base';

export function useCrudQueries<T extends BaseEntity>(service: CrudService<T>) {
  const queryClient = useQueryClient();

  const useGetAll = () => useQuery({
    queryKey: [service.baseUrl, 'all'],
    queryFn: () => service.getAll(),
    //select: (result) => result.data,
  });

  const useGetById = (id: number) => useQuery({
    queryKey: [service.baseUrl, 'byId', id],
    queryFn: () => service.getById(id),
    enabled: !!id,
  });

  const useGetPaginated = (params: { page: number; limit: number }) => useQuery({
    queryKey: [service.baseUrl, 'page', params],
    queryFn: () => service.getPaginated(params),
  });

  const useCreate = () => useMutation({
    mutationFn: (data: Partial<T>) => service.create(data),
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: [service.baseUrl] });
    },
  });

  const useUpdate = () => useMutation({
    mutationFn: (data: T) => service.update(data),
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: [service.baseUrl] });
    },
  });

  const useDelete = () => useMutation({
    mutationFn: (id: number) => service.delete(id),
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: [service.baseUrl] });
    },
  });

  return {
    useGetAll,
    useGetById,
    useGetPaginated,
    useCreate,
    useUpdate,
    useDelete,
  };
}