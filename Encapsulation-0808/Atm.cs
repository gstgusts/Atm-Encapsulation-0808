using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation_0808
{
    internal class Atm
    {
        private Account? _currentAccount;

        public Atm(string address, int balance)
        {
            Address = address;
            _balance = balance;  
        }

        private List<Account> _accounts { get; set; } = new List<Account>();

        public string Address { get; private set; }

        private int _balance;

        public IEnumerable<Account> Accounts => _accounts;

        public AddAccountResultEnum AddAccount(Account account)
        {
            if(account == null)
            {
                throw new ArgumentNullException(nameof(account));
            }

            if(string.IsNullOrEmpty(account.Number))
            {
                return AddAccountResultEnum.AccountNumberIsNotProvided;
            }

            if(_accounts.Any(a => a.Number == account.Number))
            {
                return AddAccountResultEnum.AccountNumberAlreadyExists;
            }

            _accounts.Add(account);

            return AddAccountResultEnum.Success;
        }

        internal ConnectAccountEnum ConnectToAccount(string number, int pin)
        {
            var account = _accounts.FirstOrDefault(a => a.Number == number);

            if(account != null && account.IsPinValid(pin))
            {
                _currentAccount = account;
                return ConnectAccountEnum.Success;
            }

            return ConnectAccountEnum.Error;
        }

        internal void DisconnectFromAccount()
        {
            if(_currentAccount == null)
            {
                throw new ArgumentNullException("Not connected to account");
            }

            _currentAccount = null;
        }

        internal TakeOutMoneyResultEnum TakeOutMoney(int amount)
        {
            if (_currentAccount == null)
            {
                throw new ArgumentNullException("Not connected to account");
            }

            if(_balance < amount)
            {
                return TakeOutMoneyResultEnum.PleaseChooseDifferentAmount;
            }

            var result = _currentAccount.TakeOutMoney(amount);

            if(result == TakeOutMoneyResultEnum.Success)
            {
                _balance -= amount;
            }

            return result;
        }
    }  
}
