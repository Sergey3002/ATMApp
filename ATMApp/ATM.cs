using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMApp
{
    // класс-банкомат, внутренняя логика
    public class ATM
    {
        // хранилище денен, массив всех купюр банкомата с разными номиналами
        int[][] nums = new int[7][];

        // текущая карта в бакномакте
        private BankCard card;

        // хранилище конфискованных карт (список)
        private List<BankCard> confiscatedCards;

        // объект сентрального банка к которому идет обращение для некоторых действий
        private CentralBank centralBank;

        // текстовая информация для справки о операции
        private string checkInfo;

        // константное значение для для статуса операции "Операция отклонена"
        public const string OPERATION_REJECTED = "Операция отклонена";

        // число попыток ввода PIN кода
        private int attempts;

        // конструктор класса-банкомат, в качестве параметров принимает количества купюр разных номиналов
        public ATM(int num50, int num100, int num200, int num500, int num1000, int num2000, int num5000)
        {
            // инициализация массива купюр, сопоставление количества купюр с номиналом
            nums[0] = new int[] { 5000, num5000 };
            nums[1] = new int[] { 2000, num2000 };
            nums[2] = new int[] { 1000, num1000 };
            nums[3] = new int[] { 500, num500 };
            nums[4] = new int[] { 200, num200 };
            nums[5] = new int[] { 100, num100 };
            nums[6] = new int[] { 50, num50 };

            confiscatedCards = new List<BankCard>();
            centralBank = new CentralBank();
            card = null;

            attempts = 3;
        }

        // метод для обновления числа попыток ввода PIN-кода
        public void updateAttemptsNumber()
        {
            attempts = 3;
        }

        // метод для получения оставшегося числа попыток для ввода PIN-кода
        public int getAttempts()
        {
            return attempts;
        }

        // метод для проверки PIN кода
        // PIN код карты равен 3 первым цифрам карты и одной последней
        public bool checkPIN(string PIN)
        {
            if (attempts > 0)
            {
                string expectedPIN = card.CardNumber.Substring(0, 3) + card.CardNumber[card.CardNumber.Length - 1];
                if (PIN == expectedPIN)
                {
                    return true;
                }
                else
                {
                    attempts--;
                    return false;
                }
            } 
            else if (attempts == 0)
            {
                confiscatedCards.Add(card);
                return false;
            }
            else
            {
                return false;
            }
        }

        // метод позволяющий "вставить" карту в банкомат
        public bool pushCard(string cardNumber)
        {
            if (centralBank.CheckAccountExist(cardNumber))
            {
                card = new BankCard(cardNumber);
                return true;
            }
            else
            {
                return false;
            }
        }

        // Проверка того что достаточно купюр чтобы выдать наличные

        // метод позволяющий снять наличные при условии
        // что достаточно купюр чтобы выдать наличные, если купюр недостаточно, вернет статус OPERATION_REJECTED
        public string WithdrawCash(double sum)
        {
            double initial_sum = sum;
            string outstr = "";
            int[] outNums = new int[7];
            double outSum = 0;
            checkInfo = $"Операция: Снятие наличных\n" +
                        $"сумма: {sum} руб.";
            for (int i = 0; i < nums.Length; i++)
            {
                while (sum >= nums[i][0] && nums[i][1] > 0)
                {
                    outSum += nums[i][0];
                    sum -= nums[i][0];
                    outNums[i] += 1;
                }
            }
            if (sum == 0 && centralBank.WithdrawalRequest(card.CardNumber, initial_sum))
            {
                for (int i = 0; i < nums.Length; i++)
                {
                    nums[i][1] -= outNums[i];
                }
                for (int i = 0; i < nums.Length; i++)
                {
                    if (outNums[i] > 0)
                    {
                        outstr += "Номинал " + nums[i][0] + "[" + outNums[i] + "]\n";
                    }
                }
                return outstr;
            }
            else
            {
                return OPERATION_REJECTED;
            }
        }

        // метод для получения текста справки
        public string getCheckInfo()
        {
            return $"Карта {card.CardNumber}\n{checkInfo} \nДата и время: {DateTime.Now}";
        }

        // метод для получения остатка на счету
        public double AccountBalance()
        {
            double balance = centralBank.getAccountBalance(card.CardNumber);
            checkInfo = $"Операция: Запрос баланса\n" +
            $"Текущий баланс: {balance} руб.";
            return balance;
        }

        // метод осуществления осуществить безналичного платежа
        public bool CashLessPayment(string accountNumber, double sum)
        {
            checkInfo = $"Операция: Перевод\n" +
                        $"Счет получателя: {accountNumber} \n" +
                        $"Сумма: {sum} руб.";
            if (centralBank.CheckAccountExist(accountNumber))
            {
                if (centralBank.WithdrawalRequest(card.CardNumber, sum))
                {
                    centralBank.ReplenishmentRequest(accountNumber, sum);
                    return true;
                } 
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        // метод для распознавания типа карты
        public string RecognizeCardType()
        {
            string first_four = card.CardNumber.Substring(0, 4);
            switch (first_four)
            {
                case "1111":
                    return "type1";
                case "2222":
                    return "type2";
                case "3333":
                    return "type3";
                case "4444":
                    return "type4";
                default:
                    return "type0";
            }
        }

        // метод для получения списка доступных операций в виде строки
        public string getOperationsList()
        {
            return "1. Снять наличные\n" +
                "2. Узнать остаток на счету\n" +
                "3. Осуществить безналичный платеж\n" +
                "4. Извлечь карту\n";
        }
    }
}
