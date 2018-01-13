using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace imHeroesSearch.Models
{
    public class MarvelAPI
    {
        public string publicKey { get; set; }
        public string privateKey { get; set; }
        public string baseURL { get; set; }
    }
}