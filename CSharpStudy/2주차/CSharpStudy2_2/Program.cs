using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpStudy2_2
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            // 산술연산자
            int numA = 33;
            int numB = 15;

            int plusResult = numA + numB;
            int minusResult = numA - numB;
            int multResult = numA * numB;
            int quioResult = numA / numB;
            int reminResult = num1 % numB;
            System.Console.WriteLine($"plus Result : {plusResult}");
            System.Console.WriteLine($"minus Result : {minusResult}");
            System.Console.WriteLine($"mult Result : {multResult}");
            System.Console.WriteLine($"quio Result : {quioResult}");
            System.Console.WriteLine($"remin Result : {reminResult}");

            int num1 = 123;
            int num2 = 456;
            num2 += num1;
            System.Console.WriteLine($"+= Result : {num2}");

            num2 = 456;
            num2 -= num1;
            System.Console.WriteLine($"-= Result : {num2}"); 

            num2 = 456;
            num2 *= num1;
            System.Console.WriteLine($"*= Result : {num2}");

            num2 = 456;
            num2 /= num1;
            System.Console.WriteLine($"/= Result : {num2}");

            num2 = 456;
            num2 %= num1;
            System.Console.WriteLine($"%= Result : {num2}");

            // 증감연산자
            int value = 200;
            System.Console.WriteLine($"value result : {value}");
            System.Console.WriteLine($"++value result : {++value}");
            System.Console.WriteLine($"value++ result : {value++}");
            System.Console.WriteLine($"value result : {value}");
            System.Console.WriteLine($"--value result : {--value}");
            System.Console.WriteLine($"value-- result : {value--}");
            System.Console.WriteLine($"value result : {value}");
            */

            /*
            bool 형식
            bool isTrue = true;
            bool isFalse = false;
            System.Console.WriteLine(isTrue);
            System.Console.WriteLine(isFalse);

            bool isSame1 = (3 == 3);
            System.Console.WriteLine(isSame1);
            bool isSame2 = (3 == 4);
            System.Console.WriteLine(isSame2);
            bool isDif1 = (3 != 4);
            System.Console.WriteLine(isDif1);
            bool isDif2 = (3 != 3);
            System.Console.WriteLine(isDif2);
            bool isLess1 = (3 < 4);
            System.Console.WriteLine(isLess1);
            bool isLess2 = (3 < 3);
            System.Console.WriteLine(isLess2);
            bool isMore1 = (4 > 3);
            System.Console.WriteLine(isMore1);
            bool isMore2 = (3 > 3);
            System.Console.WriteLine(isMore2);
            bool isLessEqu1 = (3 <= 3);
            System.Console.WriteLine(isLessEqu1);
            bool isLessEqu2 = (4 <= 3);
            System.Console.WriteLine(isLessEqu2);
            bool isMoreEqu1 = (3 >= 3);
            System.Console.WriteLine(isMoreEqu1);
            bool isMoreEqu2 = (3 >= 4);
            System.Console.WriteLine(isMoreEqu2);
            */

            /*
            System.Console.WriteLine(true && true);
            System.Console.WriteLine(true && false);
            System.Console.WriteLine(false && true);
            System.Console.WriteLine(false && false);

            System.Console.WriteLine(true || true);
            System.Console.WriteLine(true || false);
            System.Console.WriteLine(false || true);
            System.Console.WriteLine(false || false);
            */

            /*
            string numberA, numberB;
            System.Console.WriteLine("숫자 2개를 입력해 주세요.");
            numberA = System.Console.ReadLine();
            numberB = System.Console.ReadLine();

            int A = System.Convert.ToInt32(numberA);
            int B = System.Convert.ToInt32(numberB);

            int number = A + B;
            if (number < 0)
                System.Console.WriteLine("두 수의 합은 0보다 작습니다.");
            else if (number < 10)
                System.Console.WriteLine("두 수의 합은 0 이상, 10 미만입니다.");
            else if (number < 20)
                System.Console.WriteLine("두 수의 합은 10 이상, 20 미만입니다.");
            else if (number < 30)
                System.Console.WriteLine("두 수의 합은 20 이상, 30 미만입니다.");
            else if (number < 40)
                System.Console.WriteLine("두 수의 합은 30 이상, 40 미만입니다.");
            else if (number < 50)
                System.Console.WriteLine("두 수의 합은 40 이상, 50 미만입니다.");
            else
                System.Console.WriteLine("두 수의 합은 50 이상입니다.");

            if (A % 2 == 0 && B < 0)
                System.Console.WriteLine("A가 짝수이고 B가 0보다 작습니다.");
            else if (A % 2 == 0 && B < 3)
                System.Console.WriteLine("A가 짝수이고 B가 3보다 작습니다.");
            else if (A % 2 == 1 && B < 5)
                System.Console.WriteLine("A가 홀수이고 B가 5보다 작습니다.");
            else
                System.Console.WriteLine("해당사항이 없습니다.");
            */

            /*
            int numberLimit = 10;
            while (numberLimit > 0)
            {
                System.Console.WriteLine($"Hi {numberLimit}");
                numberLimit--;
            }

            do
            {
                System.Console.WriteLine($"\nHi {numberLimit}");
            } while (numberLimit > 5);
            */

            /*
            int inputNum1 = System.Convert.ToInt32(System.Console.ReadLine());
            int count = 0;

            while (inputNum1-- > 0)
            {
                System.Console.WriteLine($"Hi {++count}");
            }
            */

            /*
            int inputNum2 = System.Convert.ToInt32(System.Console.ReadLine());
            for (int n = 0; n < inputNum2; n++)
            {
                System.Console.WriteLine($"Hi {n + 1}");
            }
            */

            /*
            //1번 별그리기
            for (int i = 1; i < 6; i++)
            {
                for (int j = 0; j < i; j++){
                    System.Console.Write("*");
                }
                System.Console.WriteLine("");
            }

            System.Console.WriteLine("");

            //2번 별그리기
            for (int i = 5; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    System.Console.Write("*");
                }
                System.Console.WriteLine("");
            }

            System.Console.WriteLine("");

            //3번 별그리기
            for (int i = 1; i < 6; i++)
            {
                for (int j = 6; j > i; j--)
                {
                    System.Console.Write(" ");
                }
                for (int j = 0; j < i; j++)
                {
                    System.Console.Write("*");
                }
                System.Console.WriteLine("");
            }

            System.Console.WriteLine("");

            //4번 별그리기
            for (int i = 5; i > 0; i--)
            {
                for (int j = 6; j > i; j--)
                {
                    System.Console.Write(" ");
                }
                for (int j = 0; j < i; j++)
                {
                    System.Console.Write("*");
                }
                System.Console.WriteLine("");
            }

            System.Console.WriteLine("");

            //5번 별그리기1
            for (int i = 1; i < 6; i++)
            {
                for (int j = 6; j > i; j--)
                {
                    System.Console.Write(" ");
                }
                for (int j = 0; j < i; j++)
                {
                    System.Console.Write("*");
                }

                for (int j = 1; j < i; j++)
                {
                    System.Console.Write("*");
                }
                System.Console.WriteLine("");
            }

            System.Console.WriteLine("");
            
            //5번 별그리기2
            for (int i = 1; i < 6; i++)
            {
                for (int j = 6; j > i; j--)
                {
                    System.Console.Write(" ");
                }
                for (int j = 0; j < i * 2 - 1; j++)
                {
                    System.Console.Write("*");
                }

                System.Console.WriteLine("");
            }

            //6번 별그리기1
            for (int i = 5; i > 0; i--)
            {
                for (int j = 6; j > i; j--)
                {
                    System.Console.Write(" ");
                }
                for (int j = 0; j < i; j++)
                {
                    System.Console.Write("*");
                }

                for (int j = 1; j < i; j++)
                {
                    System.Console.Write("*");
                }
                System.Console.WriteLine("");
            }
            
            //6번 별그리기2
            for (int i = 5; i > 0; i--)
            {
                for (int j = 6; j > i; j--)
                {
                    System.Console.Write(" ");
                }
                for (int j = 0; j < i * 2 - 1; j++)
                {
                    System.Console.Write("*");
                }

                System.Console.WriteLine("");
            }
            */

            /*
            int myNumber = 3;
            switch (myNumber)
            {
                case 0:
                    System.Console.WriteLine("0");
                    break;
                case 1:
                    System.Console.WriteLine("1");
                    break;
                case 2:
                    System.Console.WriteLine("2");
                    break;
                case 3:
                    System.Console.WriteLine("3");
                    break;
                default:
                    break;
            }
            */

            /*
            for (int i = 0; i < 5; i++)
            {
                if (i == 0)
                {
                    Console.WriteLine("0");
                    continue;
                }
                else if (i == 1)
                {
                    Console.WriteLine("1");
                    Console.WriteLine("11");
                    continue;
                    Console.WriteLine("111");
                }
                else if (i == 2)
                {
                    Console.WriteLine("2");
                    break;
                }
                else if (i == 3)
                {
                    Console.WriteLine("3");
                }
            }
            Console.WriteLine("끝");
            */



        }
    }
}
