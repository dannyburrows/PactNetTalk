using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PactNet.Library
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseUri = "https://localhost:5001";
            var client = new PactNetClient(baseUri);
            Console.WriteLine("Retrieving data");
            var result = client.Get(0).GetAwaiter().GetResult();
            var resultContentText = JsonConvert.SerializeObject(result);
            Console.WriteLine(resultContentText);
            Console.WriteLine("Complete. Goodbye.");
        }
    }
}