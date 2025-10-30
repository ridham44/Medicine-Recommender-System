import axios from "axios";

const api = axios.create({
  baseURL: "http://localhost:5116/api", // 👈 your .NET API base URL
});

export const getMedicineRecommendation = async (inputData) => {
  const response = await api.post("/medicine/recommend", inputData);
  return response.data;
};
