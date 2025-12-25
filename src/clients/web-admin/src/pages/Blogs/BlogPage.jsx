import React, { useEffect, useState } from 'react';
import { Table, Card, Button, Space, Typography, message, Popconfirm, Modal, Form, Input } from 'antd';
import { DeleteOutlined, PlusOutlined, EditOutlined, EyeOutlined } from '@ant-design/icons';
import blogApi from '../../api/blogApi';

const { Title } = Typography;
const { TextArea } = Input;

const BlogPage = () => {
  const [blogs, setBlogs] = useState([]);
  const [loading, setLoading] = useState(false);
  
  // State cho Modal Thêm/Sửa
  const [isModalOpen, setIsModalOpen] = useState(false);
  const [editingBlog, setEditingBlog] = useState(null); // Lưu bài đang sửa (nếu có)
  
  // State cho Modal Xem chi tiết
  const [viewModalOpen, setViewModalOpen] = useState(false);
  const [viewContent, setViewContent] = useState(null);

  const [form] = Form.useForm();

  const fetchBlogs = async () => {
    setLoading(true);
    try {
      const response = await blogApi.getAll();
      setBlogs(response);
    } catch (error) {
      message.error('Lỗi tải dữ liệu!');
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    fetchBlogs();
  }, []);

  // --- XỬ LÝ: MỞ MODAL THÊM ---
  const handleOpenAdd = () => {
    setEditingBlog(null); // Không có bài nào đang sửa -> Chế độ Thêm
    form.resetFields();   // Xóa trắng form
    setIsModalOpen(true);
  };

  // --- XỬ LÝ: MỞ MODAL SỬA ---
  const handleOpenEdit = (record) => {
    setEditingBlog(record); // Lưu bài cần sửa
    form.setFieldsValue(record); // Điền dữ liệu cũ vào form
    setIsModalOpen(true);
  };

  // --- XỬ LÝ: MỞ MODAL XEM ---
  const handleView = (record) => {
    setViewContent(record);
    setViewModalOpen(true);
  };

  // --- XỬ LÝ: LƯU (DÙNG CHUNG CHO CẢ THÊM VÀ SỬA) ---
  const handleSave = async (values) => {
    try {
      if (editingBlog) {
        // Nếu đang sửa -> Gọi API Update
        // Cần truyền thêm ID vào object gửi đi cho khớp với Backend
        await blogApi.update(editingBlog.id, { ...values, id: editingBlog.id });
        message.success('Cập nhật thành công!');
      } else {
        // Nếu thêm mới -> Gọi API Create
        await blogApi.create(values);
        message.success('Đăng bài thành công!');
      }
      setIsModalOpen(false);
      fetchBlogs(); // Load lại bảng
    } catch (error) {
      message.error('Có lỗi xảy ra!');
    }
  };

  const handleDelete = async (id) => {
    try {
      await blogApi.delete(id);
      message.success('Đã xóa bài viết!');
      fetchBlogs();
    } catch (error) {
      message.error('Xóa thất bại!');
    }
  };

  const columns = [
    {
      title: 'Tiêu đề',
      dataIndex: 'title',
      key: 'title',
      width: '30%',
      render: (text) => <b style={{ color: '#1890ff' }}>{text}</b>,
    },
    {
      title: 'Tác giả',
      dataIndex: 'author',
      key: 'author',
    },
    {
      title: 'Ngày tạo',
      dataIndex: 'createdAt',
      key: 'createdAt',
      render: (date) => new Date(date).toLocaleDateString('vi-VN'),
    },
    {
      title: 'Hành động',
      key: 'action',
      render: (_, record) => (
        <Space size="small">
          {/* Nút Xem */}
          <Button icon={<EyeOutlined />} size="small" onClick={() => handleView(record)}>Xem</Button>
          
          {/* Nút Sửa */}
          <Button type="primary" icon={<EditOutlined />} size="small" onClick={() => handleOpenEdit(record)}>Sửa</Button>
          
          {/* Nút Xóa */}
          <Popconfirm title="Xóa bài này?" onConfirm={() => handleDelete(record.id)} okText="Xóa" cancelText="Hủy" okButtonProps={{ danger: true }}>
            <Button type="primary" danger icon={<DeleteOutlined />} size="small" />
          </Popconfirm>
        </Space>
      ),
    },
  ];

  return (
    <div>
      <div style={{ display: 'flex', justifyContent: 'space-between', marginBottom: 20 }}>
        <Title level={3}>Quản lý tin tức</Title>
        <Button type="primary" icon={<PlusOutlined />} onClick={handleOpenAdd}>
          Viết bài mới
        </Button>
      </div>

      <Card>
        <Table columns={columns} dataSource={blogs} rowKey="id" loading={loading} pagination={{ pageSize: 6 }} />
      </Card>

      {/* --- MODAL THÊM / SỬA --- */}
      <Modal
        title={editingBlog ? "Chỉnh sửa bài viết" : "Soạn bài viết mới"}
        open={isModalOpen}
        onCancel={() => setIsModalOpen(false)}
        footer={null}
      >
        <Form form={form} layout="vertical" onFinish={handleSave}>
          <Form.Item name="title" label="Tiêu đề" rules={[{ required: true, message: 'Nhập tiêu đề!' }]}>
            <Input />
          </Form.Item>

          <Form.Item name="content" label="Nội dung" rules={[{ required: true, message: 'Nhập nội dung!' }]}>
            <TextArea rows={6} />
          </Form.Item>
          
          <Form.Item name="imageUrl" label="Link ảnh minh họa">
            <Input />
          </Form.Item>

          <Form.Item name="author" label="Tác giả" initialValue="Admin">
            <Input />
          </Form.Item>

          <div style={{ textAlign: 'right' }}>
            <Space>
              <Button onClick={() => setIsModalOpen(false)}>Hủy</Button>
              <Button type="primary" htmlType="submit">
                {editingBlog ? "Lưu thay đổi" : "Đăng bài"}
              </Button>
            </Space>
          </div>
        </Form>
      </Modal>

      {/* --- MODAL XEM CHI TIẾT --- */}
      <Modal
        title={viewContent?.title}
        open={viewModalOpen}
        onCancel={() => setViewModalOpen(false)}
        footer={[<Button key="close" onClick={() => setViewModalOpen(false)}>Đóng</Button>]}
      >
        <p><b>Tác giả:</b> {viewContent?.author} - <b>Ngày:</b> {new Date(viewContent?.createdAt).toLocaleDateString('vi-VN')}</p>
        <hr style={{border: '0.5px solid #eee', margin: '10px 0'}}/>
        <div style={{ whiteSpace: 'pre-line' }}>{viewContent?.content}</div>
      </Modal>
    </div>
  );
};

export default BlogPage;