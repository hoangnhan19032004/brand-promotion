import { useQuery, useMutation, useQueryClient } from '@tanstack/react-query';
import { brandApi } from '../api/brandApi';

export const useBrands = () => {
  return useQuery({
    queryKey: ['brands'], 
    queryFn: brandApi.getAll,
  });
};

export const useCreateBrand = () => {
  const queryClient = useQueryClient();
  return useMutation({
    mutationFn: brandApi.create,
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ['brands'] });
    },
  });
};

export const useDeleteBrand = () => {
  const queryClient = useQueryClient();
  return useMutation({
    mutationFn: brandApi.delete,
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ['brands'] });
    },
  });
};