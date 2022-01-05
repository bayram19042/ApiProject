using ApiProjectUI.ResponseModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ApiProjectUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory _httpclientfactory;
        public HomeController(IHttpClientFactory httpClientFactory)
        {
            _httpclientfactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            var client = _httpclientfactory.CreateClient();
           var responseMessage = await client.GetAsync("http://localhost:5000/api/products");
            if(responseMessage.StatusCode==System.Net.HttpStatusCode.OK)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<ProductList>>(jsonData);
                return View(result);
            }
            else
            {
                return View(null);
            }
           
        }
    }
}
