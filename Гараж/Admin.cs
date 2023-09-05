using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Гараж
{
    internal class Admin
    {
        private decimal _moneyBalance = 0;
        private string _nameAdmin;

        public Admin (string name)
        {
            _nameAdmin = name;
        }

        public decimal GetMyFieldBalance()
        {
            return _moneyBalance;
        }

        public decimal GetMoneyBalance(int money)
        {
            decimal commission = 10;
            _moneyBalance += money * commission / 100;
            return _moneyBalance; 
        }

        public void GetBestChoice(Dictionary<Garage, int> priceList)
        {
            foreach (var pair in priceList)
            {
                Console.WriteLine("{0}: {1}", pair.Key.garageName, pair.Value);
            }
            var minKeyValuePair = priceList.Aggregate((l, r) => l.Value < r.Value ? l : r);
            var minKey = minKeyValuePair.Key.garageName;
            int minValue = minKeyValuePair.Value;

            Console.WriteLine($"\nЛучшая цена за выбранный сервис: {minValue} у гаража - {minKey}");

        }

    }
}
