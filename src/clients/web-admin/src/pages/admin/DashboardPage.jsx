
import React, { useEffect, useState } from 'react';
import axios from 'axios';

const DashboardPage = () => {
  // 1. State lưu dữ liệu thật
  const [stats, setStats] = useState({
    totalRevenue: 0,
    newUsersToday: 0,
    pendingOrders: 0,
    recentTransactions: []
  });
  const [loading, setLoading] = useState(true);

  // 2. Gọi API lấy dữ liệu thật
  useEffect(() => {
    const fetchDashboardData = async () => {
      try {
        console.log("Đang gọi API Dashboard...");
        // Gọi API Backend (Port 5002)
        const response = await axios.get('http://localhost:5002/api/Admin/dashboard-stats');

        console.log("Dữ liệu nhận được:", response.data);
        setStats(response.data);
      } catch (error) {
        console.error("Lỗi lấy dữ liệu:", error);
      } finally {
        setLoading(false);
      }
    };

    fetchDashboardData();
  }, []);

  if (loading) return <div style={{padding: 20}}>Đang tải dữ liệu từ Server...</div>;

  return (
    <div className="dashboard-container" style={{ padding: '20px' }}>
      {/* 👇 DẤU HIỆU NHẬN BIẾT CODE MỚI 👇 */}
      <h2 style={{ marginBottom: '20px', color: 'red' }}>📊 TỔNG QUAN HỆ THỐNG (REAL-TIME)</h2>

      {/* --- PHẦN THỐNG KÊ (CARDS) --- */}
      <div style={{ display: 'flex', gap: '20px', marginBottom: '30px' }}>

        {/* Card 1: Doanh thu thật */}
        <div className="card" style={styles.card}>
          <h3>Tổng Doanh Thu</h3>
          <p style={styles.number}>
            {stats.totalRevenue.toLocaleString('vi-VN')} đ
          </p>
          <span style={{ color: 'green' }}>↑ Dữ liệu thật từ Backend</span>
        </div>

        {/* Card 2: User mới thật */}
        <div className="card" style={styles.card}>
          <h3>Người dùng mới</h3>
          <p style={styles.number} >{stats.newUsersToday}</p>
          <span>người dùng hôm nay</span>
        </div>

        {/* Card 3: Đơn chờ thật */}
        <div className="card" style={styles.card}>
          <h3>Đơn hàng chờ xử lý</h3>
          <p style={styles.number} >{stats.pendingOrders}</p>
          <span style={{ color: 'red' }}>Cần xử lý gấp</span>
        </div>
      </div>

      {/* --- BẢNG GIAO DỊCH (TABLE) --- */}
      <div className="recent-transactions" style={styles.tableContainer}>
        <h3>Giao dịch gần đây</h3>
        <table style={{ width: '100%', borderCollapse: 'collapse', marginTop: '10px' }}>
          <thead>
            <tr style={{ textAlign: 'left', borderBottom: '1px solid #ddd' }}>
              <th style={{ padding: '10px' }}>Người dùng</th>
              <th>Số tiền</th>
              <th>Ngày giao dịch</th>
              <th>Trạng thái</th>
            </tr>
          </thead>
          <tbody>
            {stats.recentTransactions.length > 0 ? (
              stats.recentTransactions.map((item, index) => (
                <tr key={index} style={{ borderBottom: '1px solid #eee' }}>
                  <td style={{ padding: '10px' }}>{item.userName}</td>
                  <td style={{ fontWeight: 'bold' }}>{item.amount.toLocaleString('vi-VN')} đ</td>
                  <td>{new Date(item.date).toLocaleDateString('vi-VN')}</td>
                  <td>
                    <span style={{
                      padding: '5px 10px',
                      borderRadius: '15px',
                      fontSize: '12px',
                      backgroundColor: item.status === 'Success' || item.status === 'Thành công' ? '#e6fffa' : '#fff5f5',
                      color: item.status === 'Success' || item.status === 'Thành công' ? '#38b2ac' : '#e53e3e'
                    }}>
                      {item.status}
                    </span>
                  </td>
                </tr>
              ))
            ) : (
              <tr><td colSpan="4" style={{padding: 20, textAlign: 'center'}}>Chưa có giao dịch nào</td></tr>
            )}
          </tbody>
        </table>
      </div>
    </div>
  );
};

// CSS nội bộ nhanh gọn
const styles = {
  card: {
    flex: 1,
    padding: '20px',
    backgroundColor: '#fff',
    borderRadius: '8px',
    boxShadow: '0 2px 5px rgba(0,0,0,0.1)'
  },
  number: {
    fontSize: '28px',
    fontWeight: 'bold',
    margin: '10px 0',
    color: '#2c3e50'
  },
  tableContainer: {
    padding: '20px',
    backgroundColor: '#fff',
    borderRadius: '8px',
    boxShadow: '0 2px 5px rgba(0,0,0,0.1)'
  }
};

export default DashboardPage;