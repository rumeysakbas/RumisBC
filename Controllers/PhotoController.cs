using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WebProject.Controllers
{
    public class PhotoController : Controller
    {
        private readonly HttpClient _httpClient;

        public PhotoController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // GET: Photo/UploadPhoto
        [HttpGet]
        public IActionResult UploadPhoto()
        {
            return View();
        }

        // POST: Photo/UploadPhoto
        [HttpPost]
        [ValidateAntiForgeryToken]  // CSRF koruması
        public async Task<IActionResult> UploadPhoto(string photoDescription)
        {
            if (!string.IsNullOrEmpty(photoDescription))
            {
                // Kullanıcı tarafından sağlanan açıklamayı kullanarak öneri alıyoruz
                var recommendation = await GetRecommendationFromAI(photoDescription);
                ViewBag.Recommendation = recommendation;
            }
            else
            {
                ViewBag.Message = "Lütfen bir fotoğraf açıklaması giriniz.";
            }

            return View();
        }

        // Kullanıcı açıklamasından öneri almak için OpenAI API çağrısı
        private async Task<string> GetRecommendationFromAI(string photoDescription)
        {
            var prompt = $"Aşağıda verilen fotoğraf açıklamasına dayanarak, kişi için hangi saç kesimi ve saç rengi önerilebilir? Açıklama: \"{photoDescription}\"";

            var requestContent = new
            {
                model = "gpt-3.5-turbo",
                messages = new[] {
                    new { role = "system", content = "You are an expert stylist and fashion consultant." },
                    new { role = "user", content = prompt }
                }
            };

            var apiKey = "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";  // Burada gerçek OpenAI API anahtarınızı kullanmalısınız.

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, "https://api.openai.com/v1/chat/completions")
            {
                Content = new StringContent(JsonConvert.SerializeObject(requestContent), Encoding.UTF8, "application/json")
            };

            requestMessage.Headers.Add("Authorization", $"Bearer {apiKey}");

            try
            {
                var response = await _httpClient.SendAsync(requestMessage);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    dynamic jsonResponse = JsonConvert.DeserializeObject(responseContent);
                    return jsonResponse.choices[0].message.content.ToString().Trim();
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    return $"Error: {response.StatusCode} - {errorContent}";
                }
            }
            catch (Exception ex)
            {
                return $"An error occurred: {ex.Message}";
            }
        }
    }
}
