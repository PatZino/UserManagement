using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UserManagement.Models;

namespace UserManagement.Controllers
{
    public class AccountController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }

      
        public ViewResult Register() => View();

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel registerModel)
        {
            RegisterModel register = new RegisterModel();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(registerModel), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("http://localhost:60628/Users/register", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    try
                    {
                        register = JsonConvert.DeserializeObject<RegisterModel>(apiResponse);
                    }
                    catch (Exception ex)
                    {
                        ViewBag.Result = apiResponse;
                        return View();
                    }
                }
            }
            return View(register);
        }


        public ViewResult Login() => View();

        [HttpPost]
        public async Task<IActionResult> Login(AuthenticateModel authenticateModel)
        {
            AuthenticateModel authenticate = new AuthenticateModel();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(authenticateModel), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("http://localhost:60628/Users/authenticate", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    try
                    {
                        authenticate = JsonConvert.DeserializeObject<AuthenticateModel>(apiResponse);
                    }
                    catch (Exception ex)
                    {
                        ViewBag.Result = apiResponse;
                        return View();
                    }
                }
            }
            //return View(authenticate);
            //return RedirectToAction("Index");
            return RedirectToAction("Index", "Product", new { check = true});
        }






    }
}