namespace ATMApp
{
    // ����� ���������� �� ���������������� ��������� ���������
    public partial class FormATM : Form
    {
        // ��������� ��������� � ���������� ������� ������
        private ATM atm;

        //��������� ����������� ��� ��������� �������� �������� ���������:
        // ��������� "�������� �����"
        private const int CONDITION_WAIT_CARD = 0;
        // ��������� "����� �������"
        private const int CONDITION_CHOOSE = 1;
        // ��������� "����� �������� ��� �� �������� ������� � ��������"
        private const int CONDITION_CHECK_CHOOSE = 2;
        // ��������� "���� ����� ������"
        private const int CONDITION_CASH_SUM_INPUT = 3;
        // ��������� "������ �����"
        private const int CONDITION_CASH_OUT = 4;
        // ��������� "���������� �����"
        private const int CONDITION_OUT_CARD = 5;
        // ��������� "����� �������"
        private const int CONDITION_SHOW_BALANCE = 6;
        // ��������� "���� ������ ����� ��� ������������ ��������"
        private const int CONDITION_WIRE_TRANSFER_ACCOUNT_INPUT = 7;
        // ��������� "���� ����� ��� ������������ ��������"
        private const int CONDITION_WIRE_TRANSFER_SUM_INPUT = 8;
        // ��������� "����������� �������"
        private const int CONDITION_WIRE_TRANSFER_COMPLETE = 9;
        // ��������� "���� PIN-����"
        private const int CONDITION_ENTER_PIN = 10;
        // ��������� "�������� PIN-����"
        private const int CONDITION_CHECK_PIN = 11;

        // ������ ��� �������� ����������������� �����
        private string userInput;
        // ������� ��������� ���������
        private int condition;
        // ��������� ��������� ���������
        private int nextCondition;
        // ����� �� ������� ���������
        private string displayText;
        // ��������� �� ������� ���������
        private string displayMessage;
        // ���������� ��� �������� ���������� � ��� ����� �� �������� ���
        bool printCheck;
        // ���������� ��� �������� �������� ���������� � ����� ��� ��������
        string tempInputWireAcc;
        // ���������� ������ ���������� � ��� ��������� �� �����
        private bool cardIn;
        // ���������� ������ ���������� � ��� �������� �� PIN ���
        private bool pinChecked;

        // ����������� ������ ����������������� ����������
        // � ������������ ���������������� ������ ��������� � ���������� �������
        // � ����� ���������� ���������
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

        // ������� ����������� �������� � ����������� �� ������ ����������� ��������� ���������
        // � ����������� �� �������� ��������� condition �������������� ����-����� 
        // ��� ������ ������ ���������� � ������ ��������� � ����� ������������ �����
        // �����������
        private void updateState()
        {
            if (condition != CONDITION_WAIT_CARD)
            {
                labelStatus.Text = "����� � ���������";
            }
            else
            {
                if (labelStatus.Text != "����� � ���������")
                {
                    labelStatus.Text = "��� �����";
                }
            }
            if (condition == CONDITION_WAIT_CARD)
            {
                displayText = "������������! �������� ����� � �������� ��� ������ ������!";
            }
            switch (condition)
            {
                case CONDITION_ENTER_PIN:
                    {
                        if (displayMessage != "�������� PIN ���, ���������� ��� ���:\n")
                        {
                            displayMessage = "������� PIN-��� � ������� '����':\n";
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
                            displayMessage = "�������� PIN ���, ���������� ��� ���:\n";
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
                            if (displayMessage != "�������� PIN ���, ���������� ��� ���:\n")
                            {
                                displayMessage = "������� PIN-��� � ������� '����':\n";
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
                                displayMessage = "�������� PIN ���, ���������� ��� ���:\n";
                                displayText = displayMessage;
                                condition = CONDITION_ENTER_PIN;
                                userInput = "";
                            }
                            break;
                        }
                    case CONDITION_CHOOSE:
                        {
                            displayText = "�������� ��������:\n"
                                + atm.getOperationsList();
                            //printOperationCheck();
                            break;
                        }
                    case CONDITION_CASH_SUM_INPUT:
                        {
                            displayMessage = "������� ����� ��� ������ � ������� '����':\n";
                            displayText = displayMessage + userInput;
                            break;
                        }
                    case CONDITION_CHECK_CHOOSE:
                        {
                            displayText = "�������� ������� � ��������? (1 ���� ��, 2 ���� ���)";
                            break;
                        }
                    case CONDITION_OUT_CARD:
                        {
                            buttonEject.Enabled = true;
                            displayText = "������ �����";
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
                                displayText = "�������� ������ �� �����";
                                richTextBoxCashOut.Text = cash_out_msg;
                                printOperationCheck();
                            }
                            break;
                        }
                    case CONDITION_SHOW_BALANCE:
                        {
                            displayText = "������� �� �����: " + atm.AccountBalance() + "\n�������� ������� � ��������? (1 ���� ��, 2 ���� ���)\n������� '������' ��� ������ ������ ��������\n";
                            condition = CONDITION_CHECK_CHOOSE;
                            nextCondition = CONDITION_SHOW_BALANCE;
                            userInput = "";
                            printOperationCheck();
                            break;
                        }
                    case CONDITION_WIRE_TRANSFER_ACCOUNT_INPUT:
                        {
                            displayMessage = "������� ����� ����� ��� �������� � ������� '����':\n";
                            displayText = displayMessage + tempInputWireAcc + userInput;
                            tempInputWireAcc += userInput;
                            userInput = "";
                            break;
                        }
                    case CONDITION_WIRE_TRANSFER_SUM_INPUT:
                        {
                            displayMessage = "����� �����:\n" + tempInputWireAcc + "\n������� ����� � ������� ����:\n";
                            displayText = displayMessage + userInput;
                            break;
                        }
                    case CONDITION_WIRE_TRANSFER_COMPLETE:
                        try
                        {
                            double sum = Convert.ToDouble(userInput);
                            if (atm.CashLessPayment(tempInputWireAcc, sum))
                            {
                                displayText = "������� ������� ���������! ������� '������' ����� ��������� � ������ ��������";
                                printOperationCheck();
                            }
                            else
                            {
                                displayText = "�� ������� ��������� �������! ������� '������' ����� ��������� � ������ ��������";
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

        // ������� ��������� ������� �� ������ "����" ������ ����������
        // ������� �������� ����� �� ������ ��������� ������� ���
        // � ����������� �� �������� ��������� condition �������������� ����-����� 
        // ��� ������ ������ ���������� � ������ ���������
        // ����� �������������� ������������ ����� �����������
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
                            labelStatus.Text = "����� � ���������";
                        }
                        break;
                    }
            }
            updateState();
        }

