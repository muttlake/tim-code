using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Library
{
    public class RelayPost
    {
        public RelayPost()
        {

        }
        
        public async Task RelayAddToDataSvc(Uri uri, string requestBody)
        {
            //Pass to DataSvc
            using (var client = new HttpClient())
            {
                var stringContent = new StringContent(requestBody);
                await client.PostAsync(uri, stringContent);
            }
        }
    }
}
