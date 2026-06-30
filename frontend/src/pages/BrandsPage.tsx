import { useMemo } from 'react';
import { Link } from 'react-router-dom';
import { useBrands } from '../hooks/useBrands';
import type { Brand, Product, Campaign } from '../types';

const MOCK_PRODUCTS: Product[] = [
  {
    id: 'mock-p1',
    name: 'Áo khoác denim oversize',
    brandId: 'mock-b1',
    price: 890000,
    discountPrice: 690000,
    description: 'Form rộng, vải denim dày dặn',
    images: [],
    tags: ['mới', 'bán chạy'],
    isFeatured: true,
    isActive: true,
  },
  {
    id: 'mock-p2',
    name: 'Giày sneaker thể thao',
    brandId: 'mock-b2',
    price: 1490000,
    description: 'Đế êm, phù hợp chạy bộ hằng ngày',
    images: [],
    tags: ['running'],
    isFeatured: true,
    isActive: true,
  },
  {
    id: 'mock-p3',
    name: 'Túi tote vải canvas',
    brandId: 'mock-b1',
    price: 350000,
    discountPrice: 280000,
    description: 'Chống nước nhẹ, bền theo thời gian',
    images: [],
    tags: ['phụ kiện'],
    isFeatured: true,
    isActive: true,
  },
  {
    id: 'mock-p4',
    name: 'Đồng hồ dây da',
    brandId: 'mock-b3',
    price: 2190000,
    description: 'Mặt kính sapphire chống trầy',
    images: [],
    tags: ['cao cấp'],
    isFeatured: true,
    isActive: true,
  },
];

const MOCK_CAMPAIGNS: Campaign[] = [
  {
    id: 'mock-c1',
    title: 'Mùa Hè Rực Lửa',
    brandId: 'mock-b1',
    description: 'Giảm giá toàn bộ sản phẩm denim và phụ kiện mùa hè',
    discountPercent: 30,
    startDate: '2026-06-01',
    endDate: '2026-07-31',
    isActive: true,
  },
  {
    id: 'mock-c2',
    title: 'Chào Sân Vận Động',
    brandId: 'mock-b2',
    description: 'Ưu đãi đặc biệt cho dòng giày thể thao mới ra mắt',
    discountPercent: 20,
    startDate: '2026-06-15',
    endDate: '2026-07-15',
    isActive: true,
  },
];

const formatVnd = (value: number) =>
  new Intl.NumberFormat('vi-VN', { style: 'currency', currency: 'VND' }).format(value);

function daysRemaining(endDate: string): number {
  const diff = new Date(endDate).getTime() - Date.now();
  return Math.max(0, Math.ceil(diff / (1000 * 60 * 60 * 24)));
}

