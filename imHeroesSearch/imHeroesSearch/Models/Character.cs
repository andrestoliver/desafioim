using imHeroesSearch.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using Newtonsoft.Json;

namespace imHeroesSearch.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ThumbnailURL { get; set; }
        public List<Comic> Comics { get; set; }

        public Character GetCharacterById(MarvelAPI marvel, int id){
            string hash = MarvelAPIUtil.GetHash(DateTime.Now.Ticks.ToString(), marvel.PublicKey, marvel.PrivateKey);
            string requestURL = string.Format("{0}characters?ts={1}&apikey={2}&hash={3}&id={4}", marvel.BaseURL, marvel.PublicKey, hash, id);
            Character character = new Character();

            HttpResponseMessage response = marvel.Client.GetAsync(requestURL).Result;
            response.EnsureSuccessStatusCode();
            string content = response.Content.ReadAsStringAsync().Result;
            dynamic result = JsonConvert.DeserializeObject(content);

            character.Name = result.data.results[0].id;
            character.Name = result.data.results[0].name;
            character.Description = result.data.results[0].description;
            character.Description = result.data.results[0].thumbnail.path + "." + result.data.results[0].thumbnail.extension;
            
            return character;
        }
    }
}