# Tích Hợp API Tỷ Giá Hối Đoái Đông Á vào ASP.NET Core

##  Mô tả
Dự án này hướng dẫn cách nhúng **API Tỷ Giá Hối Đoái từ Ngân Hàng Đông Á** vào website riêng của bạn, sử dụng nền tảng **ASP.NET Core MVC**. Dữ liệu được lấy theo định dạng **JSON**, sau đó parse sang **C# class** và hiển thị trên giao diện web.

---

##  Công nghệ sử dụng
- ASP.NET Core MVC
- Newtonsoft.Json
- HttpClient

---

##  Cách hoạt động
1. Gửi HTTP GET request đến API của Đông Á.
2. Nhận dữ liệu JSON trả về.
3. Deserialize JSON thành đối tượng C#.
4. Render dữ liệu ra giao diện.

---
