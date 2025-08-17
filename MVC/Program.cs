var builder = WebApplication.CreateBuilder(args);

// MVC Servislerinin Eklenmesi:
// MVC uygulama özelliklerini etkinleştirmek ve hem view'leri hem de controller'ları kullanabilmek için gerekli servisleri ekliyoruz
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Geliştirme ortamında hata sayfası gösterimi
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

// Statik Dosyaların Kullanımının Belirtilmesi:
// wwwroot klasöründe bulunan statik dosyaların (CSS, JS, resim vb.) kullanılmasını sağlayacak konfigürasyon
app.UseStaticFiles();

// Routing Konfigürasyonu:
// Tarayıcıdan gelen isteklerin doğru şekilde yönlendirilmesini sağlamak amacıyla routing yapılandırması
app.UseRouting();

app.UseAuthorization();

// Varsayılan Routing:
// Anasayfa için bir varsayılan routing yapılandırması - controller: Home, action: Index
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

/*
 * KAVRAMLARIN AÇIKLAMALARI:
 * 
 * Controller: MVC pattern'da kullanıcı etkileşimlerini yöneten, HTTP isteklerini alan ve uygun yanıtları dönen sınıflardır.
 * İş mantığını koordine ederler ve Model ile View arasında köprü görevi görürler.
 * 
 * Action: Controller sınıfları içerisinde bulunan ve belirli HTTP isteklerini karşılayan metotlardır.
 * Her action farklı bir işlevi yerine getirir (Index, Create, Edit, Delete vb.).
 * 
 * Model: Uygulamanın veri yapısını ve iş mantığını temsil eden sınıflardır.
 * Veritabanı tablolarını, veri transfer objelerini ve doğrulama kurallarını içerir.
 * 
 * View: Kullanıcıya gösterilecek HTML içeriğini üreten şablon dosyalarıdır.
 * Model'den gelen verileri kullanıcı arayüzünde görsel olarak sunar.
 * 
 * Razor: Microsoft'un ASP.NET Core'da sunduğu view template engine'idir.
 * HTML ile C# kodunu birleştirerek dinamik web sayfaları oluşturmaya olanak sağlar.
 * 
 * RazorView: Razor syntax'ı kullanılarak yazılmış view dosyalarıdır (.cshtml uzantılı).
 * Server-side rendering için C# kodunu HTML ile harmanlayarak çalışır.
 * 
 * wwwroot: Statik dosyaların (CSS, JavaScript, resimler, favicon vb.) saklandığı özel klasördür.
 * Bu klasördeki dosyalar doğrudan web tarayıcısı tarafından erişilebilir.
 * 
 * builder.Build(): WebApplicationBuilder nesnesini kullanarak WebApplication örneği oluşturur.
 * Bu noktaya kadar eklenen tüm servisleri ve konfigürasyonları uygulama instance'ına aktarır.
 * 
 * app.Run(): Web uygulamasını başlatır ve HTTP isteklerini dinlemeye başlar.
 * Uygulama yaşam döngüsünün ana döngüsünü başlatır ve sunucuyu aktif hale getirir.
 */ 