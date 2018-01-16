﻿using System;
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
            ViewBag.Characters = MarvelAPIUtil.GetCharacters();

            return View();
        }
    }
}