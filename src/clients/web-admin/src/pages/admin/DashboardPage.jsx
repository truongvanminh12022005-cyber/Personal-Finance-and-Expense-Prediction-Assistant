import React from 'react';
import { Card, Col, Row, Statistic, Table, Tag } from 'antd';
import { ArrowUpOutlined, ArrowDownOutlined, UserOutlined, DollarOutlined, ShoppingCartOutlined } from '@ant-design/icons';

const DashboardPage = () => {
  // Dữ liệu giả lập cho bảng "Giao dịch gần đây"
  const recentData = [
    { key: '1', user: 'Nguyễn Văn A', amount: '500.000 đ', status: 'completed', date: '2025-01-17' },
    { key: '2', user: 'Trần Thị B', amount: '1.200.000 đ', status: 'pending', date: '2025-01-16' },
    { key: '3', user: 'Lê Văn C', amount: '250.000 đ', status: 'failed', date: '2025-01-16' },
  ];

  const columns = [
    { title: 'Người dùng', dataIndex: 'user', key: 'user' },
    { title: 'Số tiền', dataIndex: 'amount', key: 'amount' },
    { title: 'Ngày giao dịch', dataIndex: 'date', key: 'date' },
    {
      title: 'Trạng thái',
      dataIndex: 'status',
      key: 'status',
      render: (status) => {
        let color = status === 'completed' ? 'green' : status === 'pending' ? 'gold' : 'red';
        let text = status === 'completed' ? 'Thành công' : status === 'pending' ? 'Chờ xử lý' : 'Thất bại';
        return <Tag color={color}>{text}</Tag>;
      },
    },
  ];

  return (
    <div>
      <h2 style={{ marginBottom: 20 }}>📊 Tổng quan hệ thống</h2>
      
      {/* Hàng thống kê số liệu */}
      <Row gutter={16}>
        <Col span={8}>
          <Card bordered={false}>
            <Statistic
              title="Tổng Doanh Thu"
              value={112893000}
              precision={0}
              valueStyle={{ color: '#3f8600' }}
              prefix={<DollarOutlined />}
              suffix="₫"
            />
            <div style={{ marginTop: 8, color: 'gray' }}>
              <ArrowUpOutlined style={{ color: 'green' }} /> Tăng 12% so với tháng trước
            </div>
          </Card>
        </Col>
        <Col span={8}>
          <Card bordered={false}>
            <Statistic
              title="Người dùng mới"
              value={93}
              valueStyle={{ color: '#1890ff' }}
              prefix={<UserOutlined />}
            />
            <div style={{ marginTop: 8, color: 'gray' }}>
              <ArrowUpOutlined style={{ color: 'green' }} /> Tăng 5 user hôm nay
            </div>
          </Card>
        </Col>
        <Col span={8}>
          <Card bordered={false}>
            <Statistic
              title="Đơn hàng chờ xử lý"
              value={5}
              valueStyle={{ color: '#cf1322' }}
              prefix={<ShoppingCartOutlined />}
            />
            <div style={{ marginTop: 8, color: 'gray' }}>
              <ArrowDownOutlined style={{ color: 'red' }} /> Cần xử lý gấp
            </div>
          </Card>
        </Col>
      </Row>

      {/* Bảng dữ liệu gần đây */}
      <div style={{ marginTop: 24 }}>
        <h3>Giao dịch gần đây</h3>
        <Table columns={columns} dataSource={recentData} pagination={false} style={{ background: 'white', padding: 10, borderRadius: 8 }} />
      </div>
    </div>
  );
};

export default DashboardPage;