import React, { useEffect, useState } from 'react';
// Chỉ dùng 1 dòng import duy nhất cho antd
import { Table, Card, Tag, Button, Space, Typography, message, Popconfirm } from 'antd';
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
      setUsers(response);
    } catch (error) {
      message.error('Không thể lấy danh sách người dùng!');
    } finally {
      setLoading(false);
    }
  };

  // Hàm xóa người dùng
  const handleDelete = async (id) => {
    try {
      await userApi.delete(id);
      message.success('Xóa người dùng thành công!');
      fetchUsers(); 
    } catch (error) {
      message.error('Xóa thất bại! Có thể do lỗi mạng hoặc server.');
    }
  };

  useEffect(() => {
    fetchUsers();
  }, []);

  const columns = [
    {
      title: 'Họ và tên',
      dataIndex: 'fullName',
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
      render: () => <Tag color="green">Hoạt động</Tag>,
    },
    {
      title: 'Hành động',
      key: 'action',
      render: (_, record) => (
        <Space size="middle">
          <Button type="primary" icon={<EditOutlined />} size="small">Sửa</Button>
          
          {/* Nút Xóa có xác nhận */}
          <Popconfirm
            title="Cảnh báo"
            description="Bạn có chắc chắn muốn xóa người dùng này không?"
            onConfirm={() => handleDelete(record.id)}
            okText="Xóa"
            cancelText="Hủy"
            okButtonProps={{ danger: true }}
          >
            <Button type="primary" danger icon={<DeleteOutlined />} size="small">Xóa</Button>
          </Popconfirm>
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
          pagination={{ pageSize: 5 }} 
        />
      </Card>
    </div>
  );
};

export default UserPage;