using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace imHeroesSearch.Models
{
    public class Comic
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ThumbnailURL { get; set; }
    }
}