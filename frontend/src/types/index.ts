export interface Brand {
  id: string;
  name: string;
  logo?: string;
  description?: string;
  website?: string;
  isActive: boolean;
  createdAt: string;
}

export interface Product {
  id: string;
  name: string;
  brandId: string;
  price: number;
  discountPrice?: number;
  description?: string;
  images: string[];
  tags: string[];
  isFeatured: boolean;
  isActive: boolean;
}

export interface Campaign {
  id: string;
  title: string;
  brandId: string;
  description: string;
  discountPercent: number;
  startDate: string;
  endDate: string;
  isActive: boolean;
}