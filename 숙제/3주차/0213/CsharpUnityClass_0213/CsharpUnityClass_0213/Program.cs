using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CsharpUnityClass_0213
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Zodiac zodiac = new Zodiac();
            zodiac.AgeInput();
            Console.WriteLine($"{zodiac.ZodiacCalculation()}띠\t{zodiac.age}세\n");

            Calculator calculator = new Calculator();
            calculator.Input();
            calculator.CalculationOutput();

        }
    }

    class Zodiac
    {
        public int age;

        public void AgeInput()
        {
            Console.Write("나이를 입력해 주세요: ");
            age = Convert.ToInt32(Console.ReadLine());
        }
        public string ZodiacCalculation()
        {
            switch ((2024 - age) % 12)
            {
                case 0:
                    return "원숭이";
                case 1:
                    return "닭";
                case 2:
                    return "개";
                case 3:
                    return "돼지";
                case 4:
                    return "쥐";
                case 5:
                    return "소";
                case 6:
                    return "호랑이";
                case 7:
                    return "토끼";
                case 8:
                    return "용";
                case 9:
                    return "뱀";
                case 10:
                    return "말";
                default:
                    return "양";
            }
        }
    }

    class Calculator
    {
        public int number1;
        public int number2;
        public string numOperator;

        public void Input()
        {
            Console.WriteLine("숫자 2개와 연산시호를 입력해주세요.");
            number1 = Convert.ToInt32(Console.ReadLine());
            number2 = Convert.ToInt32(Console.ReadLine());
            numOperator = Console.ReadLine();
        }
        public void CalculationOutput()
        {
            switch (numOperator)
            {
                case "+":
                    Console.WriteLine($"{number1} + {number2} = {number1 + number2}");
                    break;
                case "-":
                    Console.WriteLine($"{number1} - {number2} = {number1 - number2}");
                    break;
                case "*":
                    Console.WriteLine($"{number1} * {number2} = {number1 * number2}");
                    break;
                case "/":
                    Console.WriteLine($"{number1} / {number2} = {number1 / number2}");
                    break;
                case "%":
                    Console.WriteLine($"{number1} % {number2} = {number1 % number2}");
                    break;
                default:
                    Console.WriteLine("연산기호를 잘못입력하셨습니다.");
                    break;
            }
        }

    }

}
