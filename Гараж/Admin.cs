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
            decimal moneyBalance = _moneyBalance; 
            decimal commission = 10;
            _moneyBalance = moneyBalance + money * commission / 100;
            return _moneyBalance; 
        }
    } 
}
