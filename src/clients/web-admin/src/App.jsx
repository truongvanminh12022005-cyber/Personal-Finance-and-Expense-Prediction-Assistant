import React from 'react';
import { BrowserRouter, Routes, Route, Navigate } from 'react-router-dom';
import LoginPage from './pages/Auth/LoginPage';
import MainLayout from './layouts/MainLayout';
import UserPage from './pages/Users/UserPage'; 


const Dashboard = () => <h2>📊 Thống kê doanh thu & người dùng</h2>;
const Blogs = () => <h2>✍️ Quản lý bài viết & tin tức</h2>;

const App = () => {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<Navigate to="/login" />} />
        <Route path="/login" element={<LoginPage />} />

        
        <Route path="/admin" element={<MainLayout />}>
          <Route path="dashboard" element={<Dashboard />} />
          
          <Route path="users" element={<UserPage />} />
          
          <Route path="blogs" element={<Blogs />} />
        </Route>

      </Routes>
    </BrowserRouter>
  );
};

export default App;