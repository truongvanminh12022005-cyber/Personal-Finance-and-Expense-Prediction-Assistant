import React, { useEffect, useState } from 'react';
import { Card, Form, Switch, InputNumber, Button, message, Divider, Alert, Spin } from 'antd';
import { SaveOutlined, ToolOutlined } from '@ant-design/icons';
import settingsApi from '../../api/settingsApi';

const SettingsPage = () => {
  const [settings, setSettings] = useState([]);
  const [loading, setLoading] = useState(false);
  const [form] = Form.useForm();

  // Load dữ liệu
  const fetchSettings = async () => {
    setLoading(true);
    try {
      const res = await settingsApi.getAll();
      setSettings(res);
      // Chuyển mảng setting thành object để fill vào form
      const formData = {};
      res.forEach(s => {
        // Nếu value là "true"/"false" thì chuyển thành boolean, còn lại giữ nguyên
        formData[s.key] = s.value === 'true' ? true : s.value === 'false' ? false : s.value;
      });
      form.setFieldsValue(formData);
    } catch (error) {
      console.error(error);
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    fetchSettings();
  }, []);

  // Lưu cấu hình
  const handleSave = async (values) => {
    try {
      // Chuyển lại dữ liệu form thành mảng để gửi về Server
      const updates = Object.keys(values).map(key => ({
        key: key,
        value: String(values[key]) // Chuyển tất cả về chuỗi
      }));

      await settingsApi.update(updates);
      message.success("Cấu hình hệ thống đã được cập nhật!");
    } catch (error) {
      message.error("Lỗi khi lưu cấu hình!");
    }
  };

  if (loading) return <Spin size="large" style={{ display: 'block', margin: '50px auto' }} />;

  return (
    <div style={{ maxWidth: 800, margin: '0 auto' }}>
      <h2 style={{ marginBottom: 20 }}>⚙️ Cấu hình hệ thống</h2>

      <Alert
        message="Lưu ý quan trọng"
        description="Thay đổi ở đây sẽ ảnh hưởng trực tiếp đến toàn bộ người dùng App Mobile. Hãy cẩn trọng!"
        type="warning"
        showIcon
        style={{ marginBottom: 24 }}
      />

      <Form form={form} layout="vertical" onFinish={handleSave}>
        <Card title="🔧 Trạng thái Server" bordered={false} style={{ marginBottom: 20 }}>
          <Form.Item name="IS_MAINTENANCE" label="Chế độ Bảo trì (Tạm khóa App)" valuePropName="checked">
             <Switch checkedChildren="ĐANG BẢO TRÌ" unCheckedChildren="Hoạt động bình thường" />
          </Form.Item>
        </Card>

        <Card title="💰 Quy tắc Tài chính & Tính năng" bordered={false} style={{ marginBottom: 20 }}>
          <div style={{ display: 'flex', gap: 20 }}>
            <Form.Item name="WARNING_THRESHOLD" label="Ngưỡng cảnh báo chi tiêu (%)" style={{ flex: 1 }}>
              <InputNumber min={1} max={100} addonAfter="%" style={{ width: '100%' }} />
            </Form.Item>
            <Form.Item name="OCR_LIMIT_DAILY" label="Giới hạn quét OCR miễn phí / ngày" style={{ flex: 1 }}>
              <InputNumber min={0} addonAfter="lượt" style={{ width: '100%' }} />
            </Form.Item>
          </div>
          <Form.Item name="MAX_UPLOAD_SIZE" label="Dung lượng ảnh tối đa cho phép">
            <InputNumber min={1} addonAfter="MB" style={{ width: '50%' }} />
          </Form.Item>
        </Card>

        <div style={{ textAlign: 'center' }}>
          <Button type="primary" htmlType="submit" icon={<SaveOutlined />} size="large" style={{ minWidth: 200 }}>
            Lưu thay đổi
          </Button>
        </div>
      </Form>
    </div>
  );
};

export default SettingsPage;