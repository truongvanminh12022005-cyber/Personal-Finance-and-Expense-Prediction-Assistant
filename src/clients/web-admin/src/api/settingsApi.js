import axiosClient from "./axiosClient";

const settingsApi = {
  getAll: () => axiosClient.get('/Settings'),
  update: (data) => axiosClient.put('/Settings', data),
};

export default settingsApi;