import React, { useState, useEffect } from 'react';
import { Layout, Menu, Button, theme, Avatar, Dropdown, message } from 'antd';
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
  const [user, setUser] = useState(null);
  
  const {
    token: { colorBgContainer, borderRadiusLG },
  } = theme.useToken();

  // Lấy tên User từ LocalStorage để hiển thị "Xin chào..."
  useEffect(() => {
    const userStr = localStorage.getItem('user');
    if (userStr) {
        setUser(JSON.parse(userStr));
    }
  }, []);

  // --- HÀM XỬ LÝ ĐĂNG XUẤT ---
  const handleLogout = () => {
    // 1. Xóa Token
    localStorage.removeItem('accessToken');
    localStorage.removeItem('refreshToken');
    localStorage.removeItem('user');

    // 2. Thông báo
    message.success('Đã đăng xuất thành công!');

    // 3. Chuyển về trang login
    navigate('/login');
  };

  // Menu Dropdown (Khi bấm vào Avatar góc phải)
  const userMenu = {
    items: [
      { key: '1', label: 'Hồ sơ cá nhân', icon: <UserOutlined /> },
      { type: 'divider' },
      { 
        key: 'logout', 
        label: 'Đăng xuất', 
        icon: <LogoutOutlined />, 
        danger: true, 
        onClick: handleLogout // Gọi hàm đăng xuất
      },
    ]
  };

  return (
    <Layout style={{ minHeight: '100vh' }}>
      {/* --- SIDEBAR (MENU TRÁI) --- */}
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
          // Xử lý khi bấm vào menu
          onClick={({ key }) => {
            if (key === 'logout-sidebar') {
                handleLogout(); // Nếu bấm nút đăng xuất ở sidebar
            } else {
                navigate(key); // Nếu bấm các nút khác thì chuyển trang
            }
          }}
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
              type: 'divider', // Đường gạch ngang phân cách
            },
            {
              key: '/admin/settings',
              icon: <SettingOutlined />,
              label: 'Cấu hình hệ thống',
            },
            // --- THÊM NÚT ĐĂNG XUẤT VÀO MENU TRÁI ---
            {
              key: 'logout-sidebar',
              icon: <LogoutOutlined />,
              label: 'Đăng xuất',
              danger: true, // Màu đỏ cảnh báo
            },
          ]}
        />
      </Sider>

      <Layout>
        {/* --- HEADER (THANH TRÊN CÙNG) --- */}
        <Header style={{ padding: 0, background: colorBgContainer, display: 'flex', justifyContent: 'space-between', alignItems: 'center', paddingRight: 24 }}>
          <Button
            type="text"
            icon={collapsed ? <MenuUnfoldOutlined /> : <MenuFoldOutlined />}
            onClick={() => setCollapsed(!collapsed)}
            style={{ fontSize: '16px', width: 64, height: 64 }}
          />
          
          <div style={{ display: 'flex', alignItems: 'center', gap: 10 }}>
            {/* Hiển thị tên Admin lấy từ LocalStorage */}
            <span style={{ fontWeight: 500 }}>Xin chào, {user?.fullName || 'Admin'}</span>
            
            {/* Avatar có menu sổ xuống */}
            <Dropdown menu={userMenu} placement="bottomRight" arrow>
              <Avatar 
                style={{ backgroundColor: '#1890ff', cursor: 'pointer' }} 
                icon={<UserOutlined />} 
                src={user?.avatarUrl} // Nếu có ảnh thì hiện, ko thì hiện icon
              />
            </Dropdown>
          </div>
        </Header>

        {/* --- CONTENT (NỘI DUNG CHÍNH) --- */}
        <Content style={{ margin: '24px 16px', padding: 24, minHeight: 280, background: colorBgContainer, borderRadius: borderRadiusLG }}>
          <Outlet />
        </Content>
      </Layout>
    </Layout>
  );
};

export default MainLayout;