import axiosClient from "./axiosClient";

const userApi = {
  getAll() {
    return axiosClient.get('/Users');
  },
  create(data) {
    return axiosClient.post('/Users', data);
  },
  update(id, data) {
    return axiosClient.put(`/Users/${id}`, data);
  },
  delete(id) {
    return axiosClient.delete(`/Users/${id}`);
  }
};

export default userApi;