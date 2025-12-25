import axios from 'axios';

const axiosClient = axios.create({
  baseURL: 'http://localhost:5002/api', 
  headers: {
    'Content-Type': 'application/json',
  },
});

// Trước khi gửi request, tự động lấy Token từ bộ nhớ gắn vào
axiosClient.interceptors.request.use(async (config) => {
  const token = localStorage.getItem('accessToken');
  if (token) {
    config.headers.Authorization = `Bearer ${token}`;
  }
  return config;
});

// Xử lý khi nhận response 
axiosClient.interceptors.response.use(
  (response) => {
    if (response && response.data) {
      return response.data;
    }
    return response;
  },
  (error) => {
    // Nếu lỗi 401 (Hết hạn token) -> Tự động đá ra trang login
    if (error.response && error.response.status === 401) {
      localStorage.removeItem('accessToken');
      window.location.href = '/login';
    }
    throw error;
  }
);

export default axiosClient;