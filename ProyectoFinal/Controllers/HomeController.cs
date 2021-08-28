using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ProyectoFinal.Manager;
using ProyectoFinal.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace ProyectoFinal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        
        private readonly AppSettings _appSettings;

        private string myURL;

        public static List<Data> JsonUsers(string value)
        {
            return JsonConvert.DeserializeObject<Page>(value).Data;
        }

        public static Pagination JsonPages(string value)
        {
            return JsonConvert.DeserializeObject<Page>(value).Pagination;
        }


        public HomeController(ILogger<HomeController> logger, IOptions<AppSettings> appSettings)
        {
            _logger = logger;
            _appSettings = appSettings.Value;
        }

        public ActionResult Index(string addressAPI)
        {
            if (addressAPI != null)
            {

                @myURL = addressAPI;
            }
            else
            {
                @myURL = _appSettings.APIUrl;
            }
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(@myURL);

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                var json = reader.ReadToEnd();
                JObject jResults = JObject.Parse(json);

                Pagination myPagination = new Pagination();
                myPagination = JsonPages(jResults["meta"].ToString());

                List<Data> myUsers = (from Data c in JsonUsers(json)
                                      select c).ToList();

                var modelo = new InfoVM();
                modelo.InfUsers = myUsers;
                modelo.InfPagination = myPagination;

                return View(modelo);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
