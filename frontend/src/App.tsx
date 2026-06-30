import { Layout } from 'antd';
import { Route, Routes } from 'react-router-dom';
import { AppHeader } from './components/layout/Header';
import { AppFooter } from './components/layout/Footer';
import BrandsPage from './pages/BrandsPage';

const { Content } = Layout;

function App() {
  return (
    <Layout className="app-shell">
      <AppHeader />

      <Content className="app-content">
        <Routes>
          <Route path="/" element={<BrandsPage />} />
          <Route path="/brands" element={<BrandsPage />} />
          <Route path="/products" element={<BrandsPage />} />
        </Routes>
      </Content>

      <AppFooter />
    </Layout>
  );
}

export default App;