import axiosInstance from './axiosInstance';
import type { Brand } from '../types';

export const brandApi = {
  getAll: () =>
    axiosInstance.get<Brand[]>('/brands').then(res => res.data),

  getById: (id: string) =>
    axiosInstance.get<Brand>(`/brands/${id}`).then(res => res.data),

  create: (data: Omit<Brand, 'id' | 'createdAt'>) =>
    axiosInstance.post<Brand>('/brands', data).then(res => res.data),

  update: (id: string, data: Partial<Brand>) =>
    axiosInstance.put<void>(`/brands/${id}`, data),

  delete: (id: string) =>
    axiosInstance.delete<void>(`/brands/${id}`),
};