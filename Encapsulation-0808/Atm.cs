using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation_0808
{
    internal class Atm
    {
        public Atm(string address, int balance)
        {
            Address = address;
            Balance = balance;  
        }

        private List<Account> _accounts { get; set; }

        public string Address { get; private set; }

        public int Balance { get; private set; }

        public IEnumerable<Account> Accounts => _accounts;

        public void AddAccount(Account account)
        {
            if(account == null)
            {
                throw new ArgumentNullException(nameof(account));
            }
        }
    }
}
