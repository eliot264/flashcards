using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashcards.Models
{
    public class Set
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Card> Cards { get; set; }
        [JsonIgnore]
        public int NumberOfCards => Cards.Count;

        public Set(string name, string description, ICollection<Card> cards)
        {
            Name = name;
            Description = description;
            Cards = cards;
        }
    }
}
