import { useState } from 'react';
import { NavLink } from 'react-router-dom';

const navItems = [
  { to: '/', label: 'Trang chủ' },
  { to: '/brands', label: 'Thương hiệu' },
  { to: '/products', label: 'Sản phẩm' },
  { to: '/offers', label: 'Ưu đãi' },
];

export function AppHeader() {
  const [showSearch, setShowSearch] = useState(false);
  const [query, setQuery] = useState('');

  return (
    <>
      <header className="site-header">
        <div className="site-header__brand">
          <img src="/Logo.png" alt="V-Shop Viet" className="site-header__logo" />
          <div>
            <div className="site-header__title">V-Shop Viet</div>
            <div className="site-header__subtitle">Marketplace & campaigns</div>
          </div>
        </div>

        <nav className="site-header__nav" aria-label="Primary navigation">
          {navItems.map((item) => (
            <NavLink key={item.to} to={item.to} end={item.to === '/'}>
              {item.label}
            </NavLink>
          ))}
        </nav>

        <div className="site-header__actions">
          <a href="#featured" className="site-header__cta">
            <span>Khám phá ngay</span>
          </a>

          <button
            type="button"
            className="site-header__icon-btn"
            aria-label="Tìm kiếm"
            onClick={() => setShowSearch((value) => !value)}
          >
            🔍
          </button>

          <button type="button" className="site-header__icon-btn site-header__icon-btn--login" aria-label="Đăng nhập">
            👤
          </button>
        </div>
      </header>

      {showSearch && (
        <div className="site-header__search-panel">
          <div className="site-header__search">
            <input
              type="text"
              value={query}
              onChange={(event) => setQuery(event.target.value)}
              placeholder="Tìm sản phẩm hoặc thương hiệu..."
              aria-label="Tìm kiếm"
            />
            <button type="button" className="site-header__search-btn">
              Tìm
            </button>
          </div>
        </div>
      )}
    </>
  );
}
