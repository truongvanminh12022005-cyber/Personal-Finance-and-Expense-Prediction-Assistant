import React from 'react';
import { BrowserRouter, Routes, Route, Navigate } from 'react-router-dom';

// Import các trang
import LoginPage from './pages/Auth/LoginPage';
import MainLayout from './layouts/MainLayout';
import DashboardPage from './pages/admin/DashboardPage'; // <-- File mới tạo ở bước 1
import UserPage from './pages/Users/UserPage';          // <-- File mới tạo ở bước 2
import BlogPage from './pages/Blogs/BlogPage';          // <-- File mới tạo ở bước 3

const App = () => {
  return (
    <BrowserRouter>
      <Routes>
        {/* Chuyển hướng mặc định về Login */}
        <Route path="/" element={<Navigate to="/login" replace />} />
        
        {/* Trang Login */}
        <Route path="/login" element={<LoginPage />} />

        {/* Khu vực Admin (Được bảo vệ bởi MainLayout) */}
        <Route path="/admin" element={<MainLayout />}>
          {/* Dashboard chính */}
          <Route path="dashboard" element={<DashboardPage />} />
          
          {/* Quản lý Users */}
          <Route path="users" element={<UserPage />} />
          
          {/* Quản lý Blogs */}
          <Route path="blogs" element={<BlogPage />} />

          {/* Cấu hình (Tạm thời dẫn về dashboard hoặc tạo trang Settings sau) */}
          <Route path="settings" element={<h2>⚙️ Trang cấu hình hệ thống (Đang phát triển)</h2>} />
        </Route>

        {/* Xử lý 404 - Trang không tồn tại */}
        <Route path="*" element={<Navigate to="/login" replace />} />
      </Routes>
    </BrowserRouter>
  );
};

export default App;