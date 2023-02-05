using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpStudy
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            // WriteLine 사용법
            System.Console.WriteLine("1");
            System.Console.WriteLine("2");
            System.Console.WriteLine("3");
            System.Console.WriteLine("4");
            // Write 사용법
            System.Console.Write("5");
            System.Console.Write("6");
            System.Console.Write("7");
            System.Console.Write("8");
            System.Console.Write("9");
            System.Console.Write("10");
            */

            /*
            //데이터 형 - string
            String myName, myAge;
            myName = "나의 이름은 유민혁 입니다.";
            myAge = "나의 나이는 24살 입니다.";
            System.Console.WriteLine(myName);
            System.Console.WriteLine(myAge);
            */

            /*
            //ReadLine();
            string MyName, MyAge, MyAdress, MyGender;

            System.Console.WriteLine("이름을 입력해 주세요 : ");
            MyName = System.Console.ReadLine();
            System.Console.WriteLine("나이를 입력해 주세요 : ");
            MyAge = System.Console.ReadLine();
            System.Console.WriteLine("주소를 입력해 주세요 : ");
            MyAdress = System.Console.ReadLine();
            System.Console.WriteLine("성별 입력해 주세요 : ");
            MyGender = System.Console.ReadLine();

            System.Console.Write("당신의 이름은 : ");
            System.Console.WriteLine(MyName);
            System.Console.Write("당신의 나이는 : ");
            System.Console.WriteLine(MyAge);
            System.Console.Write("당신의 주소는 : ");
            System.Console.WriteLine(MyAdress);
            System.Console.Write("당신의 성별은 : ");
            System.Console.WriteLine(MyGender);

            System.Console.Write($"당신의 이름은 {MyName} 이고, 당신의 나이는 {MyAge} 입니다. ");
            System.Console.Write("당신의 이름은 {0} 이고, 당신의 나이는 {1} 입니다. ", MyName, MyAge);
            */

            /*
            System.Console.WriteLine(int.MaxValue);
            System.Console.WriteLine(int.MinValue);

            int mynumber = 2147483647;
            int Max = int.MaxValue;
            System.Console.WriteLine(mynumber + 1);
            System.Console.WriteLine(Max + 1);
            */

            /*
            System.Console.WriteLine("강사님이 말했다 \"안녕하세요\" 라고\n");
            string MyName = "MinHyeok";
            string MyAge = "3";
            string MMM = MyName + MyAge;
            System.Console.Write(MMM);
            */

            /*
            string MyAge;
            System.Console.WriteLine("나이를 입력해 주세요 : ");
            MyAge = System.Console.ReadLine();

            int MyAgeNumber = Convert.ToInt32(MyAge);
            string NowAge = (MyAgeNumber + 3).ToString();
            System.Console.WriteLine(NowAge);
            */

            /*
            //나의 태어난 년도 입력, 받은 입력 후 지금 나이 도출하기
            string Year;
            System.Console.WriteLine("태어난 년도를 입력해 주세요 : ");
            Year = System.Console.ReadLine();

            int AgeNumber = Convert.ToInt32(Year);
            string Age = (2023 - AgeNumber).ToString();
            System.Console.WriteLine(Age);
            */

            /*
            System.Console.WriteLine(@"
□□□□□□□□□
□□□□■□□□□
□□□■■■□□□
□□■■■■■□□
□■■■■■■■□
■■■■■■■■■");
            */


            /*
            //1. 변수형 종류 주석으로 작성 후, 각 변수형들의 최대값 최소값 출력하기
            //int, float, long, double
            //int
            System.Console.WriteLine(int.MaxValue);
            System.Console.WriteLine(int.MinValue);

            //float
            System.Console.WriteLine(float.MaxValue);
            System.Console.WriteLine(float.MinValue);

            //long
            System.Console.WriteLine(long.MaxValue);
            System.Console.WriteLine(long.MinValue);

            //double
            System.Console.WriteLine(double.MaxValue);
            System.Console.WriteLine(double.MinValue);


            //2. string으로 이름 입력받고, 출력하기
            //나이는 출생년도만 입력받기
            string BirthYear;
            System.Console.Write("\n출생년도를 입력해 주세요: ");
            BirthYear = System.Console.ReadLine();

            int YearNum = Convert.ToInt32(BirthYear);
            string NowAge = (2023 - YearNum).ToString();
            System.Console.WriteLine(NowAge);


            //3. @사용해서 별 그리기
            System.Console.WriteLine(@"
     ㅁ
    ㅁㅁ
ㅁㅁㅁㅁㅁㅁ
  ㅁㅁㅁㅁ
 ㅁㅁ  ㅁㅁ
ㅁ        ㅁ");
            */

            /*
            //4. int값을 float 로 캐스팅하기
            int inum = 5;
            float fnum = (float)inum;
            System.Console.WriteLine(fnum);

            float fnum2 = inum * 1.00f;
            System.Console.WriteLine(fnum2);

            //      3.12 를 int값으로 캐스팅하기
            float fnumber = 3.12f;
            int inumber = Convert.ToInt32(fnumber);
            System.Console.WriteLine(inumber);
            */
            /*
            float number0 = 2.99f;
            float number1 = 3.00f;
            float number2 = 3.01f;
            System.Console.WriteLine(number0);
            System.Console.WriteLine(number1);
            System.Console.WriteLine(number2);
            */

            /*
            //이름을 입력받는다.
            //입력받은 이름의 길이를 숫자로 바꾸고
            //받은 숫자를 출력한다.
            System.Console.WriteLine("이름을 입력해 주세요: ");
            string name = System.Console.ReadLine();
            System.Console.WriteLine(name.Length);

            int NameLength = name.Length;
            System.Console.WriteLine(NameLength);
            */

            /*
            var Mynameis = "유민혁";
            var iii = 3;
            var fff = 3.12f;
            */

            /*
            //int형 배열을 5칸짜리 5개
            int[] i1 = new int[5] { 0, 1, 2, 3, 4 };
            int[] i2 = new int[5] { 5, 6, 7, 8, 9 };
            int[] i3 = new int[5] { 10, 11, 12, 13, 14 };
            int[] i4 = new int[5] { 15, 16, 17, 18, 19 };
            int[] i5 = new int[5];

            //string형 배열 5칸짜리 5개 만들기
            string[] s1 = new string[5] { "영", "일", "이", "삼", "사" };
            string[] s2 = new string[5] { "오", "육", "칠", "팔", "구" };
            string[] s3 = new string[5] { "십", "십일", "십이", "십삼", "십사" };
            string[] s4 = new string[5] { "십오", "십육", "십칠", "십팔", "십구" };
            string[] s5 = new string[5];
            */

            /*
            int[] LaterArray;
            System.Console.WriteLine("배열의 크기는?");
            String ArraySize = System.Console.ReadLine();

            LaterArray = new int[Convert.ToInt32(ArraySize)];

            string[] _lang = new string[3];
            _lang[0] = "C";
            _lang[1] = "C++";
            _lang[2] = "C#";

            System.Console.WriteLine($"0번 값은 {_lang[0]}입니다.");
            _lang[0] = "나도 졸려";
            System.Console.WriteLine($"0번 값은 {_lang[0]}입니다.");
            */


            //식당에 음식이 떡볶이, 김밥, 라면, 라뽁이가 있다.
            //이중에 숫자를 입력받으면 입력받은 값은 비어있게 된다.
            //최초 음식들과 숫자를 입력방았을 때 음식을 출력하고
            //비어있게 되었다는 결과값도 출력하라

            string Choice;
            int ChoiceNumber;
            string[] food = new string[4] { "떡볶이", "김밥", "라면", "라볶이" };
            System.Console.WriteLine("1 떡볶이, 2 김밥, 3 라면, 4 라볶이 중 드실 음식의 번호를 입력해 주세요.");
            Choice = System.Console.ReadLine();
            ChoiceNumber = System.Convert.ToInt32(Choice) - 1;

            System.Console.WriteLine($"{food[ChoiceNumber]} 선택되었습니다.");
            food[ChoiceNumber] = " ";

            System.Console.WriteLine($"{food[0]} {food[1]} {food[2]} {food[3]} 남았습니다.");



        }
    }
}
