# KayraExport.Task 2 - UserProductApi

[Click here for the English version of this document.](./README.EN.md)

Bu proje, KayraExport için geliştirdiğim **User ve Product yönetim API** uygulamasıdır. Junior seviyede backend geliştirici olarak geliştirdiğim bu projede temel CRUD operasyonları, kullanıcı yönetimi ve authentication işlemlerini gerçekleştirdim.  

Projenin amacı, kullanıcı ve ürün yönetimi işlemlerini bir API üzerinden sağlamaktır.  

---

## Özellikler ve Yapılanlar

### 1. **User ve Product CRUD**
- `UserService` ve `ProductService` üzerinden temel CRUD işlemleri gerçekleştirildi.
- Veritabanı işlemleri için **UnitOfWork + Repository Pattern** kullanıldı.
- Kullanıcı ve ürünleri ekleme, silme, güncelleme ve listeleme fonksiyonları mevcut.

### 2. **Authentication / JWT**
- Kullanıcı giriş işlemleri için **JWT tabanlı authentication** implement edildi.
- Şifreler **BCrypt ile hashlenerek** veritabanına kaydedildi.
- Token süresi, issuer ve audience gibi bilgiler **appsettings.json** üzerinden konfigüre edildi.
- Önceki projelerimde (CinemaApi) JWT ve Redis internetten araştırılarak kullanılmıştı; ancak kendimi junior seviyesinde gördüğüm ve projeyi kendi başıma yapmak istediğim için **JWT'yi araştırmamla ve çeşitli kaynaklardan yardım alarak ekledim**, Redis cache’i eklemedim.

### 3. **DTO ve AutoMapper**
- Veri transferi için DTO'lar oluşturuldu: `UserDto`, `ProductDto`, `AuthResponseDto`, `RegisterUserDto`, `LoginUserDto`, `CreateProductDto`, `UpdateProductDto`, `ProductDetailDto`.
- **AutoMapper** ile entity ve DTO dönüşümleri sağlandı.

### 4. **Validation / FluentValidation**
- DTO’lar için **FluentValidation** kullanıldı:
  - `CreateProductDtoValidator`
  - `UpdateProductDtoValidator`
  - `RegisterUserDtoValidator`
  - `LoginUserDtoValidator`
- Gerekli alanların kontrolü (örn. Name, Email, Password, Stock, Description) yapıldı.
- Validation hataları **Global Exception Middleware** ile JSON formatında kullanıcıya döndürülüyor.

### 5. **Global Exception Handling**
- Tüm API için **ExceptionMiddleware** oluşturuldu.
- `NotFoundException` ve diğer genel hatalar merkezi olarak yakalanıyor.
- FluentValidation hataları da middleware aracılığıyla döndürülüyor.

### 6. **API Versioning**
- Endpoint versiyonlaması eklendi (`v1`) ve URL segmentleri ile çağrılabiliyor.
- Örnek: `/api/v1/products`

### 7. **Swagger**
- Swagger UI projeye eklenildi, dokümantasyon süre kısıtından dolayı oluşturulmadı.

---

## Proje Durumu ve Açıklamalar

- Bu proje, **junior seviye backend geliştirme** için tasarlanmıştır ve temel özellikler tamamlanmıştır.
- JWT Authentication sistemi **internetteki kaynaklar ve örnekler üzerinden araştırılarak** projeye eklenmiştir. Daha önceki projelerimde (CinemaApi) JWT ve Redis kullanılmış olsa da, o projede çok fazla yardım alınmıştı. Bu projede kendi araştırmam ve uygulamam ile JWT entegre edilmiştir.
- **Redis, CQRS ve MediatR** gibi ileri seviye konular bu projede **henüz eklenmemiştir**, çünkü bu konular mevcut seviyemin üstünde ve junior seviye için zorunlu değildir.
- Projede aşağıdaki ana özellikler tamamlanmıştır:
  - User, Product ve Auth controllerları
  - UnitOfWork ve Service katmanları
  - AutoMapper ile DTO mapping
  - Global Exception Middleware
  - NotFoundException handling
  - API Versioning
  - FluentValidation ile DTO validasyonları
  - JWT Authentication
- Bu proje, **junior seviye bir backend geliştirici olarak gerekli temel kavramların uygulanması ve test edilmesi** amacıyla hazırlanmıştır. İleri seviye konular (Redis, CQRS, MediatR) ileride eklenebilir.

---

## Yapılmayan / İleri Seviye Konular
- **Redis Cache** eklenmedi (Junior seviyemde ve proje gereksinimi dışında).  
- **CQRS / MediatR** patternleri henüz uygulanmadı.  
- Unit Test veya Integration Test yazılmadı.  

---

## Kurulum
1. Projeyi klonlayın:  
```bash
git clone https://github.com/KadirAkyaman/KayraExport.Task2
```

2. Veritabanı oluşturun:
- PostgreSQL üzerinde yeni bir veritabanı oluşturun.
- appsettings.json içindeki DefaultConnection bağlantı stringini kendi veritabanınıza göre güncelleyin.

3. Migration’ları uygulayın
```bash
dotnet ef database update
```

4. Projeyi çalıştırın
```bash
dotnet run --project src/KayraExport.Api/KayraExport.Api.csproj
```