using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Гараж
{
    internal class Garage
    {
        public string garageName;
        private int _servicePrice;
        public Garage(string garageName)
        {
            this.garageName = garageName;
        }

        public int GetPrice(Random random)//доработать рандом
        {
            int servicePrice = random.Next(100, 500);
            _servicePrice = servicePrice;
            return servicePrice;

        }


    }

}
