import axiosClient from "./axiosClient";

const subscriptionApi = {
  getAll: () => axiosClient.get('/Subscriptions'),
  update: (id, data) => axiosClient.put(`/Subscriptions/${id}`, data),
};

export default subscriptionApi;