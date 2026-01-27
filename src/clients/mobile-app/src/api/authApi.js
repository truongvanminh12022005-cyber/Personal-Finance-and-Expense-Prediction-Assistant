import axiosClient from './axiosClient';

const authApi = {
  login: (params) => {
    return axiosClient.post('/Auth/login', params);
  },
  register: (params) => {
    return axiosClient.post('/Auth/register', params);
  },
  // Thêm cái này:
  forgotPassword: (email) => {
    // API này tùy thuộc backend bạn đặt tên là gì, thường là /Auth/forgot-password
    return axiosClient.post('/Auth/forgot-password', { email: email });
  }
};

export default authApi;