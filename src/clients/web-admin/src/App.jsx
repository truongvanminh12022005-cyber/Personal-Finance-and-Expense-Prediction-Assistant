import React from 'react';
import { BrowserRouter, Routes, Route, Navigate } from 'react-router-dom';

// 1. Import các trang cũ
import LoginPage from './pages/Auth/LoginPage';
import MainLayout from './layouts/MainLayout';
import DashboardPage from './pages/admin/DashboardPage';
import UserPage from './pages/Users/UserPage';
import BlogPage from './pages/Blogs/BlogPage';
import SettingsPage from './pages/Settings/SettingsPage';

// 2. 👇 IMPORT CÁC TRANG MỚI VỪA LÀM 👇
import AdsPage from './pages/Ads/AdsPage';
import SubscriptionPage from './pages/Subscriptions/SubscriptionPage';

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

          {/* Tự động vào Dashboard nếu chỉ gõ /admin */}
          <Route index element={<Navigate to="dashboard" replace />} />

          {/* Dashboard chính */}
          <Route path="dashboard" element={<DashboardPage />} />

          {/* Quản lý Users */}
          <Route path="users" element={<UserPage />} />

          {/* Quản lý Blogs */}
          <Route path="blogs" element={<BlogPage />} />

          {/* 👇 CÁC ROUTE MỚI THÊM VÀO 👇 */}
          <Route path="ads" element={<AdsPage />} />
          <Route path="subscriptions" element={<SubscriptionPage />} />
          {/* ----------------------------- */}

          {/* Cấu hình */}
          <Route path="settings" element={<SettingsPage />} />
        </Route>

        {/* Xử lý 404 - Trang không tồn tại */}
        <Route path="*" element={<Navigate to="/login" replace />} />
      </Routes>
    </BrowserRouter>
  );
};

export default App;