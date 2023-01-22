using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMApp
{
    // класс бакноквский счет
    public class BankAccount
    {
        // свойство для получения номера счета
        public string AccountNumber { get; }

        // сумма денег на счету
        private double MoneySum {get; set;}

        // конструктор класса бакновский счет, в качестве параметров
        // принимает номер счета и сумму денег на счету
        public BankAccount(string accountNumber, double moneySum)
        {
            this.AccountNumber = accountNumber;
            this.MoneySum = moneySum;
        }

        // метод для получения текущего баланса на банквоском счету
        public double GetBalance()
        {
            return MoneySum;    
        }

        // метод для изменения текущего баланса на банковском счету на основе параметра
        public void ChangeBalance(double sum)
        {
            MoneySum += sum;
        }
    }
}
