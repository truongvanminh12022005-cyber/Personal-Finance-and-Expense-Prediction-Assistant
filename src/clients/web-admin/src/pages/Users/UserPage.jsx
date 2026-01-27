import React, { useEffect, useState } from 'react';
import { Table, Card, Tag, Button, Space, Typography, message, Popconfirm, Modal, Form, Input } from 'antd';
import { EditOutlined, DeleteOutlined, UserAddOutlined } from '@ant-design/icons';
import userApi from '../../api/userApi';

const { Title } = Typography;

const UserPage = () => {
  const [users, setUsers] = useState([]);
  const [loading, setLoading] = useState(false);
  const [isModalOpen, setIsModalOpen] = useState(false);
  const [editingUser, setEditingUser] = useState(null);
  const [form] = Form.useForm();

  // Tải danh sách
  const fetchUsers = async () => {
    setLoading(true);
    try {
      const response = await userApi.getAll();
      setUsers(response);
    } catch (error) {
      message.error('Lỗi tải danh sách!');
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    fetchUsers();
  }, []);

  // Mở Modal Thêm
  const handleOpenAdd = () => {
    setEditingUser(null);
    form.resetFields();
    setIsModalOpen(true);
  };

  // Mở Modal Sửa
  const handleOpenEdit = (record) => {
    setEditingUser(record);
    form.setFieldsValue(record);
    setIsModalOpen(true);
  };

  // 4. Xử lý Lưu
  const handleSave = async (values) => {
    try {
      if (editingUser) {
        // --- SỬA ---

        await userApi.update(editingUser.id, { ...editingUser, ...values });
        message.success('Cập nhật thành công!');
      } else {
        // --- THÊM ---
        await userApi.create(values);
        message.success('Thêm người dùng thành công!');
      }
      setIsModalOpen(false);
      fetchUsers();
    } catch (error) {
      message.error(editingUser ? 'Cập nhật thất bại!' : 'Email này đã được sử dụng!');
    }
  };

  // Xử lý Xóa
  const handleDelete = async (id) => {
    try {
      await userApi.delete(id);
      message.success('Đã xóa!');
      fetchUsers();
    } catch (error) {
      message.error('Xóa thất bại!');
    }
  };

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
          <Button type="primary" icon={<EditOutlined />} size="small" onClick={() => handleOpenEdit(record)}>Sửa</Button>

          <Popconfirm title="Xóa người này?" onConfirm={() => handleDelete(record.id)} okText="Xóa" cancelText="Hủy" okButtonProps={{ danger: true }}>
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
        <Button type="primary" icon={<UserAddOutlined />} onClick={handleOpenAdd}>Thêm mới</Button>
      </div>

      <Card>
        <Table columns={columns} dataSource={users} rowKey="id" loading={loading} pagination={{ pageSize: 6 }} />
      </Card>

      {/* --- MODAL NHẬP LIỆU --- */}
      <Modal
        title={editingUser ? "Chỉnh sửa thông tin" : "Thêm người dùng mới"}
        open={isModalOpen}
        onCancel={() => setIsModalOpen(false)}
        footer={null}
      >
        <Form form={form} layout="vertical" onFinish={handleSave}>
          <Form.Item name="fullName" label="Họ và tên" rules={[{ required: true, message: 'Vui lòng nhập tên!' }]}>
            <Input />
          </Form.Item>

          <Form.Item name="email" label="Email" rules={[{ required: true, type: 'email', message: 'Email không hợp lệ!' }]}>
            <Input disabled={!!editingUser} />
            {/* Khi sửa thì khóa ô Email lại để tránh lỗi hệ thống */}
          </Form.Item>

          {/* Chỉ hiện ô nhập mật khẩu khi Thêm mới */}
          {!editingUser && (
            <Form.Item name="password" label="Mật khẩu" rules={[{ required: true, message: 'Nhập mật khẩu!' }]}>
              <Input.Password />
            </Form.Item>
          )}

          <div style={{ textAlign: 'right', marginTop: 20 }}>
            <Space>
              <Button onClick={() => setIsModalOpen(false)}>Hủy</Button>
              <Button type="primary" htmlType="submit">
                {editingUser ? "Lưu thay đổi" : "Tạo tài khoản"}
              </Button>
            </Space>
          </div>
        </Form>
      </Modal>
    </div>
  );
};

export default UserPage;