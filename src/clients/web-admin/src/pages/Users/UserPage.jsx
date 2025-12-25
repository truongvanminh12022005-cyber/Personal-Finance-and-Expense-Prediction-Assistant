import React, { useEffect, useState } from 'react';
import { Table, Card, Tag, Button, Space, Typography, message } from 'antd';
import { EditOutlined, DeleteOutlined, UserAddOutlined } from '@ant-design/icons';
import userApi from '../../api/userApi';

const { Title } = Typography;

const UserPage = () => {
  const [users, setUsers] = useState([]);
  const [loading, setLoading] = useState(false);

  // Hàm gọi API lấy dữ liệu
  const fetchUsers = async () => {
    setLoading(true);
    try {
      const response = await userApi.getAll();
      setUsers(response); // Lưu dữ liệu lấy được vào biến users
    } catch (error) {
      message.error('Không thể lấy danh sách người dùng!');
    } finally {
      setLoading(false);
    }
  };

  // Chạy hàm này 1 lần ngay khi mở trang
  useEffect(() => {
    fetchUsers();
  }, []);

  // Cấu hình các cột của bảng
  const columns = [
    {
      title: 'ID',
      dataIndex: 'id',
      key: 'id',
      width: 80,
    },
    {
      title: 'Họ và tên',
      dataIndex: 'fullName', // Phải trùng với tên biến trong Backend trả về
      key: 'fullName',
      render: (text) => <b>{text}</b>,
    },
    {
      title: 'Email',
      dataIndex: 'email',
      key: 'email',
    },
    {
      title: 'Trạng thái',
      key: 'status',
      render: () => <Tag color="green">Hoạt động</Tag>, // Tạm thời để cứng
    },
    {
      title: 'Hành động',
      key: 'action',
      render: (_, record) => (
        <Space size="middle">
          <Button type="primary" icon={<EditOutlined />} size="small">Sửa</Button>
          <Button type="primary" danger icon={<DeleteOutlined />} size="small">Xóa</Button>
        </Space>
      ),
    },
  ];

  return (
    <div>
      <div style={{ display: 'flex', justifyContent: 'space-between', marginBottom: 20 }}>
        <Title level={3}>Quản lý người dùng</Title>
        <Button type="primary" icon={<UserAddOutlined />}>Thêm mới</Button>
      </div>

      <Card>
        <Table 
          columns={columns} 
          dataSource={users} 
          rowKey="id" 
          loading={loading}
          pagination={{ pageSize: 5 }} // Phân trang, mỗi trang 5 dòng
        />
      </Card>
    </div>
  );
};

export default UserPage;