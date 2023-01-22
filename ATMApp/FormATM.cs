namespace ATMApp
{
    // класс отвечающий за пользовательский интерфейс банкомата
    public partial class FormATM : Form
    {
        // экземляра банкомата с внутренней логикой работы
        private ATM atm;

        //константы применяемые для изменения текущего состония банкомата:
        // состояние "ожидание карты"
        private const int CONDITION_WAIT_CARD = 0;
        // состояние "выбор дествия"
        private const int CONDITION_CHOOSE = 1;
        // состояние "выбор печатать или не печатать справку о операции"
        private const int CONDITION_CHECK_CHOOSE = 2;
        // состояние "ввод суммы снятия"
        private const int CONDITION_CASH_SUM_INPUT = 3;
        // состояние "снятие денег"
        private const int CONDITION_CASH_OUT = 4;
        // состояние "извлечение карты"
        private const int CONDITION_OUT_CARD = 5;
        // состояние "вывод баланса"
        private const int CONDITION_SHOW_BALANCE = 6;
        // состояние "ввод номера счета для безналичного перевода"
        private const int CONDITION_WIRE_TRANSFER_ACCOUNT_INPUT = 7;
        // состояние "ввод суммы для безналичного перевода"
        private const int CONDITION_WIRE_TRANSFER_SUM_INPUT = 8;
        // состояние "безналичный перевод"
        private const int CONDITION_WIRE_TRANSFER_COMPLETE = 9;
        // состояние "ввод PIN-кода"
        private const int CONDITION_ENTER_PIN = 10;
        // состояние "Проверка PIN-кода"
        private const int CONDITION_CHECK_PIN = 11;

        // строка для хранения пользовательского ввода
        private string userInput;
        // текущее состояние банкомата
        private int condition;
        // следующее состояние банкомата
        private int nextCondition;
        // текст на дисплее банкомата
        private string displayText;
        // сообщение на дисплее банкомата
        private string displayMessage;
        // переменная для хранения информации о том нужно ли печатать чек
        bool printCheck;
        // переменная для хранения временно информации о счете для перевода
        string tempInputWireAcc;
        // переменная хранит информацию о том вставлена ли карта
        private bool cardIn;
        // переменная хранит информацию о том проверен ли PIN код
        private bool pinChecked;

        // конструктор класса пользовательского интерфейса
        // в конструкторе инициализируется объект банкомата с внутренней логикой
        // а также переменные состояния
        public FormATM()
        {
            InitializeComponent();
            atm = new ATM(5, 5, 5, 5, 5, 5, 5);
            printCheck = false;
            cardIn = false;
            pinChecked = false;
            condition = CONDITION_WAIT_CARD;
            nextCondition = CONDITION_WAIT_CARD;
            updateState();
        }

        // функция совершающая действия в зависимости от нового измененного состояния банкомата
        // в зависимости от текущего состояния condition осуществляется ввод-вывод 
        // при помощи панели управления и дислея банкомата а также переключение между
        // состояниями
        private void updateState()
        {
            if (condition != CONDITION_WAIT_CARD)
            {
                labelStatus.Text = "Карта в приемнике";
            }
            else
            {
                if (labelStatus.Text != "Карта в хранилище")
                {
                    labelStatus.Text = "Нет карты";
                }
            }
            if (condition == CONDITION_WAIT_CARD)
            {
                displayText = "Здравствуйте! Вставьте карту в приемник для начала работы!";
            }
            switch (condition)
            {
                case CONDITION_ENTER_PIN:
                    {
                        if (displayMessage != "Неверный PIN код, попробуйте еще раз:\n")
                        {
                            displayMessage = "Введите PIN-код и нажмите 'ВВОД':\n";
                        }
                        string stars = "";
                        foreach(char ch in userInput)
                        {
                            stars += "*";
                        }
                        displayText = displayMessage + stars;
                        break;
                    }
                case CONDITION_CHECK_PIN:
                    {
                        if (atm.checkPIN(userInput))
                        {
                            condition = CONDITION_CHOOSE;
                            pinChecked = true;
                            userInput = "";
                        }
                        else
                        {
                            displayMessage = "Неверный PIN код, попробуйте еще раз:\n";
                            displayText = displayMessage;
                            condition = CONDITION_ENTER_PIN;
                            userInput = "";
                        }
                        break;
                    }
            }
            if (cardIn && pinChecked)
            {
                switch (condition)
                {
                    case CONDITION_ENTER_PIN:
                        {
                            if (displayMessage != "Неверный PIN код, попробуйте еще раз:\n")
                            {
                                displayMessage = "Введите PIN-код и нажмите 'ВВОД':\n";
                            }
                            displayText = displayMessage + userInput;
                            break;
                        }
                    case CONDITION_CHECK_PIN:
                        {
                            if (atm.checkPIN(userInput))
                            {
                                condition = CONDITION_CHOOSE;
                                pinChecked = true;
                            }
                            else
                            {
                                displayMessage = "Неверный PIN код, попробуйте еще раз:\n";
                                displayText = displayMessage;
                                condition = CONDITION_ENTER_PIN;
                                userInput = "";
                            }
                            break;
                        }
                    case CONDITION_CHOOSE:
                        {
                            displayText = "Выберите операцию:\n"
                                + atm.getOperationsList();
                            //printOperationCheck();
                            break;
                        }
                    case CONDITION_CASH_SUM_INPUT:
                        {
                            displayMessage = "Введите сумму для снятия и нажмите 'ВВОД':\n";
                            displayText = displayMessage + userInput;
                            break;
                        }
                    case CONDITION_CHECK_CHOOSE:
                        {
                            displayText = "Печатать справку о операции? (1 если да, 2 если нет)";
                            break;
                        }
                    case CONDITION_OUT_CARD:
                        {
                            buttonEject.Enabled = true;
                            displayText = "Выньте карту";
                            break;
                        }
                    case CONDITION_CASH_OUT:
                        {
                            string cash_out_msg = atm.WithdrawCash(Convert.ToDouble(userInput));
                            if (cash_out_msg == ATM.OPERATION_REJECTED)
                            {
                                displayText = ATM.OPERATION_REJECTED;
                            }
                            else
                            {
                                displayText = "Заберите деньги из лотка";
                                richTextBoxCashOut.Text = cash_out_msg;
                                printOperationCheck();
                            }
                            break;
                        }
                    case CONDITION_SHOW_BALANCE:
                        {
                            displayText = "Остаток на счету: " + atm.AccountBalance() + "\nПечатать справку о операции? (1 если да, 2 если нет)\nНажмите 'ОТМЕНА' для выбора другой операции\n";
                            condition = CONDITION_CHECK_CHOOSE;
                            nextCondition = CONDITION_SHOW_BALANCE;
                            userInput = "";
                            printOperationCheck();
                            break;
                        }
                    case CONDITION_WIRE_TRANSFER_ACCOUNT_INPUT:
                        {
                            displayMessage = "Введите номер счета для перевода и нажмите 'ВВОД':\n";
                            displayText = displayMessage + tempInputWireAcc + userInput;
                            tempInputWireAcc += userInput;
                            userInput = "";
                            break;
                        }
                    case CONDITION_WIRE_TRANSFER_SUM_INPUT:
                        {
                            displayMessage = "Номер счета:\n" + tempInputWireAcc + "\nВведите сумму и нажмите ввод:\n";
                            displayText = displayMessage + userInput;
                            break;
                        }
                    case CONDITION_WIRE_TRANSFER_COMPLETE:
                        try
                        {
                            double sum = Convert.ToDouble(userInput);
                            if (atm.CashLessPayment(tempInputWireAcc, sum))
                            {
                                displayText = "Перевод успешно отправлен! Нажмите 'ОТМЕНА' чтобы вернуться к выбору операции";
                                printOperationCheck();
                            }
                            else
                            {
                                displayText = "Не удалось отправить перевод! Нажмите 'ОТМЕНА' чтобы вернуться к выбору операции";
                                printCheck = false;
                            }
                            userInput = "";
                            tempInputWireAcc = "";
                        }
                        catch
                        {
                            displayText = ATM.OPERATION_REJECTED;
                            userInput = "";
                            tempInputWireAcc = "";
                            printCheck = false;
                        }
                        break;
                }
            }
            showOnDisplay(displayText);
        }

        // функция обработки нажатия на кнопку "ВВОД" панели управления
        // функция печатает текст на кнопке вызвавшей функцию или
        // в зависимости от текущего состояния condition осуществляется ввод-вывод 
        // при помощи панели управления и дислея банкомата
        // также осуществляется переключение между состояниями
        private void buttonEnter_Click(object sender, EventArgs e)
        {
            switch (condition)
            {
                case CONDITION_CASH_SUM_INPUT:
                    {
                        condition = CONDITION_CHECK_CHOOSE;
                        nextCondition = CONDITION_OUT_CARD;
                        break;
                    }
                case CONDITION_WIRE_TRANSFER_ACCOUNT_INPUT:
                    {
                        condition = CONDITION_WIRE_TRANSFER_SUM_INPUT;
                        break;
                    }
                case CONDITION_WIRE_TRANSFER_SUM_INPUT:
                    {
                        condition = CONDITION_CHECK_CHOOSE;
                        nextCondition = CONDITION_WIRE_TRANSFER_COMPLETE;
                        break;
                    }
                case CONDITION_ENTER_PIN:
                    {
                        condition = CONDITION_CHECK_PIN;
                        updateState();
                        if (atm.getAttempts() == 0)
                        {
                            condition = CONDITION_WAIT_CARD;
                            cardIn = false;
                            labelStatus.Text = "Карта в хранилище";
                        }
                        break;
                    }
            }
            updateState();
        }

        // функция обработки нажатия на кнопку "ОТМЕНА" панели управления
        // сбрасывает банкомат к состоянию выбора дествия
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            userInput = "";
            condition = CONDITION_CHOOSE;
            updateState();
        }

        // функция обработки нажатия на кнопку "1" панели управления
        // функция печатает на дисплее текст кнопки вызвавшей функцию или
        // в зависимости от текущего состояния condition осуществляется ввод-вывод 
        // при помощи панели управления и дислея банкомата
        // также осуществляется переключение между состояниями
        private void button1_Click(object sender, EventArgs e)
        {
            if (condition != CONDITION_CHOOSE)
            {
                if (condition != CONDITION_CHECK_CHOOSE)
                {
                    userInput += "1";
                }
                else
                {
                    condition = nextCondition;
                    printCheck = true;
                }
            }
            else
            {
                condition = CONDITION_CASH_SUM_INPUT;
            }
            updateState();
        }

        // функция обработки нажатия на кнопку "2" панели управления
        // функция печатает на дисплее текст кнопки вызвавшей функцию или
        // в зависимости от текущего состояния condition осуществляется ввод-вывод 
        // при помощи панели управления и дислея банкомата
        // также осуществляется переключение между состояниями
        private void button2_Click(object sender, EventArgs e)
        {
            if (condition != CONDITION_CHOOSE)
            {
                if (condition != CONDITION_CHECK_CHOOSE)
                {
                    userInput += "2";
                }
                else
                {
                    condition = nextCondition;
                }
            }
            else
            {
                condition = CONDITION_SHOW_BALANCE;
            }
            updateState();
        }

        // функция обработки нажатия на кнопку "3" панели управления
        // функция печатает на дисплее текст кнопки вызвавшей функцию или
        // в зависимости от текущего состояния condition осуществляется ввод-вывод 
        // при помощи панели управления и дислея банкомата
        // также осуществляется переключение между состояниями
        private void button3_Click(object sender, EventArgs e)
        {
            if (condition != CONDITION_CHOOSE)
            {
                userInput += "3";
            }
            else
            {
                condition = CONDITION_WIRE_TRANSFER_ACCOUNT_INPUT;
            }
            updateState();
        }

        // функция обработки нажатия на кнопку "4" панели управления
        // функция печатает на дисплее текст кнопки вызвавшей функцию или
        // в зависимости от текущего состояния condition осуществляется ввод-вывод 
        // при помощи панели управления и дислея банкомата
        // также осуществляется переключение между состояниями
        private void button4_Click(object sender, EventArgs e)
        {
            if (condition != CONDITION_CHOOSE)
            {
                userInput += "4";
            }
            else
            {
                condition = CONDITION_WAIT_CARD;
                buttonEject.Enabled = true;
                cardIn = false;
            }
            updateState();
        }

        // функция обработки нажатия на кнопку "5" панели управления
        // функция печатает на дисплее текст кнопки вызвавшей функцию 
        private void button5_Click(object sender, EventArgs e)
        {
            userInput += "5";
            updateState();
        }

        // функция обработки нажатия на кнопку "6" панели управления
        // функция печатает на дисплее текст кнопки вызвавшей функцию 
        private void button6_Click(object sender, EventArgs e)
        {
            userInput += "6";
            updateState();
        }

        // функция обработки нажатия на кнопку "7" панели управления
        // функция печатает текст на кнопке вызвавшей функцию 
        private void button7_Click(object sender, EventArgs e)
        {
            userInput += "7";
            updateState();
        }

        // функция обработки нажатия на кнопку "8" панели управления
        // функция печатает на дисплее текст кнопки вызвавшей функцию 
        private void button8_Click(object sender, EventArgs e)
        {
            userInput += "8";
            updateState();
        }

        // функция обработки нажатия на кнопку "9" панели управления
        // функция печатает на дисплее текст кнопки вызвавшей функцию 
        private void button9_Click(object sender, EventArgs e)
        {
            userInput += "9";
            updateState();
        }

        // функция обработки нажатия на кнопку "0" панели управления
        // функция печатает на дисплее текст кнопки вызвавшей функцию 
        private void button0_Click(object sender, EventArgs e)
        {
            userInput += "0";
            updateState();
        }

        // функция обработки нажатия на кнопку "000" панели управления
        // функция печатает на дисплее текст кнопки вызвавшей функцию 
        private void button000_Click(object sender, EventArgs e)
        {
            userInput += "000";
            updateState();
        }

        // функция обработки нажатия на кнопку "Вставить карту"
        // отвечает за "вставку" карты в банкомат,
        // вызов проверки что карта существует при помощи метода pushCard класса ATM
        // также отвечает за обновление числа попыток для ввода PIN кода
        private void buttonPushCard_Click(object sender, EventArgs e)
        {
            string cardNumber = textBoxCardNumber.Text;
            if (atm.pushCard(cardNumber))
            {
                userInput = "";
                cardIn = true;
                condition = CONDITION_ENTER_PIN;
                atm.updateAttemptsNumber();
                updateState();
            }
            else
            {
                displayText = "Карта не обслуживается!";
                showOnDisplay(displayText);
            }
        }

        // функция для вывода сообщения в поле дислея банкомата
        private void showOnDisplay(string message)
        {
            richTextBoxDisplay.Text = message;
        }

        // функция для печати справки в поле справки банкомата
        private void printOperationCheck()
        {
            if (printCheck)
            {
                richTextBoxCheck.Text += $"-------------------------------\n" +
                                        $"{atm.getCheckInfo()}\n" +
                                        $"-------------------------------\n";
            }
            printCheck = false;
        }

        // функция для извлечения карты из банкомата
        private void buttonEject_Click(object sender, EventArgs e)
        {
            if (condition == CONDITION_OUT_CARD)
            {
                condition = CONDITION_CASH_OUT;
                updateState();
            }
            buttonEject.Enabled = false;
            condition = CONDITION_WAIT_CARD;
            cardIn = false;
            pinChecked = false;
        }

        // функция для извлечения денег из банкомата
        private void buttonCashOut_Click(object sender, EventArgs e)
        {
            richTextBoxCashOut.Text = "";
            updateState();
        }

        // функция обработки нажатия на кнопку "-" панели управления
        private void button10_Click(object sender, EventArgs e)
        {
            userInput += "-";
            updateState();
        }
    }
}