export default function BrandsPage() {
  const { data: brands, isLoading: brandsLoading, isError: brandsError } = useBrands();

  const activeBrands = useMemo<Brand[]>(
    () => (brands ?? []).filter((brand) => brand.isActive).slice(0, 8),
    [brands]
  );

  return (
    <div className="home">
      <section className="hero">
        <div className="hero__content">
          <span className="hero__eyebrow">PHIẾU ƯU ĐÃI · TOÀN SÀN</span>
          <h1 className="hero__title">
            Thương hiệu thật.
            <br />
            Giá thật. Quảng bá thật.
          </h1>
          <p className="hero__subtitle">
            Khám phá các thương hiệu đang được quảng bá, sản phẩm nổi bật
            và chiến dịch giảm giá đang diễn ra — cập nhật trực tiếp từ hệ thống.
          </p>

          <div className="hero__actions">
            <Link to="/brands" className="btn btn--primary">
              Xem thương hiệu
            </Link>
            <a href="#featured" className="btn btn--ghost">
              Sản phẩm nổi bật
            </a>
          </div>

          <div className="hero__highlights">
            <div>
              <strong>120+</strong>
              <span>thương hiệu kết nối</span>
            </div>
            <div>
              <strong>24/7</strong>
              <span>cập nhật ưu đãi</span>
            </div>
            <div>
              <strong>4.9/5</strong>
              <span>đánh giá trải nghiệm</span>
            </div>
          </div>
        </div>

        <div className="hero__panel">
          <div className="hero__panel-card">
            <span className="hero__panel-label">Ưu đãi mùa này</span>
            <div className="hero__panel-value">30%</div>
            <p>Giảm giá đặc biệt cho các sản phẩm mới và chiến dịch giới thiệu.</p>
            <div className="hero__panel-pill">Mã BP-2026</div>
          </div>
        </div>
      </section>

      <section className="section">
        <div className="section__head">
          <div>
            <span className="section__eyebrow">01 · Thương hiệu</span>
            <h2 className="section__title">Đang được quảng bá</h2>
          </div>
          <Link to="/brands" className="section__link">
            Xem tất cả →
          </Link>
        </div>

        {brandsLoading && <p className="state-text">Đang tải thương hiệu…</p>}
        {brandsError && (
          <p className="state-text state-text--error">
            Không tải được danh sách thương hiệu. Kiểm tra lại API backend.
          </p>
        )}
        {!brandsLoading && !brandsError && activeBrands.length === 0 && (
          <p className="state-text">Chưa có thương hiệu nào được tạo.</p>
        )}

        {activeBrands.length > 0 && (
          <div className="brand-row">
            {activeBrands.map((brand) => (
              <Link to="/brands" key={brand.id} className="brand-chip">
                {brand.logo ? (
                  <img src={brand.logo} alt={brand.name} className="brand-chip__logo" />
                ) : (
                  <span className="brand-chip__fallback">
                    {brand.name.charAt(0).toUpperCase()}
                  </span>
                )}
                <span className="brand-chip__name">{brand.name}</span>
              </Link>
            ))}
          </div>
        )}
      </section>

      <section className="section section--soft">
        <div className="section__head">
          <div>
            <span className="section__eyebrow">02 · Danh mục</span>
            <h2 className="section__title">Khám phá theo nhu cầu</h2>
          </div>
        </div>

        <div className="category-grid">
          <article className="category-card category-card--accent">
            <h3>Thời trang</h3>
            <p>Áo khoác, giày dép, phụ kiện mới mỗi tuần</p>
          </article>
          <article className="category-card">
            <h3>Điện tử</h3>
            <p>Thiết bị thông minh và công nghệ hiện đại</p>
          </article>
          <article className="category-card">
            <h3>Gia dụng</h3>
            <p>Những sản phẩm tiện ích cho mọi gia đình</p>
          </article>
          <article className="category-card">
            <h3>Makeup & beauty</h3>
            <p>Chăm sóc cá nhân, làm đẹp và xu hướng mới</p>
          </article>
        </div>
      </section>

      <section className="section section--feature">
        <div className="feature-banner">
          <div>
            <span className="section__eyebrow">03 · Ưu đãi</span>
            <h2 className="section__title">Mua sắm thông minh, tiết kiệm tối đa</h2>
            <p>Nhận giảm giá lên đến 50% cho các sản phẩm được chọn lọc trong tuần này.</p>
          </div>
          <a href="#featured" className="btn btn--primary">
            Mua ngay
          </a>
        </div>
      </section>

      <section className="section" id="featured">
        <div className="section__head">
          <div>
            <span className="section__eyebrow">04 · Sản phẩm</span>
            <h2 className="section__title">Nổi bật tuần này</h2>
          </div>
        </div>

        <div className="product-grid">
          {MOCK_PRODUCTS.map((product) => {
            const hasDiscount = !!product.discountPrice;

            return (
              <article key={product.id} className="product-card">
                <div className="product-card__media" />
                <div className="product-card__body">
                  <div className="product-card__topline">
                    <span className="product-card__tag">Cửa hàng mới</span>
                    {hasDiscount && (
                      <span className="product-card__badge">
                        -{Math.round((1 - (product.discountPrice! / product.price)) * 100)}%
                      </span>
                    )}
                  </div>
                  <h3 className="product-card__name">{product.name}</h3>
                  <p className="product-card__desc">{product.description}</p>
                  <div className="product-card__price">
                    <span className="product-card__price-now">
                      {formatVnd(product.discountPrice ?? product.price)}
                    </span>
                    {hasDiscount && (
                      <span className="product-card__price-old">
                        {formatVnd(product.price)}
                      </span>
                    )}
                  </div>
                </div>
              </article>
            );
          })}
        </div>
      </section>

      <section className="section section--dark">
        <div className="section__head">
          <div>
            <span className="section__eyebrow">05 · Chiến dịch</span>
            <h2 className="section__title">Khuyến mãi đang diễn ra</h2>
          </div>
        </div>

        <div className="campaign-row">
          {MOCK_CAMPAIGNS.map((campaign) => (
            <article key={campaign.id} className="campaign-card">
              <div className="campaign-card__top">
                <span className="campaign-card__percent">-{campaign.discountPercent}%</span>
                <span className="campaign-card__days">còn {daysRemaining(campaign.endDate)} ngày</span>
              </div>
              <h3 className="campaign-card__title">{campaign.title}</h3>
              <p className="campaign-card__desc">{campaign.description}</p>
            </article>
          ))}
        </div>
      </section>
    </div>
  );
}