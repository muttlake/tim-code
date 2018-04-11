using System;
using System.Net.Http;
using System.Threading;

namespace RestService.Consumer
{
    class Program
    {
        static void Main(string[] args)
        {

            ConsumeAsync();
            Thread.Sleep(5000); 
        }

        static async void ConsumeAsync()
        {
            var cli = new HttpClient();
            var res = await cli.GetAsync("http://localhost:5000/pizza/read/1?extra=consumer");
            
            if(res.IsSuccessStatusCode)
            {
                //System.Console.WriteLine(res.Content.ReadAsStringAsync().GetAwaiter().GetResult());
                System.Console.WriteLine(await res.Content.ReadAsStringAsync());
            }
            else
            {
                Console.WriteLine(res.ReasonPhrase);  //shows the error
            }
        }
    }
}
