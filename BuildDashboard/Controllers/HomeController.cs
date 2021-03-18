using BuildDashboard.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace BuildDashboard.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            BuildDashboard.Models.DashboardContent dc;
            dc = new BuildDashboard.Models.DashboardContent();
            //dc.ResponseData = "Data received from the server";

            using (var client = new HttpClient())
            {
                //var url = "https://ci.jenkins.io/api/";
                //var url = "http://localhost:8080/job/DotNet/3/consoleText";
                var url = "http://localhost:8080/job/DotNet/api/json?tree=builds[number,status,timestamp,id,result]";
                
                var response = client.GetAsync(url).Result;
                BuildDetails bd = new BuildDetails();
                Build bui = new Build();

                if (response.IsSuccessStatusCode)
                {

                    var responseContent = response.Content;

                    string responseString = responseContent.ReadAsStringAsync().Result;
                    

                    //dc.ResponseData = responseString;

                    bd = JsonConvert.DeserializeObject<BuildDetails>(responseString);
                    //bui = JsonConvert.DeserializeObject<Build>(responseString);


                }

                return View(bd);

            }

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}










/* using (var client = new HttpClient())
 {
     client.BaseAddress = new Uri("https://ci.jenkins.io/api/");
     var responseTask = client.GetAsync("text");
     responseTask.Wait();
     var result = responseTask.Result;
     if (result.IsSuccessStatusCode)
     {
         var readjob = result.Content.ReadAsStringAsync<IList<ErrorViewModel>>();
         readjob.Wait();
         IEnumerable<ErrorViewModel> text = readjob.Result;
     }
 }*/
//using (var httpClient = new HttpClient())
//{
//    using (var response = await _client.GetAsync("localhost:8080/job/DotNet/3/consoleText"))
//    {
//        var apiResponse = await response.Content.ReadAsStringAsync();
//        var task = JsonConvert.DeserializeObject(apiResponse);

//        return task;
//    }
//}
