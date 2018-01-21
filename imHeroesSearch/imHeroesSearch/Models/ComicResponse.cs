using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace imHeroesSearch.Models
{
    public class ComicResponse
    {
        public Comic Comic { get; set; }
        public int Total { get; set; }
        public int ItemNumber { get; set; }
    }
}