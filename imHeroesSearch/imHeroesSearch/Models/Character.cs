using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace imHeroesSearch.Models
{
    public class Character
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public string ThumbnailURL { get; set; }
        public List<Comic> Comics { get; set; }

        public Character GetCharacterById(){

            return new Character();
        }
    }
}