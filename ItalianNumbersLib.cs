using System.Collections.Generic;
using System;

public class ItalianNumbersLib
{
    private static Dictionary<decimal, string> specificNumbers = new Dictionary<decimal, string>()
    {
        [0] = "Zero",
        [1] = "Uno",
        [2] = "Due",
        [3] = "Tre",
        [4] = "Quattro",
        [5] = "Cinque",
        [6] = "Sei",
        [7] = "Sette",
        [8] = "Otto",
        [9] = "Nove",
        [10] = "Dieci",
        [11] = "Undici",
        [12] = "Dodici",
        [13] = "Tredici",
        [14] = "Quattordici",
        [15] = "Quindici",
        [16] = "Sedici",
        [17] = "Diciassette",
        [18] = "Diciotto",
        [19] = "Diciannove",
        [20] = "Venti",
        [30] = "Trenta",
        [40] = "Quaranta",
        [50] = "Cinquanta",
        [60] = "Sessanta",
        [70] = "Settanta",
        [80] = "Ottanta",
        [90] = "Novanta"
    };

    private static List<Tuple<string, int>> romanNumbers = new List<Tuple<string, int>>()
    {
        new Tuple<string, int>("M", 1000),
        new Tuple<string, int>("CCC", 300),
        new Tuple<string, int>("CC", 200),
        new Tuple<string, int>("CD", 400),
        new Tuple<string, int>("CM", 900),
        new Tuple<string, int>("C", 100),
        new Tuple<string, int>("DCCC", 800),
        new Tuple<string, int>("DCC", 700),
        new Tuple<string, int>("DC", 600),
        new Tuple<string, int>("D", 500),
        new Tuple<string, int>("LXXX", 80),
        new Tuple<string, int>("LXX", 70),
        new Tuple<string, int>("LX", 60),
        new Tuple<string, int>("L", 50),
        new Tuple<string, int>("XC", 90),
        new Tuple<string, int>("XL", 40),
        new Tuple<string, int>("XXX", 30),
        new Tuple<string, int>("XX", 20),
        new Tuple<string, int>("X", 10),
        new Tuple<string, int>("IX", 9),
        new Tuple<string, int>("IV", 4),
        new Tuple<string, int>("VIII", 8),
        new Tuple<string, int>("VII", 7),
        new Tuple<string, int>("VI", 6),
        new Tuple<string, int>("V", 5),
        new Tuple<string, int>("IV", 4),
        new Tuple<string, int>("III", 3),
        new Tuple<string, int>("II", 2),
        new Tuple<string, int>("I", 1)
    };

