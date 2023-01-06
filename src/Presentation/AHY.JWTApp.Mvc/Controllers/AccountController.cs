using AHY.JWTApp.Mvc.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;


namespace AHY.JWTApp.Mvc.Controllers
{
    public class AccountController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AccountController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Login()
        {
            return View(new UserLoginModel());
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginModel model)
        {
            if (ModelState.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                var content = new StringContent(JsonConvert.SerializeObject(model), System.Text.Encoding.UTF8, "application/json");
                var response = await client.PostAsync("http://localhost:5220/api/Auth/Login", content);
                if (response.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    var jsonData = await response.Content.ReadAsStringAsync();
                    var tokenModel = JsonConvert.DeserializeObject<JwtTokenResponseModel>(jsonData);

                    if (tokenModel != null)
                    {
                        JwtSecurityTokenHandler handler = new();
                        var token = handler.ReadJwtToken(tokenModel.Token);

                        var claims = token.Claims.ToList();

                        if (tokenModel.Token != null)
                            claims.Add(new Claim("accesToken", tokenModel.Token));

                        var claimsIdentity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);

                        var authProps = new AuthenticationProperties
                        {
                            ExpiresUtc = tokenModel.ExpireDate,
                            IsPersistent = false
                        };

                        await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProps);
                    }
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Kullanıcı adı veya şifre hatali.");
                }
                return View();
            }

            return View(model);
        }
    }
}
