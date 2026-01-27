import axiosClient from "./axiosClient";

const adsApi = {
  getAll: () => axiosClient.get('/Advertisements'),
  create: (data) => axiosClient.post('/Advertisements', data),
  update: (id, data) => axiosClient.put(`/Advertisements/${id}`, data),
  delete: (id) => axiosClient.delete(`/Advertisements/${id}`),
};

export default adsApi;