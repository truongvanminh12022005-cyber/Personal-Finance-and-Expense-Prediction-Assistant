import React, { useEffect, useState } from 'react';
import { Card, Button, Modal, Form, Input, InputNumber, message, Switch, Tag } from 'antd';
import { EditOutlined, CheckCircleOutlined, CrownFilled } from '@ant-design/icons';
import subscriptionApi from '../../api/subscriptionApi';

const { Meta } = Card;

const SubscriptionPage = () => {
  const [plans, setPlans] = useState([]);
  const [loading, setLoading] = useState(false);
  const [isModalOpen, setIsModalOpen] = useState(false);
  const [editingPlan, setEditingPlan] = useState(null);
  const [form] = Form.useForm();

  const fetchPlans = async () => {
    setLoading(true);
    try {
      const res = await subscriptionApi.getAll();
      setPlans(res);
    } catch (error) {
      console.log("Chưa có API Subscriptions");
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    fetchPlans();
  }, []);

  const handleEdit = (plan) => {
    setEditingPlan(plan);
    form.setFieldsValue(plan);
    setIsModalOpen(true);
  };

  const handleSave = async (values) => {
    try {
      await subscriptionApi.update(editingPlan.id, { ...editingPlan, ...values });
      message.success("Đã cập nhật!");
      setIsModalOpen(false);
      fetchPlans();
    } catch (error) {
      message.error("Lỗi khi lưu!");
    }
  };

  return (
    <div>
      <h2 style={{ marginBottom: 20 }}>👑 Quản lý Gói cước (Premium)</h2>

      <div style={{ display: 'flex', gap: '20px', flexWrap: 'wrap' }}>
        {plans.length > 0 ? plans.map(plan => (
          <Card
            key={plan.id}
            style={{ width: 350, borderColor: plan.isActive ? '#1890ff' : '#d9d9d9', borderTop: plan.isActive ? '3px solid #1890ff' : '1px solid #d9d9d9' }}
            actions={[
              <Button type="link" icon={<EditOutlined />} onClick={() => handleEdit(plan)}>Chỉnh sửa giá</Button>
            ]}
          >
            <Meta
              avatar={<CrownFilled style={{ fontSize: 30, color: '#faad14' }} />}
              title={<span style={{ fontSize: 20 }}>{plan.name}</span>}
              description={
                <div>
                  <h3 style={{ color: '#52c41a', margin: '10px 0' }}>
                    {plan.price.toLocaleString('vi-VN')} đ / {plan.durationInDays} ngày
                  </h3>
                  <div style={{ marginTop: 10 }}>
                    {plan.description && plan.description.split(';').map((feature, idx) => (
                      <div key={idx} style={{ marginBottom: 5 }}>
                        <CheckCircleOutlined style={{ color: '#1890ff', marginRight: 8 }} />
                        {feature}
                      </div>
                    ))}
                  </div>
                  <div style={{ marginTop: 15 }}>
                     {plan.isActive ? <Tag color="green">Đang bán</Tag> : <Tag color="red">Ngừng bán</Tag>}
                  </div>
                </div>
              }
            />
          </Card>
        )) : <p>Chưa có dữ liệu gói cước (Hãy kiểm tra Backend)</p>}
      </div>

      <Modal
        title={`Chỉnh sửa: ${editingPlan?.name}`}
        open={isModalOpen}
        onCancel={() => setIsModalOpen(false)}
        footer={null}
      >
        <Form form={form} layout="vertical" onFinish={handleSave}>
          <Form.Item name="name" label="Tên gói" rules={[{ required: true }]}>
            <Input />
          </Form.Item>
          <Form.Item name="price" label="Giá tiền (VND)" rules={[{ required: true }]}>
            <InputNumber style={{ width: '100%' }} formatter={value => `${value}`.replace(/\B(?=(\d{3})+(?!\d))/g, ',')} parser={value => value.replace(/\$\s?|(,*)/g, '')} />
          </Form.Item>
          <Form.Item name="description" label="Mô tả quyền lợi (ngăn cách bằng dấu chấm phẩy ;)">
            <Input.TextArea rows={4} />
          </Form.Item>
          <Form.Item name="isActive" label="Trạng thái" valuePropName="checked">
            <Switch checkedChildren="Đang bán" unCheckedChildren="Ngừng bán" />
          </Form.Item>
          <div style={{ textAlign: 'right' }}>
            <Button onClick={() => setIsModalOpen(false)} style={{ marginRight: 10 }}>Hủy</Button>
            <Button type="primary" htmlType="submit">Lưu thay đổi</Button>
          </div>
        </Form>
      </Modal>
    </div>
  );
};

export default SubscriptionPage;