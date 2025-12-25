import axiosClient from "./axiosClient";

const blogApi = {
  getAll() {
    return axiosClient.get('/Blogs');
  },
  create(data) {
    return axiosClient.post('/Blogs', data);
  },
update(id, data) {
    return axiosClient.put(`/Blogs/${id}`, data);
  },

  delete(id) {
    return axiosClient.delete(`/Blogs/${id}`);
  }
};

export default blogApi;