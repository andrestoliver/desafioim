using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace imHeroesSearch.Models
{
    public class MarvelAuthorization
    {
        public string PublicKey { get; set; }
        public string PrivateKey { get; set; }
        public string BaseURL { get; set; }
        public string Hash { get; set; }
        public string Ts { get; set; }
    }
}