        // ������� ��������� ������� �� ������ "������" ������ ����������
        // ���������� �������� � ��������� ������ �������
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            userInput = "";
            condition = CONDITION_CHOOSE;
            updateState();
        }

        // ������� ��������� ������� �� ������ "1" ������ ����������
        // ������� �������� �� ������� ����� ������ ��������� ������� ���
        // � ����������� �� �������� ��������� condition �������������� ����-����� 
        // ��� ������ ������ ���������� � ������ ���������
        // ����� �������������� ������������ ����� �����������
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

        // ������� ��������� ������� �� ������ "2" ������ ����������
        // ������� �������� �� ������� ����� ������ ��������� ������� ���
        // � ����������� �� �������� ��������� condition �������������� ����-����� 
        // ��� ������ ������ ���������� � ������ ���������
        // ����� �������������� ������������ ����� �����������
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

        // ������� ��������� ������� �� ������ "3" ������ ����������
        // ������� �������� �� ������� ����� ������ ��������� ������� ���
        // � ����������� �� �������� ��������� condition �������������� ����-����� 
        // ��� ������ ������ ���������� � ������ ���������
        // ����� �������������� ������������ ����� �����������
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

        // ������� ��������� ������� �� ������ "4" ������ ����������
        // ������� �������� �� ������� ����� ������ ��������� ������� ���
        // � ����������� �� �������� ��������� condition �������������� ����-����� 
        // ��� ������ ������ ���������� � ������ ���������
        // ����� �������������� ������������ ����� �����������
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

        // ������� ��������� ������� �� ������ "5" ������ ����������
        // ������� �������� �� ������� ����� ������ ��������� ������� 
        private void button5_Click(object sender, EventArgs e)
        {
            userInput += "5";
            updateState();
        }

        // ������� ��������� ������� �� ������ "6" ������ ����������
        // ������� �������� �� ������� ����� ������ ��������� ������� 
        private void button6_Click(object sender, EventArgs e)
        {
            userInput += "6";
            updateState();
        }

        // ������� ��������� ������� �� ������ "7" ������ ����������
        // ������� �������� ����� �� ������ ��������� ������� 
        private void button7_Click(object sender, EventArgs e)
        {
            userInput += "7";
            updateState();
        }

        // ������� ��������� ������� �� ������ "8" ������ ����������
        // ������� �������� �� ������� ����� ������ ��������� ������� 
        private void button8_Click(object sender, EventArgs e)
        {
            userInput += "8";
            updateState();
        }

        // ������� ��������� ������� �� ������ "9" ������ ����������
        // ������� �������� �� ������� ����� ������ ��������� ������� 
        private void button9_Click(object sender, EventArgs e)
        {
            userInput += "9";
            updateState();
        }

        // ������� ��������� ������� �� ������ "0" ������ ����������
        // ������� �������� �� ������� ����� ������ ��������� ������� 
        private void button0_Click(object sender, EventArgs e)
        {
            userInput += "0";
            updateState();
        }

        // ������� ��������� ������� �� ������ "000" ������ ����������
        // ������� �������� �� ������� ����� ������ ��������� ������� 
        private void button000_Click(object sender, EventArgs e)
        {
            userInput += "000";
            updateState();
        }

        // ������� ��������� ������� �� ������ "�������� �����"
        // �������� �� "�������" ����� � ��������,
        // ����� �������� ��� ����� ���������� ��� ������ ������ pushCard ������ ATM
        // ����� �������� �� ���������� ����� ������� ��� ����� PIN ����
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
                displayText = "����� �� �������������!";
                showOnDisplay(displayText);
            }
        }

        // ������� ��� ������ ��������� � ���� ������ ���������
        private void showOnDisplay(string message)
        {
            richTextBoxDisplay.Text = message;
        }

        // ������� ��� ������ ������� � ���� ������� ���������
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

        // ������� ��� ���������� ����� �� ���������
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

        // ������� ��� ���������� ����� �� ���������
        private void buttonCashOut_Click(object sender, EventArgs e)
        {
            richTextBoxCashOut.Text = "";
            updateState();
        }

        // ������� ��������� ������� �� ������ "-" ������ ����������
        private void button10_Click(object sender, EventArgs e)
        {
            userInput += "-";
            updateState();
        }
    }
}