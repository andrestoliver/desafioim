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
        public ActionResult Index()
        {
            //ViewBag.Characters = MarvelAPIUtil.GetCharacters();

            return View(MarvelAPIUtil.GetCharacters());
        }

        [HttpGet]
        public JsonResult GetComics(int id)
        {
            List<ComicResponse> response = new List<ComicResponse>();

            foreach (Comic item in MarvelAPIUtil.GetComics(id, 6, 0))
            {
                ComicResponse responseItem = new ComicResponse();

                responseItem.Comic = item;
                responseItem.Total = 6;
                responseItem.ItemNumber = 1;

                response.Add(responseItem);
            }

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetCharacters(string term)
        {
            return Json(MarvelAPIUtil.GetCharactersByText(term), JsonRequestBehavior.AllowGet);
        }
    }
}