    public static string ConvertNumberToItalianWords(decimal number)
    {
        string theNumber = number.ToString(), result = "", theDecimal = "";
        bool hasDecimal = false, isNegative = false;

        if (theNumber.Contains(","))
        {
            hasDecimal = true;
            string[] splitted = theNumber.Split(',');
            theNumber = splitted[0];
            theDecimal = splitted[1];
            number = decimal.Parse(theNumber);
        }

        if (theNumber.StartsWith("-"))
        {
            isNegative = true;
            theNumber = theNumber.Substring(1);
            number = decimal.Parse(theNumber);
        }

        int numberLength = theNumber.Length;

        if (numberLength == 1)
        {
            result = specificNumbers[number];
        }
        else if (numberLength == 2)
        {
            if ((number >= 10 && number <= 19) || number % 10 == 0)
            {
                result = specificNumbers[number];
            }
            else
            {
                string firstNumber = specificNumbers[decimal.Parse(theNumber[0].ToString() + "0")];
                string secondNumber = specificNumbers[decimal.Parse(theNumber[1].ToString())];

                if (secondNumber == "Uno" || secondNumber == "Otto")
                {
                    result = firstNumber.Substring(0, firstNumber.Length - 1) + secondNumber.ToLower();
                }
                else
                {
                    result = firstNumber + secondNumber.ToLower();
                }
            }
        }
        else if (numberLength == 3)
        {
            if (number == 100)
            {
                result = "Cento";
                goto finish;
            }

            if (number % 100 == 0)
            {
                string firstNumber = ConvertNumberToItalianWords(decimal.Parse(theNumber[0].ToString()));
                result = firstNumber + "cento";
                goto finish;
            }

            if (number >= 200)
            {
                string firstNumber = specificNumbers[decimal.Parse(theNumber[0].ToString())];
                string secondNumber = ConvertNumberToItalianWords(decimal.Parse(theNumber[1].ToString() + theNumber[2].ToString()));

                result = firstNumber + "cento" + secondNumber.ToLower();
            }
            else
            {
                string firstNumber = ConvertNumberToItalianWords(decimal.Parse(theNumber[1].ToString() + theNumber[2].ToString()));
                result = "Cento" + firstNumber.ToLower();
            }
        }
        else if (numberLength == 4)
        {
            if (number == 1000)
            {
                result = "Mille";
                goto finish;
            }

            if (number % 1000 == 0)
            {
                string firstNumber = specificNumbers[decimal.Parse(theNumber[0].ToString())];
                result = firstNumber + "mila";
                goto finish;
            }

            if (number >= 2000)
            {
                string firstNumber = specificNumbers[decimal.Parse(theNumber[0].ToString())];
                string secondNumber = ConvertNumberToItalianWords(decimal.Parse(theNumber.Substring(1)));

                result = firstNumber + "mila" + secondNumber.ToLower();
            }
            else
            {
                string firstNumber = ConvertNumberToItalianWords(decimal.Parse(theNumber.Substring(1)));
                result = "Mille" + firstNumber.ToLower();
            }
        }
        else if (numberLength == 5)
        {
            string firstNumber = ConvertNumberToItalianWords(decimal.Parse(theNumber[0].ToString() + theNumber[1].ToString()));

            if (number % 1000 == 0)
            {
                result = firstNumber + "mila";
                goto finish;
            }

            string secondNumber = ConvertNumberToItalianWords(decimal.Parse(theNumber[2].ToString() + theNumber[3].ToString() + theNumber[4].ToString()));
            result = firstNumber + "mila" + secondNumber.ToLower();
        }
        else if (numberLength == 6)
        {
            string firstNumber = ConvertNumberToItalianWords(decimal.Parse(theNumber[0].ToString() + theNumber[1].ToString() + theNumber[2].ToString()));

            if (number % 1000 == 0)
            {
                result = firstNumber + "mila";
                goto finish;
            }

            string secondNumber = ConvertNumberToItalianWords(decimal.Parse(theNumber[3].ToString() + theNumber[4].ToString() + theNumber[5].ToString()));
            result = firstNumber + "mila" + secondNumber.ToLower();
        }
        else if (numberLength == 7)
        {
            string firstNumber = specificNumbers[decimal.Parse(theNumber[0].ToString())];
            string theOther = " milioni ";

            if (firstNumber == "Uno")
            {
                firstNumber = "Un";
                theOther = " milione ";
            }

            if (number % 1000000 == 0)
            {
                result = firstNumber + theOther;
                goto finish;
            }

            string secondNumber = ConvertNumberToItalianWords(decimal.Parse(theNumber.Substring(1)));
            result = firstNumber + theOther + secondNumber.ToLower();
        }
        else if (numberLength == 8)
        {
            string firstNumber = ConvertNumberToItalianWords(decimal.Parse(theNumber[0].ToString() + theNumber[1].ToString()));
            decimal otherNumber = decimal.Parse(theNumber.Substring(2));

            if (otherNumber == 0)
            {
                result = firstNumber + " milioni";
                goto finish;
            }

            string secondNumber = ConvertNumberToItalianWords(otherNumber);
            result = firstNumber + " milioni " + secondNumber.ToLower();
        }
        else if (numberLength == 9)
        {
            string firstNumber = ConvertNumberToItalianWords(decimal.Parse(theNumber[0].ToString() + theNumber[1].ToString() + theNumber[2].ToString()));
            decimal otherNumber = decimal.Parse(theNumber.Substring(3));

            if (otherNumber == 0)
            {
                result = firstNumber + " milioni";
                goto finish;
            }

            string secondNumber = ConvertNumberToItalianWords(otherNumber);
            result = firstNumber + " milioni " + secondNumber.ToLower();
        }
        else if (numberLength == 10)
        {
            string firstNumber = specificNumbers[decimal.Parse(theNumber[0].ToString())];
            string theOther = " miliardi ";

            if (firstNumber == "Uno")
            {
                firstNumber = "Un";
                theOther = " miliardo ";
            }

            if (number % 1000000000 == 0)
            {
                result = firstNumber + theOther;
                goto finish;
            }

            string secondNumber = ConvertNumberToItalianWords(decimal.Parse(theNumber.Substring(1)));
            result = firstNumber + theOther + secondNumber.ToLower();
        }
        else if (numberLength == 11)
        {
            string firstNumber = ConvertNumberToItalianWords(decimal.Parse(theNumber[0].ToString() + theNumber[1].ToString()));
            decimal otherNumber = decimal.Parse(theNumber.Substring(2));

            if (otherNumber == 0)
            {
                result = firstNumber + " miliardi";
                goto finish;
            }

            string secondNumber = ConvertNumberToItalianWords(otherNumber);
            result = firstNumber + " miliardi " + secondNumber.ToLower();
        }
        else if (numberLength == 12)
        {
            string firstNumber = ConvertNumberToItalianWords(decimal.Parse(theNumber[0].ToString() + theNumber[1].ToString() + theNumber[2].ToString()));
            decimal otherNumber = decimal.Parse(theNumber.Substring(3));

            if (otherNumber == 0)
            {
                result = firstNumber + " miliardi";
                goto finish;
            }

            string secondNumber = ConvertNumberToItalianWords(otherNumber);
            result = firstNumber + " miliardi " + secondNumber.ToLower();
        }
        else if (numberLength == 13)
        {
            string firstNumber = specificNumbers[decimal.Parse(theNumber[0].ToString())];
            string theOther = " trilioni ";

            if (firstNumber == "Uno")
            {
                firstNumber = "Un";
                theOther = " trilione ";
            }

            if (number % 1000000000000 == 0)
            {
                result = firstNumber + theOther;
                goto finish;
            }

            string secondNumber = ConvertNumberToItalianWords(decimal.Parse(theNumber.Substring(1)));
            result = firstNumber + theOther + secondNumber.ToLower();
        }
        else if (numberLength == 14)
        {
            string firstNumber = ConvertNumberToItalianWords(decimal.Parse(theNumber[0].ToString() + theNumber[1].ToString()));
            decimal otherNumber = decimal.Parse(theNumber.Substring(2));

            if (otherNumber == 0)
            {
                result = firstNumber + " trilioni";
                goto finish;
            }

            string secondNumber = ConvertNumberToItalianWords(otherNumber);
            result = firstNumber + " trilioni " + secondNumber.ToLower();
        }
        else if (numberLength == 15)
        {
            string firstNumber = ConvertNumberToItalianWords(decimal.Parse(theNumber[0].ToString() + theNumber[1].ToString() + theNumber[2].ToString()));
            decimal otherNumber = decimal.Parse(theNumber.Substring(3));

            if (otherNumber == 0)
            {
                result = firstNumber + " trilioni";
                goto finish;
            }

            string secondNumber = ConvertNumberToItalianWords(otherNumber);
            result = firstNumber + " trilioni " + secondNumber.ToLower();
        }

        if (isNegative)
        {
            result = "Meno " + result.ToLower();
        }

    finish: if (hasDecimal)
        {
            string theDecimalNumber = "";

            while (theDecimal.StartsWith("0"))
            {
                if (theDecimalNumber == "")
                {
                    theDecimalNumber = "zero";
                }
                else
                {
                    theDecimalNumber += " zero";
                }

                theDecimal = theDecimal.Substring(1);
            }

            if (theDecimalNumber == "")
            {
                theDecimalNumber = ConvertNumberToItalianWords(decimal.Parse(theDecimal));
            }
            else
            {
                theDecimalNumber += " " + ConvertNumberToItalianWords(decimal.Parse(theDecimal));
            }

            return result + " virgola " + theDecimalNumber.ToLower();
        }
        else
        {
            return result;
        }

        throw new Exception("Invalid number");
    }

    public static int ConvertRomanNumberToDecimal(string number)
    {
        int result = 0;

        while (number.Length > 0)
        {
            foreach (Tuple<string, int> theTuple in romanNumbers)
            {
                if (number.StartsWith(theTuple.Item1))
                {
                    result += theTuple.Item2;
                    number = number.Substring(theTuple.Item1.Length);
                    break;
                }
            }
        }

        return result;
    }
}