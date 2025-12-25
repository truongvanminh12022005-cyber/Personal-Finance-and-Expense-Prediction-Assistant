import React, { useState } from 'react';
import { Layout, Menu, Button, theme, Avatar, Dropdown } from 'antd';
import {
  MenuFoldOutlined,
  MenuUnfoldOutlined,
  UserOutlined,
  DashboardOutlined,
  FileTextOutlined,
  SettingOutlined,
  LogoutOutlined,
  TeamOutlined
} from '@ant-design/icons';
import { Outlet, useNavigate, useLocation } from 'react-router-dom';

const { Header, Sider, Content } = Layout;

const MainLayout = () => {
  const [collapsed, setCollapsed] = useState(false);
  const navigate = useNavigate();
  const location = useLocation();
  
  const {
    token: { colorBgContainer, borderRadiusLG },
  } = theme.useToken();

  // Xử lý Đăng xuất
  const handleLogout = () => {
    localStorage.removeItem('accessToken');
    navigate('/login');
  };

  // MenuDropdown cho Avatar
  const userMenu = (
    <Menu items={[
      { key: '1', label: 'Hồ sơ cá nhân', icon: <UserOutlined /> },
      { type: 'divider' },
      { key: '2', label: 'Đăng xuất', icon: <LogoutOutlined />, danger: true, onClick: handleLogout },
    ]} />
  );

  return (
    <Layout style={{ minHeight: '100vh' }}>
      {/* --- SIDEBAR --- */}
      <Sider trigger={null} collapsible collapsed={collapsed} width={250} style={{ background: '#001529' }}>
        <div style={{ height: 64, display: 'flex', alignItems: 'center', justifyContent: 'center', background: 'rgba(255,255,255,0.1)' }}>
          <h1 style={{ color: 'white', fontSize: collapsed ? 16 : 24, fontWeight: 'bold', margin: 0, transition: 'all 0.3s' }}>
            {collapsed ? 'FP' : 'FEPA ADMIN'}
          </h1>
        </div>
        
        <Menu
          theme="dark"
          mode="inline"
          defaultSelectedKeys={[location.pathname]}
          onClick={({ key }) => navigate(key)}
          items={[
            {
              key: '/admin/dashboard',
              icon: <DashboardOutlined />,
              label: 'Tổng quan (Dashboard)',
            },
            {
              key: '/admin/users',
              icon: <TeamOutlined />,
              label: 'Quản lý Người dùng',
            },
            {
              key: '/admin/blogs',
              icon: <FileTextOutlined />,
              label: 'Quản lý Bài viết',
            },
            {
              key: '/admin/settings',
              icon: <SettingOutlined />,
              label: 'Cấu hình hệ thống',
            },
          ]}
        />
      </Sider>

      <Layout>
        {/* --- HEADER --- */}
        <Header style={{ padding: 0, background: colorBgContainer, display: 'flex', justifyContent: 'space-between', alignItems: 'center', paddingRight: 24 }}>
          <Button
            type="text"
            icon={collapsed ? <MenuUnfoldOutlined /> : <MenuFoldOutlined />}
            onClick={() => setCollapsed(!collapsed)}
            style={{ fontSize: '16px', width: 64, height: 64 }}
          />
          
          <div style={{ display: 'flex', alignItems: 'center', gap: 10 }}>
            <span style={{ fontWeight: 500 }}>Xin chào, Admin</span>
            <Dropdown overlay={userMenu} placement="bottomRight" arrow>
              <Avatar style={{ backgroundColor: '#1890ff', cursor: 'pointer' }} icon={<UserOutlined />} />
            </Dropdown>
          </div>
        </Header>

        {/* --- CONTENT (NỘI DUNG CHÍNH) --- */}
        <Content style={{ margin: '24px 16px', padding: 24, minHeight: 280, background: colorBgContainer, borderRadius: borderRadiusLG }}>
          {/* Outlet là nơi các trang con (Dashboard, Users...) sẽ hiển thị */}
          <Outlet />
        </Content>
      </Layout>
    </Layout>
  );
};

export default MainLayout;