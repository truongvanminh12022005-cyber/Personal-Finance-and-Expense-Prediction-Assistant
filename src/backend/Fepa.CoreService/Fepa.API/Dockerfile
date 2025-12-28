# 1. Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# --- COPY CÁC FILE DỰ ÁN (Để Restore trước) ---
# Copy file csproj của API
COPY ["Fepa.API/Fepa.API.csproj", "Fepa.API/"]
# Copy file csproj của các lớp phụ thuộc (Application, Infrastructure, Domain)
# (Bạn kiểm tra lại tên thư mục thật kỹ nhé, phải khớp 100% với tên folder trong máy bạn)
COPY ["Fepa.Application/Fepa.Application.csproj", "Fepa.Application/"]
COPY ["Fepa.Infrastructure/Fepa.Infrastructure.csproj", "Fepa.Infrastructure/"]
COPY ["Fepa.Domain/Fepa.Domain.csproj", "Fepa.Domain/"]

# Restore (Tải thư viện) cho dự án chính
RUN dotnet restore "Fepa.API/Fepa.API.csproj"

# --- COPY TOÀN BỘ CODE CÒN LẠI ---
COPY . .

# Build dự án
WORKDIR "/src/Fepa.API"
RUN dotnet publish "Fepa.API.csproj" -c Release -o /app/out

# 2. Run
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .

EXPOSE 8080
ENTRYPOINT ["dotnet", "Fepa.API.dll"]