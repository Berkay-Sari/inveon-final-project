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
API Dökümantasyonu Postman Collection olarak sağlanmıştır.
```
