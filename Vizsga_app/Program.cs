using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Vizsga_app;

namespace Vizsga_app
{
    internal class Program
    {

        static async Task Main(string[] args)
        {
            await UgyfelAdatok();
            Console.Title = "Ugyfelek";


        }
        private static async Task UgyfelAdatok()
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage responseMessage = await httpClient.GetAsync("http://localhost/Vizsga_Backend/index.php?ugyfelek");
            if (responseMessage.IsSuccessStatusCode)
            {
                string jsonString = await responseMessage.Content.ReadAsStringAsync();
                var ugyfelek = Ugyfelek.FromJson(jsonString);
                foreach (var item in ugyfelek)
                {
                    Console.WriteLine($"{item.Nev}");
                }
                Console.ReadLine();
            }
        }
    }
}
