using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpUnityClass_0203
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] Foods = new string[4] { "떡볶이", "김밥", "만두", "튀김" };
            System.Console.WriteLine($"{Foods[0]}(1) {Foods[1]}(2) {Foods[2]}(3) {Foods[3]}(4) 중 먹을 음식을 골라주세요.");
            string num = System.Console.ReadLine();

            int number = System.Convert.ToInt32(num) - 1;
            System.Console.WriteLine($"{Foods[number]}을(를) 먹었습니다.");

            Foods[number] = " ";
            System.Console.WriteLine($"{Foods[0]} {Foods[1]} {Foods[2]} {Foods[3]} 남았습니다.");

        }
    }
}
