using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace pjo_client_app
{
    class Program
    {
        private static string baseAddress = "http://localhost:25410/";
        private static string tokenAccess = "";

        static void Main(string[] args)
        {
            RunAsync().Wait();
            GetDataFromClient();
        }

        static async Task RunAsync()
        {
            using (var client = new HttpClient())
            {
                // Send HTTP requests              
                client.BaseAddress = new Uri(baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // HTTP POST                
                var body = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("grant_type", "password"),
                    new KeyValuePair<string, string>("username", "xuandt@gmail.com"),
                    new KeyValuePair<string, string>("password", "123456")
                };
                var content = new FormUrlEncodedContent(body);
                HttpResponseMessage response = await client.PostAsync("token", content);

                //var tokenResponse = client.PostAsync(baseAddress + "/oauth/token", new FormUrlEncodedContent(body)).Result;
                ////var token = tokenResponse.Content.ReadAsStringAsync().Result;  
                //var token = tokenResponse.Content.ReadAsAsync<Token>(new[] { new JsonMediaTypeFormatter() }).Result;

                if (response.IsSuccessStatusCode)
                {
                    var responseStream = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(responseStream);

                    var token = JsonConvert.DeserializeObject<Token>(responseStream);
                    tokenAccess = token.AccessToken;

                    Console.ReadLine();
                }
            }
        }

        static async Task GetDataFromClient()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", tokenAccess);
                HttpResponseMessage response = client.GetAsync("api/users/getall").Result;
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Success");
                    var data = response.Content.ReadAsStringAsync().Result;
                    Console.WriteLine(data);
                    Console.ReadLine();
                }
            }
        }
    }
}