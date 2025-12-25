import axiosClient from "./axiosClient";

const authApi = {
  login(data) {
   
    return axiosClient.post('/Auth/login', data);
  },
  
};

export default authApi;