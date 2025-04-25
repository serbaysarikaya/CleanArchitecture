CleanArchitecture Projesi
Bu proje, Clean Architecture prensiplerine uygun olarak katmanlı, modüler ve sürdürülebilir bir mimari yapıya sahiptir. 

Proje Yapısı
CleanArchitecture.sln
│
├── Core (Temel katmanlar)
│   ├── CleanArchitecture.Domain           // İş varlıkları, domain modelleri ve temel iş kuralları
│   ├── CleanArchitecture.Application      // İş mantığı, servisler, kullanım senaryoları
│
├── External (Dış bağımlılıklar)
│   ├── CleanArcihtecture.Infrastructure   // Dış servisler, altyapı implementasyonları
│   ├── CleanArchitecture.Persistance      // Veri erişim katmanı (Repository, DbContext vs)
│   ├── CleanArchitecture.Presentation     // UI katmanı (ör. WPF, devam eden UI çözümleri)
│   └── CleanArchitecture.WebApi            // Web API projesi (REST servisleri)
│
├── src (Kaynak dosyalar varsa burada toplanmış olabilir)
│
└── test
    └── CleanArchitecture.UnitTest          // Birim testler
    
Proje Katmanlarının Görevleri
Domain: İş kuralları ve varlıklar burada tanımlanır. Diğer katmanlardan bağımsızdır.
Application: Domain katmanını kullanarak iş mantığını uygular. Servisler, komutlar ve sorgular bu katmanda bulunur.
Infrastructure: Veri erişim, harici servisler ve diğer altyapı hizmetler burada yer alır.
Persistence: Veri tabanı işlemleri, EF Core gibi ORM ve repository implementasyonları bu katmanda tutulur.
Presentation: Kullanıcıya yönelik arayüz ve frontend katmanı.
WebApi: REST API uç noktaları burada tanımlanır; dış dünya ile iletişim bu katman üzerinden olur.
UnitTest: Uygulamaya ait birim testler bulunur.
Kullanılan Teknolojiler
.NET 7+ / .NET Core
Entity Framework Core
xUnit / NUnit / MSTest (test çerçevesi)
Visual Studio 2022 / 2023
Çalıştırma ve Test Etme

