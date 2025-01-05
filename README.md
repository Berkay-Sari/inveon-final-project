# CourseMarket

Onion Architecture yaklaşımı ile kurgulanmış bir Kurs Satış Platformu. 

## 🚀 Başlarken

Projenizi çalıştırmak için aşağıdaki adımları takip edebilirsiniz:

1. **Visual Studio**'yu açın.
2. **"Clone a repository"** seçeneği üzerinden projeyi klonlayın.
3. **Backend** klasörüne gidin ve `CourseMarket.API.sln` dosyasını çift tıklayarak açın.
4. **NuGet Package Manager Console**'u açın:
   - Menüden **Tools (Araçlar) > NuGet Package Manager > Package Manager Console** yolunu izleyin.
   - Default project olarak `CourseMarket.Infrastructure` seçin ve ardından `Update-Database` komutunu çalıştırarak veritabanını oluşturun.
5. **Seed Data**:
   - **pgAdmin**'i açın ve `CourseMarketAPIDb` veritabanına sağ tıklayarak **Query Tool**'u seçin.
   - Query Tool penceresinde dosya simgesine tıklayın, **seed-data** klasörü altındaki `seed.sql` dosyasını seçin ve çalıştırın. Veriler veritabanına yüklenecektir.
6. (Opsiyonel) **Seq ile Log Analizi**:
   - Seq'i kullanmak için aşağıdaki komutu Docker üzerinde çalıştırın:
     ```bash
     docker run --name Seq -e ACCEPT_EULA=Y -p 5341:80 datalust/seq:latest
     ```
   - Seq arayüzüne `http://localhost:5341` adresinden erişebilirsiniz. Backend çalışmaya başladıktan sonra veya Frontend'de bazı işlemleri gerçekleştirdikten sonra logları analiz edebilirsiniz.

---

## 📂 Proje Yapısı

- **Exception Handling**: 
  - Beklenmeyen veya kritik hatalar için `ConfigureExceptionHandlerExtension` kullanılmıştır.
  - İş kuralları hataları ve tahmin edilebilir durumlar için `ServiceResult.Error` mekanizması kullanılmıştır.

- **Logging**: 
  - Loglar, `Serilog` ile hem lokal text dosyasına hem de veritabanına kaydedilmektedir.
  - Logların görselleştirilmesi ve analizi için `Seq` aracı entegre edilmiştir.

- **File Management**: 
  - Dosyalar, veritabanında **Table Per Hierarchy (TPH)** yapısı ile URL olarak saklanmaktadır.
  - Gelecekte AWS veya diğer bulut tabanlı depolama sistemlerine geçiş için mimaride soyutlama yapılmıştır.

- **Validation**: 
  - Backend'de `FluentValidation` ile validasyon sağlanmıştır.
  - Frontend tarafında `Pure JavaScript` ve `Regex` kullanılarak input doğrulama yapılmıştır.

- **Authentication**: 
  - Kullanıcı yetkilendirme `JWT Token` ile sağlanmıştır.
  - `Refresh Token` kullanıcı tablosuna eklenmiştir.
  - Frontend'de `Axios Interceptor` ile token yenileme ve `Authorization` header'ı ekleme işlemleri gerçekleştirilmiştir.

---

## 🛠️ Kullanılan Teknolojiler

- [.NET 8](https://dotnet.microsoft.com/download/dotnet/8.0)
- [React.js](https://react.dev/)
- [PostgreSQL](https://www.postgresql.org/)
- [Entity Framework Core](https://docs.microsoft.com/ef/core)
- [Identity](https://docs.microsoft.com/aspnet/core/security/authentication/identity)
- [Mapster](https://github.com/MapsterMapper/Mapster)
- [Bootstrap](https://getbootstrap.com/)

---

## 📜 API Dökümantasyonu

API dökümantasyonu bir **Postman Collection** olarak sağlanmıştır. Aşağıdaki adımları takip ederek API'yi kolayca test edebilirsiniz:
1. **Postman**'i açın.
2. Sol üst köşeden **Import** butonuna tıklayın.
3. Repository'deki collection dosyasını sürükleyip bırakın.

---

## 📸 Görseller

| **Homepage** | **Kurs Detayı (Sahip Değil)** | **Kurs Detayı (Sahip)** |
|--------------|--------------------------------|--------------------------|
| ![Homepage](https://github.com/user-attachments/assets/898cf078-4429-4c4a-8547-8acf10cdf02b) | ![CourseDetail(not-owned)](https://github.com/user-attachments/assets/5e6189e0-41f5-4283-9d0d-78d840ebf859) | ![CourseDetail(owned)](https://github.com/user-attachments/assets/1087262c-97d1-4aad-887a-a63ac33a5ffe) |

| **Profil** | **Sipariş Geçmişi** |
|------------|----------------------|
| ![Profil](https://github.com/user-attachments/assets/3558b6ae-7156-4da9-91e8-0d1f70893cee) | ![Orderhistory](https://github.com/user-attachments/assets/6e9548aa-b371-4e06-add8-0a8d888109ec) |

| **Login (Alertify ile)** | **Register** |
|---------------------------|--------------|
| ![Login(with-alertify)](https://github.com/user-attachments/assets/ff91f579-41db-43b9-8a90-895d6312735f) | ![Register](https://github.com/user-attachments/assets/ca786691-5be1-4fd3-b8dd-63c423838fd4) |

| **Kurs Oluşturma** | **Sepet ve Ödeme** |
|---------------------|--------------------|
| ![CreateCourse](https://github.com/user-attachments/assets/92b984ee-d025-4757-a03b-ae5a74da6c76) | ![Basket-Payment](https://github.com/user-attachments/assets/7eac73bb-4d8c-4702-9377-ad43c54329aa) |

| **Dosya Yönetimi** |
|--------------------|
| ![FileManagment](https://github.com/user-attachments/assets/43fe2445-dcf6-4a0e-be51-468a67fbe43c) |

---
