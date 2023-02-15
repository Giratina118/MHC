using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpUnityClass_0210
{
    internal class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("숫자 2개를 입력해 주세요.");
            
            int numberA = System.Convert.ToInt32(System.Console.ReadLine());
            int numberB = System.Convert.ToInt32(System.Console.ReadLine());

            System.Console.WriteLine($"{numberA} + {numberB} = {PlusNumber(numberA, numberB)}\n");


            int numberC = 11;   // 별짓기 모양의 높이

            for (int i = 0; i < numberC; i++)
            {
                if (i < numberC / 2)
                {
                    for (int j = 0; j < (numberC - 1) / 2 - i; j++)
                        System.Console.Write(" ");
                    for (int j = 0; j < i * 2 + 1; j++)
                        System.Console.Write("*");
                }
                else
                {
                    for (int j = 0; j < i - numberC / 2; j++)
                        System.Console.Write(" ");
                    for (int j = 0; j < (numberC - i) * 2 - 1; j++)
                        System.Console.Write("*");
                }
                System.Console.WriteLine("");
            }

            System.Console.WriteLine("");

            for (int i = 1; i <= numberC; i++)
            {
                if (i <= numberC / 2)
                {
                    for (int j = 0; j < (numberC + 1) / 2 * 2 - i * 2; j++)
                        System.Console.Write(" ");
                    for (int j = 0; j < i * 2 - 1; j++)
                        System.Console.Write("*");
                }
                else if (numberC % 2 == 1 && numberC / 2 + 1 == i)
                    for (int j = 0; j < numberC * 2 - 1; j++)
                        System.Console.Write("*");
                else
                {
                    for (int j = 0; j < numberC - 1; j++)
                        System.Console.Write(" ");
                    for (int j = 0; j < (numberC - i) * 2 + 1; j++)
                        System.Console.Write("*");
                }
                System.Console.WriteLine("");
                
            }


        }

        private static int PlusNumber(int a, int b)
        {
            return a + b;
        }
    }
}