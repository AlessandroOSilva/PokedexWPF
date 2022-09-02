using Newtonsoft.Json;
using Pokedex.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Net.Http;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Models
{
    public class Pokemon
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string PokemonName { get; set; }
        [JsonProperty("species")]
        public Species Species { get; set; }
        [JsonProperty("stats")]
        public List<Stat> Stats { get; set; }
        [JsonProperty("url")]
        public Uri Link { get; set; }

        public Pokemon(string pokemonName, Species species, Uri link)
        {
            PokemonName = pokemonName;
            Species = species;
            Link = link;
        }

        public Pokemon()
        {

        }
        public Image GetImage(int id)
        {
            var dir = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/" + id + ".png";

            var request = WebRequest.Create(dir);

            using (var response = request.GetResponse())
            {
                using (var stream = response.GetResponseStream())
                {
                    return Image.FromStream(stream);

                    /*
                    var foto = new BitmapImage();
                    foto.BeginInit();
                    foto.StreamSource = stream;
                    foto.CacheOption = BitmapCacheOption.OnLoad;
                    foto.EndInit();
                    */
                }
            }
        }

        public void GetStats()
        {

        }
    }
}