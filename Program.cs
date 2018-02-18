using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace JustEatRecruitmentTest
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                string input = "";
                if (args.Length == 1)
                {
                    input = args[0];
                }
                else
                {
                    Console.Write("Please enter outcode: ");
                    input = Console.ReadLine();
                }

                GetRestraunts(input);
            }
        }

        private static Restraunt[] GetRestraunts(string outcode)
        {
            RestClient client = new RestClient("https://public.je-apis.com/");
            RestRequest request = new RestRequest("restaurants", Method.GET);

            request.AddParameter("q", outcode); 
            request.AddHeader("Accept-Tenant", "uk");
            request.AddHeader("Accept-Language", "en-GB");
            request.AddHeader("Authorization", "{NEEDS UPDATED TOKEN}");
            request.AddHeader("Host", "public.je-apis.com");

            IRestResponse response = client.Execute(request);
            string content = response.Content;

            Console.WriteLine(content);
            return null;
        }
    }
}
