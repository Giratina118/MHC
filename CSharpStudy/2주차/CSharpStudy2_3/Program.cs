using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpStudy2_3
{
    class Program
    {
        static void Main(string[] args)
        {
            
            System.Console.WriteLine(plusFive(15));
            System.Console.WriteLine(minuFive(15));
            System.Console.WriteLine(multFive(15));
            System.Console.WriteLine(diviFive(15));
            System.Console.WriteLine(remaFive(15));



            System.Console.WriteLine("\n\n홀짝을 구분할 숫자를 입력해 주세요. ");
            int num = System.Convert.ToInt32(System.Console.ReadLine());

            bool result = EvenCheck(num);

            if (result)
                System.Console.WriteLine("짝수입니다.");
            else
                System.Console.WriteLine("홀수입니다.");
            System.Console.WriteLine("\n");
            

            
            System.Console.WriteLine("사칙연산 할 두 숫자를 입력해 주세요. ");
            string s1 = System.Console.ReadLine();
            int s1Number = Convert.ToInt32(s1);

            string s2 = System.Console.ReadLine();
            int s2Number = Convert.ToInt32(s2);

            System.Console.WriteLine("사칙연산 기호(+, -, *, /, %) 중 하나를 입력해주세요.");
            string s3 = System.Console.ReadLine();

            int resultInt;

            if (s3 == "+")
            {
                resultInt = PlusTwoParam(s1Number, s2Number);
                System.Console.WriteLine($"{s1Number} + {s2Number} = {resultInt}");
            }
            else if (s3 == "-")
            {
                resultInt = MinuTwoParam(s1Number, s2Number);
                System.Console.WriteLine($"{s1Number} - {s2Number} = {resultInt}");
            }
            else if (s3 == "*")
            {
                resultInt = MultTwoParam(s1Number, s2Number);
                System.Console.WriteLine($"{s1Number} * {s2Number} = {resultInt}");
            }
            else if (s3 == "/")
            {
                resultInt = DiviTwoParam(s1Number, s2Number);
                System.Console.WriteLine($"{s1Number} / {s2Number} = {resultInt}");
            }
            else if (s3 == "%")
            {
                resultInt = RemaTwoParam(s1Number, s2Number);
                System.Console.WriteLine($"{s1Number} % {s2Number} = {resultInt}");
            }
            else
                System.Console.WriteLine("기호를 잘못 입력했습니다.");

            System.Console.WriteLine("");

            switch (s3)
            {
                case "+":
                    resultInt = PlusTwoParam(s1Number, s2Number);
                    System.Console.WriteLine($"{s1Number} + {s2Number} = {resultInt}");
                    break;
                case "-":
                    resultInt = MinuTwoParam(s1Number, s2Number);
                    System.Console.WriteLine($"{s1Number} - {s2Number} = {resultInt}");
                    break;
                case "*":
                    resultInt = MultTwoParam(s1Number, s2Number);
                    System.Console.WriteLine($"{s1Number} * {s2Number} = {resultInt}");
                    break;
                case "/":
                    resultInt = DiviTwoParam(s1Number, s2Number);
                    System.Console.WriteLine($"{s1Number} / {s2Number} = {resultInt}");
                    break;
                case "%":
                    resultInt = RemaTwoParam(s1Number, s2Number);
                    System.Console.WriteLine($"{s1Number} % {s2Number} = {resultInt}");
                    break;
                default:
                    System.Console.WriteLine("기호를 잘못 입력했습니다.");
                    break;
            }
            System.Console.WriteLine("\n");

            //숫자를 입력, 메소드 인수에 넣기, while문으로 숫자만큼 띄우기
            System.Console.WriteLine("반복할 문장을 입력해주세요.");
            string ss1 = System.Console.ReadLine();

            System.Console.WriteLine("문장을 반복할 수를 입력해주세요.");
            string ss2 = System.Console.ReadLine();
            int ss3 = System.Convert.ToInt32(ss2);

            Replay(ss1, ss3);


        }

        private static int plusFive(int number)
        {
            return number + 5;
        }
        private static int minuFive(int number)
        {
            return number - 5;
        }
        private static int multFive(int number)
        {
            return number * 5;
        }
        private static int diviFive(int number)
        {
            return number / 5;
        }
        private static int remaFive(int number)
        {
            return number % 5;
        }

        private static bool EvenCheck(int num)
        {
            bool result;

            if (num % 2 == 0)
                result = true;
            else
                result = false;

            return result;
        }

        private static int PlusTwoParam(int number1, int number2)
        {
            return number1 + number2;
        }
        private static int MinuTwoParam(int number1, int number2)
        {
            return number1 - number2;
        }
        private static int MultTwoParam(int number1, int number2)
        {
            return number1 * number2;
        }
        private static int DiviTwoParam(int number1, int number2)
        {
            return number1 / number2;
        }
        private static int RemaTwoParam(int number1, int number2)
        {
            return number1 % number2;
        }

        private static void Replay(string sentence, int num)
        {
            int count = 0;
            System.Console.WriteLine("\n");
            while (num-- > 0)
            {
                count++;
                System.Console.WriteLine($"{sentence}\tcount = {count}");
            }
        }

    }
}
