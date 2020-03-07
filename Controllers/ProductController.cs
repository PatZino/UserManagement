using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UserManagement.Models;

namespace UserManagement.Controllers
{
    public class ProductController : Controller
    {
        public async Task<IActionResult> Index(bool check)
        {
            if (check)
            {
                List<Product> prods = new List<Product>();
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync("https://localhost:44318/api/products"))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        prods = JsonConvert.DeserializeObject<List<Product>>(apiResponse);
                    }
                }
                return View(prods);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }






    }
}