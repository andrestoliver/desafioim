using imHeroesSearch.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace imHeroesSearch.Util
{
    public class MarvelAPIUtil
    {
        public static string GetHash(string time, string publicKey, string privateKey)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(time + privateKey + publicKey);
            var generator = MD5.Create();
            byte[] bytesHash = generator.ComputeHash(bytes);
            return BitConverter.ToString(bytesHash).ToLower().Replace("-", String.Empty);
        }

        public static Character GetCharacterById(int id)
        {
            Character character = new Character();
            MarvelAuthorization auth = GetAuthorizationParams();

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                string requestURL = string.Format("{0}characters?ts={1}&apikey={2}&hash={3}&id={4}", auth.BaseURL, auth.Ts, auth.PublicKey, auth.Hash, id);
                HttpResponseMessage response = client.GetAsync(requestURL).Result;
                response.EnsureSuccessStatusCode();

                string content = response.Content.ReadAsStringAsync().Result;
                dynamic result = JsonConvert.DeserializeObject(content);
                

                character.Id = result.data.results[0].id;
                character.Name = result.data.results[0].name;
                character.Description = result.data.results[0].description;
                character.ThumbnailURL = result.data.results[0].thumbnail.path + "." + result.data.results[0].thumbnail.extension;
            }
            return character;
        }

        public static List<Character> GetCharacters()
        {
            List<Character> characters = new List<Character>();
            MarvelAuthorization auth = GetAuthorizationParams();

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                string requestURL = string.Format("{0}characters?ts={1}&apikey={2}&hash={3}", auth.BaseURL, auth.Ts, auth.PublicKey, auth.Hash);
                HttpResponseMessage response = client.GetAsync(requestURL).Result;
                response.EnsureSuccessStatusCode();

                string content = response.Content.ReadAsStringAsync().Result;
                dynamic result = JsonConvert.DeserializeObject(content);

                foreach (dynamic item in result.data.results)
                {
                    Character character = new Character();
                    character.Id = item.id;
                    character.Name = item.name;
                    character.Description = item.description;
                    character.ThumbnailURL = item.thumbnail.path + "." + item.thumbnail.extension;
                    characters.Add(character);
                }
            }
            return characters;
        }

        public static List<Character> GetCharactersByText(string text)
        {
            List<Character> characters = new List<Character>();
            MarvelAuthorization auth = GetAuthorizationParams();

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                string requestURL = string.Format("{0}characters?ts={1}&apikey={2}&hash={3}&nameStartsWith={4}&limit=100", auth.BaseURL, auth.Ts, auth.PublicKey, auth.Hash, text);
                HttpResponseMessage response = client.GetAsync(requestURL).Result;
                response.EnsureSuccessStatusCode();

                string content = response.Content.ReadAsStringAsync().Result;
                dynamic result = JsonConvert.DeserializeObject(content);

                foreach (dynamic item in result.data.results)
                {
                    Character character = new Character();
                    character.Id = item.id;
                    character.Name = item.name;
                    character.Description = item.description;
                    character.ThumbnailURL = item.thumbnail.path + "/portrait_incredible." + item.thumbnail.extension;
                    characters.Add(character);
                }
            }
            return characters;
        }

        public static List<Comic> GetComics(int id, int limit, int offset)
        {
            List<Comic> comics = new List<Comic>();
            MarvelAuthorization auth = GetAuthorizationParams();

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                string requestURL = string.Format("{0}characters/{1}/comics?ts={2}&apikey={3}&hash={4}&limit={5}&offset={6}", auth.BaseURL, id, auth.Ts, auth.PublicKey, auth.Hash, limit, offset);
                HttpResponseMessage response = client.GetAsync(requestURL).Result;
                response.EnsureSuccessStatusCode();

                string content = response.Content.ReadAsStringAsync().Result;
                dynamic result = JsonConvert.DeserializeObject(content);

                foreach (dynamic item in result.data.results)
                {
                    Comic comic = new Comic();
                    comic.Id = item.id;
                    comic.Title = item.title;
                    comic.Description = item.description;
                    comic.ThumbnailURL = item.thumbnail.path + "." + item.thumbnail.extension;
                    comics.Add(comic);
                }
            }
            return comics;
        }

        public static MarvelAuthorization GetAuthorizationParams()
        {
            MarvelAuthorization result = new MarvelAuthorization();

            result.PublicKey = ConfigurationManager.AppSettings["marvel:APIKey"];
            result.PrivateKey = ConfigurationManager.AppSettings["marvel:APIPrivateKey"];
            result.BaseURL = ConfigurationManager.AppSettings["marvel:APIBaseURL"];
            result.Ts = DateTime.Now.Ticks.ToString();
            result.Hash = GetHash(result.Ts, result.PublicKey, result.PrivateKey);

            return result;
        }
    }
}