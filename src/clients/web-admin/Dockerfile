# --- Giai đoạn 1: Build bằng Node.js ---
FROM node:18-alpine as build
WORKDIR /app

# Copy và cài đặt thư viện
COPY package*.json ./
RUN npm install

# Copy toàn bộ code và build
COPY . .
RUN npm run build 
# (Với Vite, lệnh này sẽ tạo ra thư mục 'dist')

# --- Giai đoạn 2: Chạy bằng Nginx ---
FROM nginx:alpine

# 1. Copy file cấu hình Nginx (Để xử lý React Router khi F5)
COPY nginx.conf /etc/nginx/conf.d/default.conf

# 2. Copy code đã build từ thư mục 'dist' (Vite) sang thư mục Web của Nginx
# (SỬA LỖI TẠI ĐÂY: Dùng /app/dist thay vì /app/build)
COPY --from=build /app/dist /usr/share/nginx/html

EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]