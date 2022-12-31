using AHY.JWTApp.Mvc.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AHY.JWTApp.Mvc.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CategoryController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> List()
        {
            var token = User.Claims.FirstOrDefault(x => x.Type == "accesToken")?.Value;
            if (token != null)
            {
                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                var response = await client.GetAsync("http://localhost:5220/api/Categories");
                if (response.IsSuccessStatusCode)
                {
                    var jsonData = await response.Content.ReadAsStringAsync();
                    var categoryList = JsonConvert.DeserializeObject<List<CategoryListModel>>(jsonData);
                    return View(categoryList);
                }
            }
            return View(new List<CategoryListModel>());
        }

        public async Task<IActionResult> Remove(int id)
        {
            var token = User.Claims.FirstOrDefault(x => x.Type == "accesToken")?.Value;
            if (token != null)
            {
                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                var response = await client.DeleteAsync($"http://localhost:5220/api/categories/{id}");
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return RedirectToAction("List", "Category");
                }
                else
                {
                    TempData["hata"] = "Yetkisiz erişim";
                    return RedirectToAction("List", "Category");
                }
            }
            return RedirectToAction("List", "Home");
        }

        public IActionResult Create()
        {
            return View(new CategoryCreateModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryCreateModel model)
        {
            var token = User.Claims.FirstOrDefault(x => x.Type == "accesToken")?.Value;
            if (ModelState.IsValid)
            {
                if (token != null)
                {
                    var client = _httpClientFactory.CreateClient();
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                    var content = new StringContent(JsonConvert.SerializeObject(model), System.Text.Encoding.UTF8, "application/json");
                    var response = await client.PostAsync($"http://localhost:5220/api/categories", content);
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("List", "Category");
                    }
                    else
                    {
                        ModelState.AddModelError("", $"Bir hata oluştu {response.StatusCode.ToString()}");
                    }
                }
            }
            return View(model);
        }

        public async Task<IActionResult> Update(int id)
        {
            var token = User.Claims.FirstOrDefault(x => x.Type == "accesToken")?.Value;
            if (token != null)
            {
                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                var response = await client.GetAsync($"http://localhost:5220/api/categories/{id}");
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var jsonData = await response.Content.ReadAsStringAsync();
                    var category = JsonConvert.DeserializeObject<CategoryListModel>(jsonData);
                    return View(category);
                }
            }

            return RedirectToAction("List", "Category");
        }

        [HttpPost]
        public async Task<IActionResult> Update(CategoryListModel model)
        {
            var token = User.Claims.FirstOrDefault(x => x.Type == "accesToken")?.Value;
            if (token != null)
            {
                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                var content = new StringContent(JsonConvert.SerializeObject(model), System.Text.Encoding.UTF8, "application/json");
                var response = await client.PutAsync("http://localhost:5220/api/categories",content);

                if (response.StatusCode==System.Net.HttpStatusCode.NoContent)
                {
                    return RedirectToAction("List", "Category");
                }
            }
            return View(model);
        }
    }
}
