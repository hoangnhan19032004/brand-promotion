import { Routes, Route } from 'react-router-dom';
import { Layout } from 'antd';
import BrandsPage from './pages/BrandsPage';

const { Header, Content, Footer } = Layout;

function App() {
  return (
    <Layout style={{ minHeight: '100vh' }}>
      <Header style={{ color: 'white', fontSize: 20 }}>
        🏷️ Brand Promotion
      </Header>
      <Content style={{ padding: '24px' }}>
        <Routes>
          
          <Route path="/brands" element={<BrandsPage />} />
          
        </Routes>
      </Content>
      <Footer style={{ textAlign: 'center' }}>
        Brand Promotion ©2024
      </Footer>
    </Layout>
  );
}

export default App;