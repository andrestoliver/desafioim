using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace imHeroesSearch.Models
{
    public class MarvelAPI
    {
        public string PublicKey { get; set; }
        public string PrivateKey { get; set; }
        public string BaseURL { get; set; }
        public HttpClient Client { get; set; }
    }
}