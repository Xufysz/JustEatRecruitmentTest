using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustEatRecruitmentTest
{
    class Restraunt
    {
        public string Name { get; private set; }
        public double Rating { get; private set; }
        public string[] FoodTypes { get; private set; }
        public Restraunt(string name, double rating, string[] foodTypes)
        {
            this.Name = name;
            this.Rating = rating;
            this.FoodTypes = FoodTypes;
        }
    }
}
