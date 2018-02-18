using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
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

            //Get token
            Console.Write("Please enter token: ");
            string token = Console.ReadLine();
            if (!JustEat.GetRestraunts(token, "se19").Item1)
                exit = true;

            //Loop
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

                Console.Clear();
                Tuple<bool, Restaurant[]> restaurants = JustEat.GetRestraunts(token, input);

                //Check to see if restaurants were received correctly
                if (!restaurants.Item1)
                    exit = true;

                //Check for empty results
                if (restaurants.Item2.Length == 0)
                {
                    Console.WriteLine("No results");
                    continue;
                }

                //Write output
                foreach (Restaurant restaurant in restaurants.Item2)
                {
                    Console.WriteLine("Name: " + restaurant.Name);
                    Console.WriteLine("Rating: " + restaurant.Score);

                    Console.WriteLine("Food: ");
                    foreach (CuisineTypes cType in restaurant.CuisineTypes)
                    {
                        Console.WriteLine(Environment.NewLine);
                        Console.WriteLine("    ID: " + cType.ID);
                        Console.WriteLine("    Name: " + cType.Name);
                        Console.WriteLine("    SeoName: " + cType.SeoName);
                    }
                    Console.WriteLine(new string('-', Console.WindowWidth));
                }
            }

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
