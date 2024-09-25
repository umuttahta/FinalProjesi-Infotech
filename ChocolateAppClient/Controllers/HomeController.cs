using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ChocolateAppClient.Models;
using System.Text.Json;
using System.Threading.Tasks;
using System.Linq;

namespace ChocolateAppClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HomeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var rootChocolates = new Root<List<ChocolateViewModel>>();

            // IHttpClientFactory ile HttpClient oluşturun
            var httpClient = _httpClientFactory.CreateClient();

            // Anasayfa Çikolatalarını API'dan çek
            try
            {
                using (HttpResponseMessage response = await httpClient.GetAsync("http://localhost:3535/api/Chocolate"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();

                        // Raw JSON içeriğini loglayın
                        Debug.WriteLine("Raw JSON content:");
                        Debug.WriteLine(content);

                        var options = new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true // Büyük/küçük harf duyarlılığını ayarla
                        };

                        rootChocolates = JsonSerializer.Deserialize<Root<List<ChocolateViewModel>>>(content, options);

                        // Deserialized verileri loglayın
                        if (rootChocolates?.Data != null)
                        {
                            Debug.WriteLine("Deserialized data:");
                            foreach (var chocolate in rootChocolates.Data)
                            {
                                Debug.WriteLine($"Chocolate: {chocolate.Name}, Price: {chocolate.Price}, ImageUrl: {chocolate.ImageUrl}");
                            }
                        }
                        else
                        {
                            Debug.WriteLine("Deserialization returned null data");
                        }
                    }
                    else
                    {
                        return NotFound(); // API çağrısı başarısızsa NotFound döndür
                    }
                }
            }
            catch (JsonException jsonEx)
            {
                // JSON deserialization hatalarını işleyin
                Debug.WriteLine($"Deserialization error: {jsonEx.Message}");
                return StatusCode(500, "Error deserializing JSON data");
            }
            catch (Exception ex)
            {
                // Diğer hataları işleyin
                Debug.WriteLine($"Error fetching data from API: {ex.Message}");
                return StatusCode(500, "Error fetching data from API");
            }

            // Veriler varsa sayfayı döndür
            if (rootChocolates?.Data == null || !rootChocolates.Data.Any())
            {
                return NotFound(); // Eğer veriler null veya boş ise NotFound döndür
            }

            return View(rootChocolates.Data);
        }
    }
}
