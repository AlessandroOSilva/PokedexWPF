using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Pokedex.Services
{
    class ApiRequest
    {

        public async Task<Pokemon> PokemonPorNome(string nome)
        {
            try
            {
                HttpClient cliente = new HttpClient { BaseAddress = new Uri("https://pokeapi.co/api/v2/pokemon/" + nome) };
                var resposta = cliente.GetAsync(nome).Result;

                var conteudo = await resposta.Content.ReadAsStringAsync();

                var pokemon = JsonConvert.DeserializeObject<Pokemon>(conteudo);

                if(pokemon.PokemonName == null)
                {
                    pokemon = null;
                    return pokemon;
                }

                pokemon.Stats.Add(await GetStats(nome));


                return pokemon;


            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Stat> GetStats(string nome)
        {
            try
            {
                var stats = new List<Stat>();
                HttpClient cliente = new HttpClient { BaseAddress = new Uri("https://pokeapi.co/api/v2/pokemon/" + nome) };
                var resposta = cliente.GetAsync(nome).Result;
                var conteudo = await resposta.Content.ReadAsStringAsync();
                var stat = JsonConvert.DeserializeObject<Stat>(conteudo);

                stats.Add(stat);

                return stat;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
