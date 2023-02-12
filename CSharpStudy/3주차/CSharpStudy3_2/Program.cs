using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpStudy3_2
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 클래스 연습
            /*
            Student AStudent;
            AStudent = new Student();

            AStudent.name = "유민혁";
            AStudent.age = 24;

            System.Console.WriteLine($"A학생의 이름은 {AStudent.name}");
            System.Console.WriteLine($"A학생의 나이는 {AStudent.age}\n");

            Student BStudent;
            BStudent = new Student();

            BStudent.name = "NewName";
            BStudent.age = 25;

            System.Console.WriteLine($"B학생의 이름은 {BStudent.name}");
            System.Console.WriteLine($"B학생의 나이는 {BStudent.age}\n");

            AStudent.WriteLineStudentInfo();
            */
            #endregion

            #region 클래스 문제 1 2 3 4
            /*
            //1. 학생클래스를 만들어서 학생 하나의 정보를 입력받는다. (ReadLine)
            Student StudentA = new Student();
            Student StudentB = new Student();

            System.Console.WriteLine("학생의 이름을 입력해 주세요.");
            StudentA.name = System.Console.ReadLine();
            System.Console.WriteLine("학생의 나이를 입력해 주세요.");
            StudentA.age = System.Convert.ToInt32(System.Console.ReadLine());

            StudentA.WriteLineStudentInfo();

            //2. 학생클래스를 만들어서 매소드로 학생 하나의 정보를 입력받는다.
            StudentB.InputStudentInfoData();
            
            //3. 학생 클래스를 만들어서 for문으로 학생 을 입력받는다.
            Student[] students = new Student[3];
            for (int i = 0; i < 3; i++)
            {
                students[i] = new Student();
                students[i].InputStudentInfoData();
            }
            

            //4. 먹을 것 클래스를 만들어서 음식을 여러 개 입력받습니다. (ReadLine)
            //-1. 5개의 음식을 입력받습니다.
            //-2. 추가로 음식을 입력받는데, 5개의 음식 중 이미 있는 음식이면 제외됩니다.
            //예) a, b, c, d, e가 있는데 추가로 b가 입력됨
            //  -> a, c, d, e가 된다.

            Food foods = new Food();
            foods.InputFoodList();
            foods.OverlapFoodRemove();
            */
            #endregion

            #region 클래스 문제 5
            //나이에 해당하는 띠를 풀력해줄 클래스를 만든다.
            //탄생년도를 입력하면 해당하는 띠를 출력한다.
            //출력할 때 나이도 같이 계산되어 출력된다.

            //ZodiacSign zodiac = new ZodiacSign();
            //zodiac.InputBirthYear();
            //zodiac.WriteZodiacAge();


            //개임들을 보유하고 있는 게임 클래스를 제작한다.
            //게임을 입력하면 배열에 값이 있는지 비교해서 있는지 없는지 출력해준다.

            //Game games = new Game();
            //games.InputGameList();
            //games.CheckGame();
            #endregion

            #region 상속 연습

            //Classes myNewClass = new Classes();
            //myNewClass.WriteSchoolInfi("상원초등학교");

            #endregion

            #region 상속 문제
            // 식당 클래스를 상속받는 한식 / 양식 / 중식
            // 식당 클래스가 전체적으로 가질 정보들을 갖는다.
            // (돈 받기 / 주문한 음식 주기)

            // 각각 식당들은 메뉴가 모두 다르다.
            // 한식은 삼계탕 1만원 등등 다르다.
            // 가고싶은 식당을 입력받고, 메뉴를 모두 띄워준다.
            // 유저는 메뉴를 입력하고, 내야 할 가격, 고른 메뉴를 띄워준다.

            /*
            System.Console.WriteLine("한식(1)  중식(2)  양식(3)");
            System.Console.Write("먹을 음식점은 몇 번? : ");
            int RestChoice = Convert.ToInt32(System.Console.ReadLine());

            switch (RestChoice)
            {
                case 1:
                    Korean KoreanFood = new Korean();
                    KoreanFood.MenuSetting();
                    KoreanFood.ShowMenu();
                    KoreanFood.Process();
                    break;
                case 2:
                    Chinese ChineseFood = new Chinese();
                    ChineseFood.MenuSetting();
                    ChineseFood.ShowMenu();
                    ChineseFood.Process();
                    break;
                case 3:
                    Western WesternFood = new Western();
                    WesternFood.MenuSetting();
                    WesternFood.ShowMenu();
                    WesternFood.Process();
                    break;
            }
            */
            #endregion

            #region 클래스 문제 6
            // 서점 클래스에 제목, 지은이, 출판사를 입력받아 책 데이터를 쌓는다.
            // 특정 키를 입력받을 때까지 지속되며, 특정 키 입력을 받으면
            // 제목을 입력받고 제목에 맞는 지은이, 출판사를 순서대로 출력해준다.
            /*
            Library library = new Library();

            int countBookNumber = 0;
            do
            {
                library.InputBooksData(countBookNumber);
                countBookNumber++;
            } while (library.AskeepPutData());

            library.BookSearch();
            */
            #endregion


            // 학생 클래스를 만들고 Classes란 클래스를 만들어서
            // 핫생들의 이름과 반을 입력받아 배열로 저장한다.
            // Classes 클래스에서 숫자를 입력하면
            // 입력 숫자와 같은 반에 들어간 모든 학생을 출력해준다.

            Classes classes = new Classes();

            int StudentCount = 0;

            do
            {
                classes.InputStudentData(StudentCount++);
            } while (classes.AskKeepStudentData());

            classes.ClassSearch(StudentCount);
        }
    }
    
    #region Student 클래스
    /*
    class Student
    {
        public string name;
        public int age;

        public void WriteLineStudentInfo()
        {
            System.Console.WriteLine($"학생의 이름은 {name}");
            System.Console.WriteLine($"학생의 나이는 {age}\n");
        }

        public void InputStudentInfoData()
        {
            name = System.Console.ReadLine();
            age = System.Convert.ToInt32(System.Console.ReadLine());

            WriteLineStudentInfo();
        }

    }
    */
    #endregion

    #region Food 클래스
    class Food
    {
        public string[] foodname;   // Food 클래스 안에 있는 필드가 foodname 하나뿐이므로 굳이 Food클래스를 배열로 만들 필요 없이
                                    // Food 클래스 안의 foodname을 배열로 만들어서 하면 된다.
        public void InputFoodList()
        {
            foodname = new string[5];
            for (int i = 0; i < 5; i++)
            {
                System.Console.Write("음식 이름: ");
                foodname[i] = System.Console.ReadLine();
            }
        }
        public void OverlapFoodRemove()
        {
            System.Console.Write("\n추가 음식 이름: ");
            string AddFood = System.Console.ReadLine();
            for (int i = 0; i < 5; i++)
            {
                if (AddFood == foodname[i])
                    foodname[i] = "";
                System.Console.Write($"{foodname[i]}  ");
            }
        }

    }
    #endregion

    #region ZodiacSign 클래스
    class ZodiacSign
    {
        public int BirthYear;
        public void InputBirthYear()
        {
            System.Console.Write("출생년도 입력: ");
            BirthYear = System.Convert.ToInt32(System.Console.ReadLine());
        }
        /* 띠 계산 switch문
        public void ZodiacSignCheck()
        {
            switch (BirthYear % 12)
            {
                case 0:
                    System.Console.WriteLine("원숭이띠");
                    break;
                case 1:
                    System.Console.WriteLine("닭띠");
                    break;
                case 2:
                    System.Console.WriteLine("개띠");
                    break;
                case 3:
                    System.Console.WriteLine("돼지띠");
                    break;
                case 4:
                    System.Console.WriteLine("쥐띠");
                    break;
                case 5:
                    System.Console.WriteLine("소띠");
                    break;
                case 6:
                    System.Console.WriteLine("호랑이띠");
                    break;
                case 7:
                    System.Console.WriteLine("토끼띠");
                    break;
                case 8:
                    System.Console.WriteLine("용띠");
                    break;
                case 9:
                    System.Console.WriteLine("뱀띠");
                    break;
                case 10:
                    System.Console.WriteLine("말띠");
                    break;
                default:
                    System.Console.WriteLine("양띠");
                    break;
            }
        }
        */

        public string ZodiacSignCheck()
        {
            switch (BirthYear % 12)
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
        public void WriteZodiacAge()
        {
            System.Console.WriteLine($"{ZodiacSignCheck()}띠");
            System.Console.WriteLine($"나이: {2024 - BirthYear}살 입니다.");
        }

    }
    #endregion

    #region Game 클래스
    class Game
    {
        public string[] GameList = new string[5];

        public void InputGameList()
        {
            for (int i = 0; i < 5; i++)
            {
                System.Console.Write("게임 이름을 입력해 주세요: ");
                GameList[i] = System.Console.ReadLine();
            }
        }
        public void CheckGame()
        {
            System.Console.Write("\n유무를 확인하고 싶은 게임 이름을 입력해 주세요: ");
            string CheckGameName = System.Console.ReadLine();

            for (int i = 0; i < 5; i++)
            {
                if (GameList[i] == CheckGameName)
                {
                    System.Console.WriteLine("\n그 게임을 보유하고 있습니다.");
                    break;
                }

                if (i == 4)
                    System.Console.WriteLine("\n그 게임을 보유하고 있지 않습니다.");
            }

        }

    }
    #endregion

    #region School 클래스, Classes 클래스
    /*
    class School
    {
        protected string SchoolName;

        protected void WriteSchoolName()
        {
            System.Console.WriteLine($"학교 이름 : {SchoolName}");
        }
    }
    class Classes : School
    {
        private string ClassName = "3반";

        public void WriteSchoolInfi(string _schoolName)
        {
            SchoolName = _schoolName;
            WriteSchoolName();
            System.Console.WriteLine($"내 반은 {ClassName}");
        }

    }
    */
    #endregion

    #region Rest 클래스, 한식, 중식, 양식
    class Rest
    {
        protected string[] menus;           // 밥    국
        protected int[] menusPrice;         // 1000  8000

        public void TakeMoney(int money)
        {
            System.Console.WriteLine($"돈 내기 : {money}");
        }
        public void OrderMenu (int number)
        {
            System.Console.WriteLine($"주문 : {menus[number]}");
            TakeMoney(menusPrice[number]);
        }
        public void ShowMenu()
        {
            System.Console.Write($"종류 : ");
            for (int index = 0; index < menus.Count(); index++)
            {
                System.Console.Write($"{menus[index]}  ");
            }
        }
        public void Process()
        {
            System.Console.Write("\n먹을 음식은 몇 번? : ");
            int inputMenu = Convert.ToInt32(System.Console.ReadLine()) - 1;
            OrderMenu(inputMenu);
        }

    }
    class Korean : Rest
    {
        public void MenuSetting()
        {
            menus = new string[2];
            menus[0] = "밥";
            menus[1] = "국";

            menusPrice = new int[2];
            menusPrice[0] = 1000;
            menusPrice[1] = 8000;
        }
    }
    class Chinese : Rest
    {
        public void MenuSetting()
        {
            menus = new string[2];
            menus[0] = "짜장면";
            menus[1] = "짬뽕";

            menusPrice = new int[2];
            menusPrice[0] = 6500;
            menusPrice[1] = 7000;
        }
    }
    class Western : Rest
    {
        public void MenuSetting()
        {
            menus = new string[2];
            menus[0] = "파스타";
            menus[1] = "리조또";

            menusPrice = new int[2];
            menusPrice[0] = 8500;
            menusPrice[1] = 9000;
        }
    }
    #endregion

    #region Book 클래스, Library 클래스
    class Book
    {
        public string title;
        public string writerr;
        public string Publisher;
    }
    class Library
    {
        Book[] books = new Book[99];

        public void InputBooksData(int BookCount)
        {
            books[BookCount] = new Book();

            System.Console.Write("제목 : ");
            books[BookCount].title = System.Console.ReadLine();

            System.Console.Write("지은이 : ");
            books[BookCount].writerr = System.Console.ReadLine();

            System.Console.Write("출판사 : ");
            books[BookCount].Publisher = System.Console.ReadLine();

            System.Console.Write("--------------------");
        }

        public bool AskeepPutData()
        {
            System.Console.Write("계속 입력할까요? (y/n) : ");
            string userAnser = System.Console.ReadLine();

            if (userAnser == "Y" || userAnser == "y")
                return true;
            else
                return false;
        }

        public void BookSearch()
        {
            System.Console.Write("\n검색할 책 제목 : ");
            string BookTitle = System.Console.ReadLine();

            for (int i = 0; i < books.Count(); i++)
            {
                if (books[i] == null)
                {
                    System.Console.WriteLine("못찾았습니다.");
                    break;
                }
                if (books[i].title == BookTitle)
                {
                    System.Console.WriteLine($"지은이: {books[i].writerr}");
                    System.Console.WriteLine($"출판사: {books[i].Publisher}");
                    break;
                }
            }

        }


    }
    #endregion

    
    class Student
    {
        public string Name;
        public int Class;
    }
    class Classes
    {
        Student[] student = new Student[99];

        public void InputStudentData(int StudentCount)
        {
            student[StudentCount] = new Student();

            System.Console.Write("학생 이름: ");
            student[StudentCount].Name = System.Console.ReadLine();

            System.Console.Write("학생 반: ");
            student[StudentCount].Class = Convert.ToInt32(System.Console.ReadLine());

            System.Console.Write("--------------------");
        }
        
        public bool AskKeepStudentData()
        {
            System.Console.Write("계속 입력할까요? (y/n) : ");
            string userAnser = System.Console.ReadLine();

            if (userAnser == "Y" || userAnser == "y")
                return true;
            else
                return false;
        }
            
        public void ClassSearch(int StudentCount)
        {
            System.Console.WriteLine("\n검색할 반을 입력해 주세요 : ");
            int classnumber = Convert.ToInt32(System.Console.ReadLine());

            for (int i = 0; i < StudentCount; i++)
            {
                if (student[i].Class == classnumber)
                    System.Console.WriteLine($"{student[i].Name}");
            }


        }



    }


}