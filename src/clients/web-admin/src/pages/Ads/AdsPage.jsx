import React, { useEffect, useState } from 'react';
import { Table, Button, Modal, Form, Input, DatePicker, Switch, InputNumber, message, Card, Image, Tag, Space, Popconfirm } from 'antd';
import { PlusOutlined, EditOutlined, DeleteOutlined, DollarOutlined } from '@ant-design/icons';
import dayjs from 'dayjs';
import adsApi from '../../api/adsApi';

const AdsPage = () => {
  const [ads, setAds] = useState([]);
  const [loading, setLoading] = useState(false);
  const [isModalOpen, setIsModalOpen] = useState(false);
  const [editingAd, setEditingAd] = useState(null);
  const [form] = Form.useForm();

  // Load dữ liệu
  const fetchAds = async () => {
    setLoading(true);
    try {
      const res = await adsApi.getAll();
      setAds(res);
    } catch (error) {
      console.log("Chưa có API Ads hoặc lỗi mạng");
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    fetchAds();
  }, []);

  // Mở Modal
  const handleOpenModal = (record = null) => {
    setEditingAd(record);
    if (record) {
      form.setFieldsValue({
        ...record,
        dateRange: [dayjs(record.startDate), dayjs(record.endDate)]
      });
    } else {
      form.resetFields();
    }
    setIsModalOpen(true);
  };

  // Lưu
  const handleSave = async (values) => {
    try {
      const payload = {
        ...values,
        startDate: values.dateRange[0].toISOString(),
        endDate: values.dateRange[1].toISOString(),
        isActive: values.isActive === undefined ? true : values.isActive
      };
      delete payload.dateRange;

      if (editingAd) {
        await adsApi.update(editingAd.id, { ...payload, id: editingAd.id });
        message.success("Cập nhật thành công!");
      } else {
        await adsApi.create(payload);
        message.success("Tạo quảng cáo mới thành công!");
      }
      setIsModalOpen(false);
      fetchAds();
    } catch (error) {
      // Log lỗi ra console để xem chi tiết
      console.error(error);
      message.error("Lỗi khi lưu! Kiểm tra lại Backend.");
    }
  };

  // Xóa
  const handleDelete = async (id) => {
    try {
      await adsApi.delete(id);
      message.success("Đã xóa!");
      fetchAds();
    } catch (error) {
      message.error("Xóa thất bại!");
    }
  };

  const columns = [
    {
      title: 'Banner',
      dataIndex: 'imageUrl',
      key: 'imageUrl',
      render: (url) => <Image width={100} height={50} src={url} style={{objectFit: 'cover', borderRadius: 4}} fallback="https://via.placeholder.com/150" />,
    },
    {
      title: 'Chiến dịch / Đối tác',
      key: 'info',
      render: (_, record) => (
        <div>
          <div style={{fontWeight: 'bold'}}>{record.title}</div>
          <div style={{color: '#888'}}>{record.partnerName}</div>
        </div>
      )
    },
    {
      title: 'Thời gian chạy',
      key: 'time',
      render: (_, record) => (
        <div style={{fontSize: 12}}>
          <div>BĐ: {new Date(record.startDate).toLocaleDateString('vi-VN')}</div>
          <div>KT: {new Date(record.endDate).toLocaleDateString('vi-VN')}</div>
        </div>
      )
    },
    {
      title: 'Giá trị HĐ',
      dataIndex: 'contractValue',
      key: 'contractValue',
      render: (val) => <Tag color="gold">{val?.toLocaleString('vi-VN')} đ</Tag>
    },
    {
      title: 'Trạng thái',
      dataIndex: 'isActive',
      key: 'isActive',
      render: (active) => active ? <Tag color="green">Đang chạy</Tag> : <Tag color="red">Đã dừng</Tag>
    },
    {
      title: 'Hành động',
      key: 'action',
      render: (_, record) => (
        <Space>
          <Button icon={<EditOutlined />} onClick={() => handleOpenModal(record)} />
          <Popconfirm title="Xóa quảng cáo này?" onConfirm={() => handleDelete(record.id)} okButtonProps={{danger: true}}>
            <Button danger icon={<DeleteOutlined />} />
          </Popconfirm>
        </Space>
      )
    }
  ];

  return (
    <div>
      <div style={{ display: 'flex', justifyContent: 'space-between', marginBottom: 20 }}>
        <h2>📢 Quản lý Quảng cáo</h2>
        <Button type="primary" icon={<PlusOutlined />} onClick={() => handleOpenModal(null)}>
          Tạo quảng cáo mới
        </Button>
      </div>

      <Card>
        <Table columns={columns} dataSource={ads} rowKey="id" loading={loading} />
      </Card>

      <Modal
        title={editingAd ? "Cập nhật Quảng cáo" : "Tạo Quảng cáo Mới"}
        open={isModalOpen}
        onCancel={() => setIsModalOpen(false)}
        footer={null}
        width={600}
      >
        <Form form={form} layout="vertical" onFinish={handleSave} initialValues={{ isActive: true }}>
          <Form.Item name="title" label="Tên chiến dịch" rules={[{ required: true }]}>
            <Input placeholder="Ví dụ: Banner Tết 2024" />
          </Form.Item>

          <Form.Item name="partnerName" label="Tên đối tác (Partner)" rules={[{ required: true }]}>
            <Input placeholder="Ví dụ: Tiki, Shopee, VNPay..." />
          </Form.Item>

          <div style={{display: 'flex', gap: 20}}>
            <Form.Item name="contractValue" label="Giá trị hợp đồng (VND)" style={{flex: 1}}>
              <InputNumber style={{width: '100%'}} formatter={value => `${value}`.replace(/\B(?=(\d{3})+(?!\d))/g, ',')} parser={value => value.replace(/\$\s?|(,*)/g, '')}/>
            </Form.Item>
             <Form.Item name="isActive" label="Trạng thái" valuePropName="checked" style={{flex: 1}}>
              <Switch checkedChildren="Bật" unCheckedChildren="Tắt" />
            </Form.Item>
          </div>

          <Form.Item name="dateRange" label="Thời gian chạy (Bắt đầu - Kết thúc)" rules={[{ required: true }]}>
            <DatePicker.RangePicker style={{width: '100%'}} format="DD/MM/YYYY" />
          </Form.Item>

          <Form.Item name="imageUrl" label="Link ảnh Banner (URL)" rules={[{ required: true }]}>
            <Input placeholder="https://..." />
          </Form.Item>

          {/* 👇 ĐÃ BỔ SUNG Ô NHẬP NÀY ĐỂ SỬA LỖI 👇 */}
          <Form.Item
            name="targetUrl"
            label="Link đích (Khi bấm vào quảng cáo)"
            rules={[{ required: true, message: 'Vui lòng nhập link đích!' }]}
          >
            <Input placeholder="Ví dụ: https://shopee.vn/san-pham-a" />
          </Form.Item>

          <div style={{ textAlign: 'right', marginTop: 20 }}>
            <Button onClick={() => setIsModalOpen(false)} style={{ marginRight: 10 }}>Hủy</Button>
            <Button type="primary" htmlType="submit" icon={<DollarOutlined />}>
              {editingAd ? "Lưu thay đổi" : "Lên đơn quảng cáo"}
            </Button>
          </div>
        </Form>
      </Modal>
    </div>
  );
};

export default AdsPage;