#  CourseMarket 
Onion Architecture yaklaşımı ile kurgulanmış Kurs Satış sitesi
## Getting Started

1. Visual Studio'yu açın.
2. "Clone a repository" seçeneği üzerinden klonlayın.
3. Backend klasörüne girip CourseMarket.API.sln'a çift tıklayın.
4. Tools (Araçlar) > NuGet Package Manager > Package Manager Console: Bu konsolda Default project olarak CourseMarket.Infrastructure seçtikten sonra Update-Database komutunu çalıştırın ve veritabanının oluşmasını bekleyin.
5. Ardından pgAdmin üzerinden CourseMarketAPIDb veritabanına sağ tıklayıp QueryTool pencersini açın. Dosya simgesine tıklayıp seed-data klasörü altında bulunan seed.sql'i seçin ve çalıştırın. Veriler insert edilecektir.
6. (Opsiyonel) Seq ile sistemdeki logları incelemek isterseniz `docker run --name Seq -e ACCEPT_EULA=Y -p 5341:80 datalust/seq:latest` komutu ile Docker'da Seq uygulaması için bir konteyner başlatıp, Seq arayüzüne http://localhost:5341 adresinden erişebilirsiniz. Frontend'de birkaç işlem yaptıktan sonra ya da backend ayağa kalktıktan sonra Seq arayüzndeki logları analiz edebilirsiniz.

## Project Structure

- `Exception Handling`: ConfigureExceptionHandlerExtension üzerinden beklenmeyen veya kritik hatalar (örneğin, bir veritabanı bağlantı hatası) ele alınmıştır. Bunun dışındaki iş kuralları hataları ve beklenen durumlar için ServiceResult.Error üzerinden geri dönüş sağlanmıştır.

- `Logging`: Loglar, `Serilog` kullanılarak hem local text dosyasına hem de veritabanına kaydedilmiştir. Log verilerini görselleştirme ve sistem operasyonlarında, log verilerini merkezi bir yerde analiz etme amacıyla `Seq` aracı kullanılmıştır.

- `File Managment` : Dosyalar Table per Hierarchy (TPH) yapısıyla veritabanında url olarak tutulmuştur. Local Storage dışında ileriye yönelik AWS, Amazon gibi sunucu tabanlı depolama sistemi için mimarisel soyut bir tasarım sergilenmiştir. 

- `Validation` : Backend tarafında FluentValidation kütüphanesi üzerinden Rule tanımlanarak validasyon sağlanırken Frontend tarafında da pure javascript ve regex kullanılarak inputlar valide edilmiştir.

- `Auth` : Kullanıcı yetkilendirme JWT token ile sağlanmıştır. Refresh token kullanıcı tablosuna eklenmiştir. Frontend tarafında axios interceptor ile refresh token kullanarak yeniden access token alma, headere Authorization bilgisi ekleme gibi işlemler gerçekleştirilmiştir.


## Tech Stack

- [.NET 8](https://dotnet.microsoft.com/download/dotnet/8.0)
- [React.js](https://react.dev/)
- [PostgreSQL](https://www.postgresql.org/)
- [Entity Framework Core](https://docs.microsoft.com/ef/core/)

- [Identity](https://docs.microsoft.com/aspnet/core/security/authentication/identity)
- [Mapster](https://github.com/MapsterMapper/Mapster)
- [Bootstrap](https://getbootstrap.com/)

## Note: 
```
API Dökümantasyonu Postman Collection olarak sağlanmıştır. Postman'i açıp sol üst kısımdan import dedikten sonra repodaki collection'ı sürükleyip içeri bırakabilirsiniz.
```
![Architecture](https://github.com/user-attachments/assets/b98f5807-c87a-4dda-8d26-f41110c9166a)

![CourseDetail(not-owned)](https://github.com/user-attachments/assets/5e6189e0-41f5-4283-9d0d-78d840ebf859)
![CourseDetail(owned)](https://github.com/user-attachments/assets/1087262c-97d1-4aad-887a-a63ac33a5ffe)
![Profil](https://github.com/user-attachments/assets/3558b6ae-7156-4da9-91e8-0d1f70893cee)
![Homepage](https://github.com/user-attachments/assets/898cf078-4429-4c4a-8547-8acf10cdf02b)
![Orderhistory](https://github.com/user-attachments/assets/6e9548aa-b371-4e06-add8-0a8d888109ec)
![Login(with-alertify)](https://github.com/user-attachments/assets/ff91f579-41db-43b9-8a90-895d6312735f)
![Register](https://github.com/user-attachments/assets/ca786691-5be1-4fd3-b8dd-63c423838fd4)
![CreateCourse](https://github.com/user-attachments/assets/92b984ee-d025-4757-a03b-ae5a74da6c76)
![Basket-Payment](https://github.com/user-attachments/assets/7eac73bb-4d8c-4702-9377-ad43c54329aa)
![FileManagment](https://github.com/user-attachments/assets/43fe2445-dcf6-4a0e-be51-468a67fbe43c)
