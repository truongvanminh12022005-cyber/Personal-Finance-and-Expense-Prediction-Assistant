import React, { useState } from 'react';
import { Form, Input, Button, Card, Typography, message } from 'antd'; 
import { UserOutlined, LockOutlined } from '@ant-design/icons';
import authApi from '../../api/authApi';
import { useNavigate } from 'react-router-dom';

const { Title, Text } = Typography;

const LoginPage = () => {
  const [loading, setLoading] = useState(false);
  const navigate = useNavigate();

  const onFinish = async (values) => {
    setLoading(true);
    try {
      // Gọi API login
      const response = await authApi.login({
        email: values.email,
        password: values.password
      });

      console.log("--> Debug Response:", response); // Bật F12 Console để xem kết quả

      const token = response.accessToken || response.token || response.access_token;

      if (token) {
        // 1. Lưu Access Token quan trọng nhất
        localStorage.setItem('accessToken', token);
        
        // 2. Lưu Refresh Token (nếu có - dùng để gia hạn đăng nhập)
        if (response.refreshToken) {
            localStorage.setItem('refreshToken', response.refreshToken);
        }

        // 3. Lưu thông tin User (để hiển thị tên, avatar...)
        if (response.user) {
            localStorage.setItem('user', JSON.stringify(response.user));
        }

        message.success('Đăng nhập thành công!');
        
        // 4. Chuyển hướng vào trang Dashboard
        navigate('/admin/dashboard');
      } else {
        // Trường hợp API trả về thành công nhưng thiếu Token
        console.error("Lỗi: Không tìm thấy Token trong phản hồi:", response);
        message.error('Lỗi hệ thống: Server không trả về Token.');
      }

    } catch (error) {
      console.error("Lỗi đăng nhập:", error);
      message.error('Đăng nhập thất bại! Vui lòng kiểm tra lại Email và Mật khẩu.');
    } finally {
      setLoading(false);
    }
  };

  return (
    <div style={{ 
      display: 'flex', 
      justifyContent: 'center', 
      alignItems: 'center', 
      minHeight: '100vh', 
      backgroundColor: '#f0f2f5', 
      backgroundImage: 'linear-gradient(135deg, #f0f2f5 0%, #d9e2ec 100%)' 
    }}>
      
      <Card 
        bordered={false} 
        style={{ 
          width: 420, 
          boxShadow: '0 4px 20px rgba(0,0,0,0.08)', 
          borderRadius: 12, 
          padding: 20
        }}
      >
        {/* --- LOGO & TIÊU ĐỀ --- */}
        <div style={{ textAlign: 'center', marginBottom: 30 }}>
          <h1 style={{ 
            fontSize: '2.5rem', 
            fontWeight: '800', 
            margin: 0,
            background: 'linear-gradient(45deg, #1890ff, #722ed1)',
            WebkitBackgroundClip: 'text',
            WebkitTextFillColor: 'transparent'
          }}>
            FEPA
          </h1>
          <Text type="secondary" style={{ fontSize: 16 }}>Trợ lý tài chính và dự toán chi tiêu cá nhân</Text>
        </div>

        {/* --- FORM --- */}
        <Form
          name="login_form"
          initialValues={{ remember: true }}
          onFinish={onFinish}
          layout="vertical"
          size="large"
        >
          <Form.Item
            name="email"
            rules={[
                { required: true, message: 'Vui lòng nhập Email!' },
                { type: 'email', message: 'Email không hợp lệ!' }
            ]}
          >
            <Input 
              prefix={<UserOutlined style={{ color: '#1890ff' }} />} 
              placeholder="Email đăng nhập" 
              style={{ borderRadius: 6 }}
            />
          </Form.Item>

          <Form.Item
            name="password"
            rules={[{ required: true, message: 'Vui lòng nhập mật khẩu!' }]}
          >
            <Input.Password 
              prefix={<LockOutlined style={{ color: '#1890ff' }} />} 
              placeholder="Mật khẩu" 
              style={{ borderRadius: 6 }}
            />
          </Form.Item>

          <Form.Item style={{ marginBottom: 10 }}>
            <Button 
              type="primary" 
              htmlType="submit" 
              block 
              loading={loading} 
              style={{ 
                height: 48, 
                fontWeight: 'bold', 
                fontSize: 16,
                borderRadius: 6,
                background: 'linear-gradient(90deg, #1890ff 0%, #40a9ff 100%)',
                border: 'none'
              }}
            >
              ĐĂNG NHẬP
            </Button>
          </Form.Item>
        </Form>

        <div style={{ textAlign: 'center', marginTop: 20 }}>
          <Text type="secondary" style={{ fontSize: 12 }}>© 2025 FEPA Project</Text>
        </div>
      </Card>
    </div>
  );
};

export default LoginPage;