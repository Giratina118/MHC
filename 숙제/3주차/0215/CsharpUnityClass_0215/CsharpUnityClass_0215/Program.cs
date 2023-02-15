using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CsharpUnityClass_0215
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Rest rest = new Rest();
            
            switch (rest.AskRest())
            {
                case 1:
                    Korean korean = new Korean();
                    korean.menu();
                    korean.money(korean.AskMenu());
                    break;
                case 2:
                    Western western = new Western();
                    western.menu();
                    western.money(western.AskMenu());
                    break;
                case 3:
                    Chinese chinese = new Chinese();
                    chinese.menu();
                    chinese.money(chinese.AskMenu());
                    break;
                default:
                    Console.WriteLine("잘못 선택했습니다.");
                    break;
            }

        }
    }

    class Rest
    {
        protected string[] foodname;
        protected int[] price;

        public int AskRest()
        {
            Console.WriteLine("가고싶은 식당을 선택해주세요. (한식 1   양식 2   중식 3)");
            int ChoiceRest = Convert.ToInt32(Console.ReadLine());
            return ChoiceRest;
        }
        public int AskMenu()
        {
            Console.WriteLine("\n먹고싶은 음식을 선택해주세요.");
            for (int i = 0; i < foodname.Count(); i++)
                Console.WriteLine($"{i + 1}번   {foodname[i]}");
            int ChoiceFood = Convert.ToInt32(Console.ReadLine());
            return ChoiceFood - 1;
        }
        public void money(int SelectMenu)
        {
            Console.WriteLine($"\n{foodname[SelectMenu]}  {price[SelectMenu]}원입니다.");
        }

    }
    class Korean : Rest
    {
        public void menu()
        {
            foodname = new string[3];
            foodname[0] = "밥";
            foodname[1] = "김치찌개";
            foodname[2] = "불고기";

            price = new int[3];
            price[0] = 1000;
            price[1] = 4000;
            price[2] = 7000;
        }
        
    }
    class Western : Rest
    {
        public void menu()
        {
            foodname = new string[3];
            foodname[0] = "파스타";
            foodname[1] = "리조또";
            foodname[2] = "스테이크";

            price = new int[3];
            price[0] = 7500;
            price[1] = 7000;
            price[2] = 14000;
        }
    }
    class Chinese : Rest
    {
        public void menu()
        {
            foodname = new string[3];
            foodname[0] = "짜장면";
            foodname[1] = "짬뽕";
            foodname[2] = "탕수육";

            price = new int[3];
            price[0] = 6000;
            price[1] = 7000;
            price[2] = 15000;
        }
    }

}
