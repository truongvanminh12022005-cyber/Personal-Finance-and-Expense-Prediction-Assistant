# Giai đoạn 1: Build code React
FROM node:18-alpine as build
WORKDIR /app
COPY package*.json ./
RUN npm install
COPY . .
RUN npm run build

# Giai đoạn 2: Dùng Nginx để chạy Web (Nhẹ và nhanh)
FROM nginx:alpine
# Copy code đã build ở trên vào thư mục của Nginx
COPY --from=build /app/dist /usr/share/nginx/html
# (Lưu ý: Nếu dự án bạn dùng Create-React-App cũ thì sửa 'dist' thành 'build')

EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]