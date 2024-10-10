

# E-Commerce Web Application
![E-Commerce Web Application](https://github.com/farunurisonmez/ECommerce-ElasticSearch-DotNet/blob/dev/v1.0.0/Assets/ECommerceWEB.PNG)

Bu proje, bir e-ticaret web uygulaması geliştirmek için tasarlanmıştır. Proje, ürünlerin aranabilirliği, kullanıcı arayüzü ve veri yönetimi üzerine odaklanmaktadır.

## Kullanılan Teknolojiler

- **ASP.NET Core**: Projenin temelini oluşturan framework. ASP.NET Core 7.0 kullanılmaktadır.
- **Entity Framework Core**: Veri erişimi katmanı için ORM (Object-Relational Mapping) olarak kullanılır.
- **Elasticsearch**: Gelişmiş arama işlevselliği sağlamak için kullanılır. Verilerin hızlı ve etkili bir şekilde aranabilmesini sağlar.
- **MVC (Model-View-Controller) Design Pattern**: Proje, uygulama mantığını, kullanıcı arayüzünü ve verileri birbirinden ayırmak için MVC desenini kullanmaktadır.

## Proje Yapısı

- **Controllers**: Kullanıcı isteklerini işlemek için controller sınıflarını içerir. Örneğin, `ECommerceController` sınıfı, e-ticaret ile ilgili arama işlemlerini yönetir.
- **Models**: Uygulamanın veri modellerini tanımlar. `ECommerceModel` ve `Product` gibi sınıflar, veritabanı ile etkileşime girmek için kullanılır.
- **ViewModels**: Görüntüleme katmanı için verilerin taşınmasını sağlar. `ECommerceViewModel` ve `SearchPageViewModel`, kullanıcı arayüzüne gerekli bilgileri sunmak için tasarlanmıştır.
- **Services**: Uygulamanın iş mantığını içerir. `ECommerceService`, verileri almak ve işlemek için repository sınıflarını kullanır.
- **Repositories**: Veritabanı etkileşimlerini yöneten sınıfları içerir. `ECommerceRepository`, Elasticsearch ile iletişim kurarak arama sorgularını yönetir.

## Kurulum

### Gereksinimler

- [.NET SDK 7.0](https://dotnet.microsoft.com/download)
- [Elasticsearch](https://www.elastic.co/downloads/elasticsearch)

### Adımlar

1. Projeyi klonlayın:
   ```bash
   git clone <repository-url>
   cd <project-directory>
   ```

2. Gerekli NuGet paketlerini yükleyin:
   ```bash
   dotnet restore
   ```

3. Elasticsearch'u başlatın.

4. Uygulamayı çalıştırın:
   ```bash
   dotnet run
   ```

5. Tarayıcınızda `http://localhost:5000` adresine giderek uygulamayı görüntüleyin.

## Özellikler

- Ürün arama özelliği.
- Kategorilere göre filtreleme.
- Tarih aralığına göre sipariş görüntüleme.
- Kullanıcı bilgilerini görüntüleme.

## Katkıda Bulunanlar

- Faru Nuri Sönmez

## Lisans

Bu proje [MIT Lisansı](LICENSE) ile lisanslanmıştır.
