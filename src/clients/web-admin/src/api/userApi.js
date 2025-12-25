import axiosClient from "./axiosClient";

const userApi = {
  getAll() {
    return axiosClient.get('/Users'); 
  },
  
  
};

export default userApi;