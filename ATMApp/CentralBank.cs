using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMApp
{
    // класс описывающий центральный банк
    public class CentralBank
    {
        // список счетов клиентов в центральном банке
        private List<BankAccount> bankAccounts = new List<BankAccount>();

        // конструктор центрального банка, в конструкторе инициализируются счета клиентов банка
        public CentralBank()
        {
            bankAccounts.Add(new BankAccount("0000-0000-0000-0001", 10000));
            bankAccounts.Add(new BankAccount("1111-0000-0000-0002", 20000));
            bankAccounts.Add(new BankAccount("2222-0000-0000-0003", 30000));
            bankAccounts.Add(new BankAccount("3333-0000-0000-0004", 0));
        }

        // метод проверки существования счета карты
        public bool CheckAccountExist(string accountNumber)
        {
            bool isExist = bankAccounts.Any(f => f.AccountNumber == accountNumber);
            return isExist;
        }

        // метод для получения баланса на счету
        public double getAccountBalance(string accountNumber)
        {
            BankAccount bankAccount = bankAccounts.Find(f => f.AccountNumber == accountNumber);
            return bankAccount.GetBalance();
        }

        // метода для запроса на операцию по снятию суммы у центрального банка
        public bool WithdrawalRequest(string accountNumber, double sum)
        {
            BankAccount bankAccount = bankAccounts.Find(f => f.AccountNumber == accountNumber && f.GetBalance() >= sum);
            if (bankAccount != null)
            {
                bankAccount.ChangeBalance(-sum);
                return true;
            }
            else
            {
                return false;
            }
        }

        // метод для запроса на пополнение баланса счета у центрального банка
        public void ReplenishmentRequest(string accountNumber, double sum)
        {
            BankAccount bankAccount = bankAccounts.Find(f => f.AccountNumber == accountNumber);
            bankAccount.ChangeBalance(sum);
        }
    }
}
