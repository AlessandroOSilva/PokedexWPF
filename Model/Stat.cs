using Newtonsoft.Json;
using Pokedex.Model;
using System;
using System.Collections.Generic;

namespace Models
{
    public class Stat
    {
        [JsonProperty("base_stat")]
        public long BaseStat { get; set; }
        public long Effort { get; set; }
        public Species StatStat { get; set; }


    }
}