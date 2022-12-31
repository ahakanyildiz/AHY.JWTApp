using AHY.JWTApp.Mvc.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace AHY.JWTApp.Mvc.Controllers
{
    [Authorize(Roles = "Admin,Member")]
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> List()
        {
            var token = User.Claims.FirstOrDefault(x => x.Type == "accesToken")?.Value;
            if (token != null)
            {
                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
                var response = await client.GetAsync("http://localhost:5220/api/products");
                if (response.IsSuccessStatusCode)
                {
                    var jsonData = await response.Content.ReadAsStringAsync();
                    var productList = JsonConvert.DeserializeObject<List<ProductListModel>>(jsonData);
                    return View(productList);
                }
            }
            return View(new List<ProductListModel>());
        }


        public async Task<IActionResult> Remove(int id)
        {
            var token = User.Claims.FirstOrDefault(x => x.Type == "accesToken")?.Value;
            if (token != null)
            {
                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
                var response = await client.DeleteAsync($"http://localhost:5220/api/products/{id}");
            }
            return RedirectToAction("List", "Product");
        }

        public async Task<IActionResult> Update(int id)
        {
            var token = User.Claims.FirstOrDefault(x => x.Type == "accesToken")?.Value;
            if (token != null)
            {
                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var response = await client.GetAsync($"http://localhost:5220/api/products/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var jsonData = await response.Content.ReadAsStringAsync();
                    var productModel = JsonConvert.DeserializeObject<ProductListModel>(jsonData);
                    return View(productModel);
                }
            }
            return RedirectToAction("List", "Product");
        }

        [HttpPost]
        public async Task<IActionResult> Update(ProductListModel model)
        {
            var token = User.Claims.FirstOrDefault(x => x.Type == "accesToken")?.Value;
            if (token != null)
            {
                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var content = new StringContent(JsonConvert.SerializeObject(model), System.Text.Encoding.UTF8, "application/json");
                var response = await client.PutAsync($"http://localhost:5220/api/products", content);
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return RedirectToAction("List", "Product");
                }
            }
            ModelState.AddModelError("", "Bir hata oluştu");
            return View(model);
        }

        public IActionResult Create()
        {
            return View(new ProductCreateModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateModel model)
        {
            var token = User.Claims.FirstOrDefault(x => x.Type == "accesToken")?.Value;
            if (token != null)
            {
                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var jsonModel = JsonConvert.SerializeObject(model);
                var content = new StringContent(jsonModel, Encoding.UTF8, "application/json");

                var response = await client.PostAsync("http://localhost:5220/api/products", content);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("List", "Product");
                }
            }
            TempData["error"] = "Bir hata oluştu";
            return View(model);
        }
    }
}
