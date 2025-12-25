import axiosClient from "./axiosClient";

const userApi = {
  getAll() {
    return axiosClient.get('/Users'); 
  },
  delete(id) {
    return axiosClient.delete(`/Users/${id}`);
  }

};



export default userApi;