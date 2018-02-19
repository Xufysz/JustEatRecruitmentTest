using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustEatRecruitmentTest.JSON_Objects
{
    class Restaurant
    {
        public string Name { get; set; }
        public double Score { get; set; }
        public CuisineTypes[] CuisineTypes { get; set; }
    }
}
