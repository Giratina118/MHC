using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpStudy3_1
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 키 입력하는 코드
            /*
            ConsoleKeyInfo cski;

            int x = 10;
            int y = 10;

            while (true)
            {
                Console.Clear();

                Console.SetCursorPosition(x, y);

                Console.Write("#");

                cski = Console.ReadKey(true);

                switch (cski.Key)
                {
                    case ConsoleKey.LeftArrow:
                        x--;
                        break;
                    case ConsoleKey.RightArrow:
                        x++;
                        break;
                    case ConsoleKey.UpArrow:
                        y--;
                        break;
                    case ConsoleKey.DownArrow:
                        y++;
                        break;
                }

            }
            */
            #endregion

            #region 복습 문제
            /*
            // 1. 산술 이항 하나씩 쓰기 (+, -, *, /, %), 출력하기 5줄
            int a = 21;
            int b = 10;
            System.Console.WriteLine($"{a} + {b} = {a + b}");
            System.Console.WriteLine($"{a} - {b} = {a - b}");
            System.Console.WriteLine($"{a} * {b} = {a * b}");
            System.Console.WriteLine($"{a} / {b} = {a / b}");
            System.Console.WriteLine($"{a} % {b} = {a % b}\n");

            // 2. 할당 (+=, - *=, /=, %=), 출력하기 5줄
            System.Console.WriteLine($"{a} += 3  ->  {a += 3}");
            System.Console.WriteLine($"{a} -= 3  ->  {a -= 3}");
            System.Console.WriteLine($"{a} *= 3  ->  {a *= 3}");
            System.Console.WriteLine($"{a} /= 3  ->  {a /= 3}");
            System.Console.WriteLine($"{a} %= 3  ->  {a %= 3}\n");

            // 3. 증감 (++, --) 앞뒤로 4줄
            System.Console.WriteLine($"++{a}  ->  {++a}");
            System.Console.WriteLine($"{a}++  ->  {a++}");
            System.Console.WriteLine($"--{a}  ->  {--a}");
            System.Console.WriteLine($"{a}--  ->  {a--}\n\n");

            // 4. 2개 숫자 입력 후 A가 짝수이고 B가 5보다 큰가를 if문으로
            // 5. 2개 숫자 입력 후 A가 홀수이고 B가 3보다 작은가를 else if문으로
            // 6. else 문으로 없음 출력하기
            System.Console.WriteLine("숫자 2개를 입력해 주세요. (A, B)");
            int numA = System.Convert.ToInt32(System.Console.ReadLine());
            int numB = System.Convert.ToInt32(System.Console.ReadLine());

            if (numA % 2 == 0 && numB > 5)
                System.Console.WriteLine("A가 짝수이고 B가 5보다 크다");
            else if (numA % 2 == 1 && numB < 3)
                System.Console.WriteLine("A가 홀수이고 B가 3보다 작다");
            else
                System.Console.WriteLine("없음");

            // 7. 숫자 입력받은거 만큼 문장 출력(while)
            System.Console.WriteLine("\n\nwhile문 문장을 반복할 횟수를 입력해 주세요.");
            int numWR = System.Convert.ToInt32(System.Console.ReadLine());
            int count = 0;
            
            while (numWR-- > 0 * ++count)
                System.Console.WriteLine($"while문 문장반복   {count}번째");

            // 8. 숫자 입력받은거 만큼 문장 출력(for)
            System.Console.WriteLine("\n\nfor문 문장을 반복할 횟수를 입력해 주세요.");
            int numFR = System.Convert.ToInt32(System.Console.ReadLine());

            for (int i = 1; i <= numFR; i++)
                System.Console.WriteLine($"for문 문장반복   {i}번째");

            // 9. 위에 했던 4, 5, 6, 7, 8을 메소드로 뽑아서 실행하기
            Question456_If();
            Question7_While();
            Question8_For();

            // 10. for문 안에서 숫자를 계속 입력받는다.
                // -1. 숫자가 10인 경우 break로 for문 종료.
                // -2. 숫자가 짝수인 경우 continue로 넘김.
                // -3. 그 외의 숫자인 경우 "다음 숫자 입력"을 출력.
            for (int i = 0; i < 10; i++)
            {
                System.Console.WriteLine("\n\n숫자를 입력해 주세요. (종료: 10)");
                int number = System.Convert.ToInt32(System.Console.ReadLine());

                if (number == 10)
                    break;
                else if (number % 2 == 0)
                {
                    System.Console.WriteLine("짝수 -> continue");
                    i--;
                    continue;
                }
                else
                {
                    System.Console.WriteLine("다음 숫자 입력");
                    i--;
                }
                    
            }
            */
            #endregion


        }
        private static void Question456_If()
        {
            System.Console.WriteLine("\n\n숫자 2개를 입력해 주세요. (A, B)");
            int numA = System.Convert.ToInt32(System.Console.ReadLine());
            int numB = System.Convert.ToInt32(System.Console.ReadLine());

            if (numA % 2 == 0 && numB > 5)
                System.Console.WriteLine("A가 짝수이고 B가 5보다 크다");
            else if (numA % 2 == 1 && numB < 3)
                System.Console.WriteLine("A가 홀수이고 B가 3보다 작다");
            else
                System.Console.WriteLine("없음");
        }

        private static void Question7_While()
        {
            System.Console.WriteLine("\n\nwhile문 문장을 반복할 횟수를 입력해 주세요.");
            int numWR = System.Convert.ToInt32(System.Console.ReadLine());
            int count = 0;

            while (numWR-- > 0 * ++count)
                System.Console.WriteLine($"while문 문장반복   {count}번째");
        }

        private static void Question8_For()
        {
            System.Console.WriteLine("\n\nfor문 문장을 반복할 횟수를 입력해 주세요.");
            int numFR = System.Convert.ToInt32(System.Console.ReadLine());

            for (int i = 1; i <= numFR; i++)
                System.Console.WriteLine($"for문 문장반복   {i}번째");
        }

    }
    
}
