using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpUnityClass_0201
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string Name, BirthYear, Adress, Gender, Introduce;

            System.Console.WriteLine("이름을 입력해 주세요.");
            Name = System.Console.ReadLine();
            System.Console.WriteLine("출생년도를 입력해 주세요.");
            BirthYear = System.Console.ReadLine();
            System.Console.WriteLine("주소를 입력해 주세요.");
            Adress = System.Console.ReadLine();
            System.Console.WriteLine("성별을 입력해 주세요.");
            Gender = System.Console.ReadLine();
            System.Console.WriteLine("자기소개 1줄을 입력해 주세요.");
            Introduce = System.Console.ReadLine();

            System.Console.WriteLine("");
            System.Console.WriteLine("");
            System.Console.WriteLine("");
            int Age = 2024 - System.Convert.ToInt32(BirthYear);

            System.Console.WriteLine($"이름은 {Name}입니다.");
            System.Console.WriteLine($"나이는 {Age}입니다.");
            System.Console.WriteLine($"주소는 {Adress}입니다.");
            System.Console.WriteLine($"성별은 {Gender}입니다.");
            System.Console.WriteLine(Introduce);

        }
    }
}
