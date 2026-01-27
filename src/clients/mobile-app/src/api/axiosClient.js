import axios from 'axios';
import AsyncStorage from '@react-native-async-storage/async-storage';

const axiosClient = axios.create({
  // 👇 QUAN TRỌNG: Kiểm tra lại IP máy tính của bạn (dùng lệnh ipconfig)
  // Nếu IP thay đổi, phải sửa số 156 này thành số mới.
  baseURL: 'http://192.168.100.156:5002/api',
  headers: {
    'Content-Type': 'application/json',
  },
});

// Gắn Token và Log Request
axiosClient.interceptors.request.use(async (config) => {
  const token = await AsyncStorage.getItem('accessToken');
  if (token) {
    config.headers.Authorization = `Bearer ${token}`;
  }

  // In ra Log để bạn biết App đang gọi đi đâu
  console.log(`[MOBILE GỬI API] --> ${config.method.toUpperCase()} ${config.baseURL}${config.url}`);

  return config;
});

// Xử lý kết quả trả về
axiosClient.interceptors.response.use(
  (response) => {
    return response.data ? response.data : response;
  },
  (error) => {
    console.log("[MOBILE LỖI API]:", error.response?.data || error.message);
    throw error;
  }
);

export default axiosClient;