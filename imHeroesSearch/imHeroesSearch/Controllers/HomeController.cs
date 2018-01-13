using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using imHeroesSearch.Util;
using imHeroesSearch.Models;

namespace imHeroesSearch.Controllers
{
    public class HomeController : Controller
    {
        private MarvelAPI _Marvel { get; set; }

        public HomeController()
        {
            _Marvel.publicKey = ConfigurationManager.AppSettings["MarvelAPIKey"];
            _Marvel.privateKey = ConfigurationManager.AppSettings["MarvelAPIPrivateKey"];
            _Marvel.baseURL = ConfigurationManager.AppSettings["MarvelAPIBaseURL"];
        }

        public ActionResult Index()
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                string hash = MarvelAPIUtil.GetHash(DateTime.Now.Ticks.ToString(), _PublicKey, _PrivateKey);


            }

            return View();
        }
    }
}