using JustEatRecruitmentTest.JSON_Objects;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustEatRecruitmentTest
{
    class JustEat
    {
        public static Tuple<bool, Restaurant[]> GetRestraunts(string token, string outcode)
        {
            //Get HTTP Request
            RestClient client = new RestClient("https://public.je-apis.com/");
            RestRequest request = new RestRequest("restaurants", Method.GET);

            request.AddParameter("q", outcode);
            request.AddHeader("Accept-Tenant", "uk");
            request.AddHeader("Accept-Language", "en-GB");
            request.AddHeader("Authorization", token);
            request.AddHeader("Host", "public.je-apis.com");

            IRestResponse response = client.Execute(request);
            return parseJSON(response.Content);
        }

        private static Tuple<bool, Restaurant[]> parseJSON(string json)
        {
            //Parse JSON and return
            JObject jsonParse = JObject.Parse(json);

            if (jsonParse["Errors"].HasValues)
            {               
                Error[] recievedErrors = JsonConvert.DeserializeObject<Error[]>(jsonParse["Errors"].ToString());
                foreach (Error e in recievedErrors)
                    Console.WriteLine(e.ErrorType + "\n" + e.Message);

                return new Tuple<bool, Restaurant[]>(false, null);
            }

            Restaurant[] restaurants = JsonConvert.DeserializeObject<Restaurant[]>(jsonParse["Restaurants"].ToString());

            return new Tuple<bool, Restaurant[]>(true, restaurants);
        }
    }
}
