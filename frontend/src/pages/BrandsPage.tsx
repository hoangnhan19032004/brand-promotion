import { Table, Button, Space, Tag, Spin } from 'antd';
import { useBrands, useDeleteBrand } from '../hooks/useBrands';
import type { Brand } from '../types';

export default function BrandsPage() {
  const { data: brands, isLoading } = useBrands();
  const deleteBrand = useDeleteBrand();

  const columns = [
    { title: 'Tên thương hiệu', dataIndex: 'name', key: 'name' },
    { title: 'Website', dataIndex: 'website', key: 'website' },
    {
      title: 'Trạng thái',
      dataIndex: 'isActive',
      key: 'isActive',
      render: (v: boolean) => (
        <Tag color={v ? 'green' : 'red'}>{v ? 'Hoạt động' : 'Ẩn'}</Tag>
      ),
    },
    {
      title: 'Hành động',
      key: 'action',
      render: (_: unknown, record: Brand) => (
        <Space>
          <Button type="primary" size="small">Sửa</Button>
          <Button
            danger
            size="small"
            onClick={() => deleteBrand.mutate(record.id)}
          >
            Xóa
          </Button>
        </Space>
      ),
    },
  ];

  if (isLoading) return <Spin size="large" />;

  return (
    <div>
      <div style={{ marginBottom: 16, display: 'flex', justifyContent: 'space-between' }}>
        <h2>Quản lý Thương hiệu</h2>
        <Button type="primary">+ Thêm thương hiệu</Button>
      </div>
      <Table
        dataSource={brands}
        columns={columns}
        rowKey="id"
        pagination={{ pageSize: 10 }}
      />
    </div>
  );
}