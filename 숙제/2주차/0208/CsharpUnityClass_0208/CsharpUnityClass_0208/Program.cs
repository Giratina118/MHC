using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpUnityClass_0208
{
    internal class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("숫자 2개를 입력해 주세요.");
            int numberA = System.Convert.ToInt32(System.Console.ReadLine());
            int numberB = System.Convert.ToInt32(System.Console.ReadLine());

            if (numberA + numberB <= 10)
                System.Console.WriteLine("10 이하입니다.\n");
            else if (numberA + numberB <= 20)
                System.Console.WriteLine("20 이하입니다.\n");
            else if (numberA + numberB <= 30)
                System.Console.WriteLine("30 이하입니다.\n");
            else
                System.Console.WriteLine("최소 30 이상입니다.\n");

            if (numberA % 2 == 0 && numberB % 2 == 0)
                System.Console.WriteLine("짝짝");
            else if (numberA % 2 == 0 && numberB % 2 == 1)
                System.Console.WriteLine("짝홀");
            else if (numberA % 2 == 1 && numberB % 2 == 0)
                System.Console.WriteLine("홀짝");
            else
                System.Console.WriteLine("홀홀");

            System.Console.WriteLine("\n\'문장반복\'을 반복할 횟수를 입력해 주세요.");
            int repeat = System.Convert.ToInt32(System.Console.ReadLine());

            System.Console.WriteLine("\nfor문 문장반복");
            for (int i = 1; i <= repeat; i++)
                System.Console.WriteLine($"문장반복 {i}회");

            int count = 0;
            System.Console.WriteLine("\nwhile문 문장반복");
            while (repeat-- > 0)
                System.Console.WriteLine($"문장반복 {++count}회");
        }
    }
}
