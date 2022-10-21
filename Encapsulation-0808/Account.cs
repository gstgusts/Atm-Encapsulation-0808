using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation_0808
{
    internal class Account
    {
        private int _pin;

        public Account(string number, double balance, int pin)
        {
            if (string.IsNullOrEmpty(number) || number.Length < 3)
            {
                throw new ArgumentException("Account is not provided or too short");
            }

            Number = number;
            Balance = balance;
            _pin = pin; 
        }

        public string Number { get; private set; }
        public double Balance { get; private set; } 
        
        public bool IsPinValid(int pin) { 
            return _pin == pin; 
        }
    }
}
