using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointerSurvival
{
    class Calculation
    {

        public static Random random = new Random();

        public const int Plus = -1;
        public const int Minus = -2;
        public const int Multiply = -3;
        public const int UnknownOp = 0;
        /*var rnd = new Random();
        var userScore = 0;
        var totalProblems = 0;
        var percentCorrect = 0d;

        var number1 = rnd.Next(1, 31);
        var number2 = rnd.Next(1, 31);
        var operation = rnd.Next(1, 5);
        string operatorString;
        int answer;*/
        public Calculation()
        {
            num1 = 0;
            num2 = 0;
            opnum = 0;
        }

        private int answer=10;

        public int getAnswer
        {
            get { return answer; }
            set { answer = value; }
        }

        private int num1;

        public int getNum1
        {
            get { return num1; }
            set { num1 = value; }
        }

        private int num2;

        public int getNum2
        {
            get { return num2; }
            set { num2 = value; }
        }

        private String symbol;

        public string getSymbol
        {
            get { return symbol; }
            set { symbol = value; }
        }

        private int operatorsign;

        public int opnum                                    
        {
            get { return operatorsign; }
            set { operatorsign = value; }
        }

        private int score;

        public int getScore
        {
            get { return score; }
            set { score = value; }
        }


        public bool checkans(int ans)
        {
            string operatorString;
            //int i = 1;
            switch (operatorsign)
            {
                case 0:
                    symbol = "?";
                    break;
                case 1:
                    answer = num1 + num2;
                    operatorString = "+";
                    symbol = operatorString;
                    //op = operatorsign;
                    if (ans == answer) {
                        score++;
                        return true;
                    } 
                    break;
                case 2:
                    answer = num1 - num2;
                    operatorString = "-";
                    symbol = operatorString;
                    //op = operatorsign;
                    if (ans == answer)
                    {
                        score++;
                        return true;
                    }
                    break;
                case 3:
                    answer = num1 * num2;
                    operatorString = "*";
                    symbol = operatorString;
                    //op = operatorsign;
                    if (ans == answer)
                    {
                        score++;
                        return true;
                    }
                    break;
                case 4:
                    if(num2!=0)
                        answer = num1 / num2;
                    operatorString = "/";
                    symbol = operatorString;
                    //op = operatorsign;
                    if (ans == answer)
                    {
                        score++;
                        return true;
                    }
                    break; 

            }
            return false;
        }


        private int count = 1;
        public void storevalue(int rnum)
        {
            if (rnum > 0)
            {
                switch (count)
                {
                    case 1:
                        num1 = rnum;
                        count++;
                        break;

                    case 2:
                        num2 = rnum;
                        count--;
                        break;
                }
            }else {
                switch (rnum)
                {
                    // case0 = reset fn
                    case 0:
                        num1 = 0;
                        num2 = 0;
                        operatorsign = 0;
                        answer = 0;
                        symbol = " ";
                        score = 0;
                        break;
                    case -1:
                        operatorsign = 1;
                        break;
                    case -2:
                        operatorsign = 2;
                        break;
                    case -3:
                        operatorsign = 3;
                        break;
                    case -4:
                        operatorsign = 4;
                        break;
                }
            }
        }

        public static string ConvertBase(int value, char[] baseChars)
        {
            string result = string.Empty;
            int targetBase = baseChars.Length;

            do
            {
                result = baseChars[value % targetBase] + result;
                value = value / targetBase;
            }

            while (value > 0);

            return result;
        }

    }
}
