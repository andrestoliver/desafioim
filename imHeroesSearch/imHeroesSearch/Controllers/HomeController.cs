using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using imHeroesSearch.Util;
using imHeroesSearch.Models;
using Newtonsoft.Json;
using System.Web.Configuration;

namespace imHeroesSearch.Controllers
{
    public class HomeController : Controller
    {
        private MarvelAPI _Marvel { get; set; }

        public HomeController()
        {
            _Marvel = new MarvelAPI();
            _Marvel.PublicKey = ConfigurationManager.AppSettings["marvel:APIKey"];
            _Marvel.PrivateKey = ConfigurationManager.AppSettings["marvel:APIPrivateKey"];
            _Marvel.BaseURL = ConfigurationManager.AppSettings["marvel:APIBaseURL"];
            _Marvel.Client = new HttpClient();
        }

        public ActionResult Index()
        {
            using (var client = _Marvel.Client)
            {
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                Character obj = new Character();
                string json = JsonConvert.SerializeObject(obj.GetCharacterById(_Marvel, 1009220));

                ViewBag.Json = json;
            }
            return View();
        }
    }
}