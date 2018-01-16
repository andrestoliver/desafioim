using System.Collections.Generic;

namespace imHeroesSearch.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ThumbnailURL { get; set; }
        public List<Comic> Comics { get; set; }
    }
}