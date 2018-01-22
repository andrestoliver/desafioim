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
            return View(MarvelAPIUtil.GetCharacters());
        }

        [HttpGet]
        public JsonResult GetComics(int id, int page)
        {
            List<ComicResponse> response = new List<ComicResponse>();
            int offset = (page * 6)-1;

            foreach (Comic item in MarvelAPIUtil.GetComics(id, 6, offset))
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

        [HttpGet]
        public JsonResult GetComic(int id)
        {
            return Json(MarvelAPIUtil.GetComicById(id), JsonRequestBehavior.AllowGet);
        }
    }
}