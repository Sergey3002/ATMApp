using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMApp
{
    // класс кредитная карта
    public class BankCard
    {
        // номер карты
        public string CardNumber { get; set; }
        // номер счета карты

        // конструктор класса кредитная карта, в качестве параметра принимает номер карты
        public BankCard(string cardNumber)
        {
            this.CardNumber = cardNumber;
        }
    }
}
