using Newtonsoft.Json;
using Pokedex.GetApis;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
namespace ConsoleApp1
{

    public class Program
    {
        public static async Task Main()
        {
            ListPokemon listpoke = new ListPokemon();
            ClassPokedex poke = new ClassPokedex();
            List<ClassPokedex> ListPoke = new List<ClassPokedex>();

            string[] pokes = listpoke.convertToList();

            foreach(string pokemon in pokes)
            {
                string url = "https://pokeapi.co/api/v2/pokemon/" + pokemon.ToLower();
                HttpClient client = new HttpClient();

                var httpResponse = await client.GetAsync(url);

                if (httpResponse.IsSuccessStatusCode)
                {
                    var content = await httpResponse.Content.ReadAsStringAsync();

                    poke = JsonConvert.DeserializeObject<ClassPokedex>(content);
                    ListPoke.Add(poke);
                }
                else
                {
                    Console.WriteLine("El pokemon: {0} no existe.", pokemon);
                }
            }
        }

    }

}









