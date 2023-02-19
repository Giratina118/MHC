using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

public enum thePlaterState
{
    idle,
    walk,
    run
}

namespace CSharpStudy4_1
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 지난 주 클래스 문제 복습
            /*
            // 1. 통장 클래스 제작
            // 2. 본 통장 클래스에는 잔고(int)가 있음.
            // 3. 입금 / 출금 / 이체 메소드를 보유하고 있다.
            // 4. 통장 클래스를 가지고 2개의 인스턴트를 만든다. (A통장/B통장)
            // 5. 수중에 100만원을가지고 있는 것으로 시작한다. (int)

            // 6. Main에서 선택지를 띄운다. While문을 이용해서 특정 키가 돌아올 때까지 계속 반복한다.
            // 선택지 1. 입금  2. 출금  3. 이체 3가지가 있다.
            // 여기서 선택지는 항상 A통장 기준이다.

            // 7. 입금을 선택하고 금액을 입력하면 수중의 돈이 줄어들고 A통장은 금액이 추가된다.
            // A통장의 전액이 출력된다.

            // 8. 출금을 선택하고 금액을 입력하면 수중의 돈이 늘어나고 A통장의 금액은 줄어든다.
            // A통장의 전액이 출력된다.

            // 9. 예금을 선택하고 금액을 입력하면 A통장의 금액이 줄어들고 B통장의 금액이 추가된다.
            // A통장과 B통장의 전액을 출력된다.


            int MyMoney = 100;

            Bank Abank = new Bank();
            Bank Bbank = new Bank();

            while (true)
            {
                System.Console.WriteLine($"현재 수중의 돈은 {MyMoney}만원 입니다.\n");
                System.Console.WriteLine("통장에 할 행동을 선택해 주세요.");
                System.Console.WriteLine("1. 입금     2. 출금     3. 예금     4. 취소(탈출)");
                string Select = System.Console.ReadLine();

                if (Select == "4")
                    break;
                System.Console.WriteLine($"\n현재 A통장 잔고는 {Abank.BankMoney}만원 입니다.");          
                switch (Select)
                {
                    case "1":
                        MyMoney -= Abank.InputMoney(MyMoney);
                        break;
                    case "2":
                        MyMoney += Abank.OutputMoney();
                        break;
                    case "3":
                        Abank.TransferMoney(Bbank);
                        break;
                }
                System.Console.WriteLine($"현재 A통장 잔고는 {Abank.BankMoney}만원 입니다.\n");
                System.Console.WriteLine("\nㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ\n\n");

            }
            */
            #endregion

            #region 랜덤 함수
            /*
            Random rand = new Random();
            int randomInt = rand.Next(0, 10);

            Console.WriteLine("0~10사이 랜덤 : " + randomInt);
            */
            #endregion

            #region enum 열거형 사용법 예시
            /*
            thePlaterState myStste = thePlaterState.idle;

            switch (myStste)
            {
                case thePlaterState.idle:
                    System.Console.WriteLine("I'm idle");
                    break;
                case thePlaterState.walk:
                    System.Console.WriteLine("I'm Walking");
                    break;
                case thePlaterState.run:
                    System.Console.WriteLine("I'm Running");
                    break;
            }
            */
            #endregion

            #region 가위바위보 하나뺴기
            /*
            int[] Comhand = new int[2] { 0, 0 };
            int[] Myhand = new int[2] { 0, 0 };
            string[] strRSP = new string[3] { "가위", "바위", "보" };
            
            Console.WriteLine("가위바위보 낼 숫자를 2개(왼손, 오른손) 적어주세요.\n1. 가위     2. 바위     3. 보");
            for (int i = 0; i < 2; i++)
            {
                Myhand[i] = Convert.ToInt32(Console.ReadLine()) - 1;
            }

            Random rand = new Random();
            
            for (int i = 0; i < 2; i++)
            {
                Comhand[i] = rand.Next(0, 3);
                if (Comhand[0] == Comhand[1])
                {
                    i--;
                    continue;
                }
            }

            Console.WriteLine($"\n컴퓨터:   {strRSP[Comhand[0]]} \t {strRSP[Comhand[1]]}");
            Console.WriteLine($"나: \t  {strRSP[Myhand[0]]} \t {strRSP[Myhand[1]]}\n");

            Console.WriteLine($"(1)왼손 {strRSP[Myhand[0]]}와 (2)오른손 {strRSP[Myhand[1]]} 둘 중 하나빼기에 낼 하나의 숫자를 골라주세요.");

            int Choice = Convert.ToInt32(Console.ReadLine()) - 1;
            Console.WriteLine($"{strRSP[Myhand[Choice]]}");

            RSP rsp = new RSP();
            rsp.ComputerChoice(Myhand[0], Myhand[1], Comhand[0], Comhand[1]);
            

            */
            #endregion

            #region 인터페이스 연습
            /*
            Player player = new Player();
            DarkMonster dark = new DarkMonster();
            LightMonster light = new LightMonster();

            player.AttackMonster(dark);
            player.AttackMonster(light);
            */
            /*
            Player player = new Player();
            DarkMonster dark = new DarkMonster();
            Zombie zombie = new Zombie();
            Ghoul ghoul = new Ghoul();

            dark.AttackPlayer(player);
            Console.WriteLine();
            zombie.AttackPlayer(player);
            Console.WriteLine();
            ghoul.AttackPlayer(player);
            */
            #endregion

            #region 인터페이스 버츄얼 플레이어 vs 몬스터
            /*
            //1. 생명체 인터페이스 생성
            //2. 생명체에는 공격하기, 공격 받기, 회피하기, 피해받기 가 있음.
            //3. 생명체는 플레이어와 몬스터 2개가 상속받는다.
            //4. 플레이어와 몬스터가 둘 중 하나가 죽을 때까지 계속 공격하고 공격 받고를 주고받는다.
            //5. 공격하면 공격한다고 출력하고
            //6. 공격 받는 대상은 확률(랜덤)로 회피 또는 피해받기를 실행한다.
            //7. 플레이어와 몬스터 둘다 이렇게 진행한다.

            Player player = new Player();
            Monster monster = new Monster();

            while (player.hp != 0 && monster.hp != 0)
            {
                player.Attack(monster);
                Thread.Sleep(500);
                Console.WriteLine();
                monster.Attack(player);
                Thread.Sleep(500);

                Console.WriteLine("\n");
            }

            if (player.hp == 0)
            {
                Console.WriteLine("플레이어가 죽었습니다.");
            }
            if (monster.hp == 0)
            {
                Console.WriteLine("몬스터가가 죽었습니다.");
            }
            */
            #endregion

            /*
            int[] intArray = new int[3];
            List<int> intList = new List<int>() { 6, 2, 4, 6 };


            intList.Add(7);
            intList.Add(91);

            for (int i = 0; i < intList.Count; i++)
            {
                Console.WriteLine(intList[i]);
            }
            Console.WriteLine();
            intList.Remove(7);
            for (int i = 0; i < intList.Count; i++)
            {
                Console.WriteLine(intList[i]);
            }
            Console.WriteLine();
            intList.Insert(3, 9);
            for (int i = 0; i < intList.Count; i++)
            {
                Console.WriteLine(intList[i]);
            }

            intList.Clear();
            */

            #region 리스트 만들기
            /*
            //int List, string List, float List 만들기 각각 원소 5개씩
            List<int> intList = new List<int>() { 1, 2, 3, 4, 5 };
            List<float> floatList = new List<float>() { 1.1f, 2.2f, 3.3f, 4.4f, 5.5f };
            List<string> strList = new List<string>() { "aa", "bb", "cc", "dd", "ee" };


            //클래스로 리스트 만들기
            List<City> cityList = new List<City>();
            City Seoul = new City();
            Seoul.name = "Seoul";

            City Dokyo = new City();
            Dokyo.name = "Dokyo";

            City City1 = new City();
            City1.name = "City1";

            City City2 = new City();
            City2.name = "City2";

            City City3 = new City();
            City3.name = "City3";

            cityList.Add(Seoul);
            cityList.Add(Dokyo);
            cityList.Add(City1);
            cityList.Add(City2);
            cityList.Add(City3);

            for (int i = 0; i < cityList.Count; i++)
            {
                cityList[i].IntroduceCity();
            }
            */
            #endregion

            #region Dictonary< > 사전
            
            /*
            Dictionary<string, string> myDic = new Dictionary<string, string>()
            {
                {"originKey", "originValue"},
                {"originKey2", "originValue2"}
            };

            myDic.Add("addKey", "addValue");
            myDic["theKey"] = "theValue";

            Console.WriteLine(myDic["originKey"]);
            Console.WriteLine(myDic["originKey2"]);
            Console.WriteLine(myDic["addKey"]);
            Console.WriteLine(myDic["theKey"]);
            

            Dictionary<string, Monster> MonsterDic = new Dictionary<string, Monster>();

            Monster zombie = new Monster();
            Monster ghost = new Monster();
            Monster dragon = new Monster();
            Monster slime = new Monster();

            zombie.name = "Zombie";
            ghost.name = "Ghost";
            dragon.name = "Dragon";
            slime.name = "Slime";

            MonsterDic["Zombie"] = zombie;
            MonsterDic["Ghost"] = ghost;
            MonsterDic["Dragon"] = dragon;
            MonsterDic["Slime"] = slime;

            MonsterDic["Zombie"].IntroduceMonster();
            MonsterDic["Ghost"].IntroduceMonster();
            MonsterDic["Dragon"].IntroduceMonster();
            MonsterDic["Slime"].IntroduceMonster();


            Dictionary<string, string> myInfoDic = new Dictionary<string, string>();

            myInfoDic["name"] = "제 이름은 유민혁입니다.";
            myInfoDic["age"] = "제 나이는 24살입니다.";

            Console.Write("검색어를 입역하세요: ");
            string searchValue = Console.ReadLine();

            Console.WriteLine(myInfoDic[searchValue]);

            #endregion
            */
        }

    }

    #region 지난 주 클래스 문제 복습
    /*
    class Bank
    {
        public int BankMoney = 0;

        public int InputMoney(int MyMoney)
        {
            System.Console.Write("입금할 금액을 적어주세요.(단위: 만원) : ");
            int Input = Convert.ToInt32(Console.ReadLine());
            if (Input <= MyMoney)
            {
                BankMoney += Input;
                System.Console.WriteLine($"\n{Input}만원 입금되었습니다.");
            }
            else
            {
                System.Console.WriteLine("\n돈이 부족하여 입금이 취소되었습니다.");
                Input = 0;
            }

            return Input;
        }
        public int OutputMoney()
        {
            System.Console.Write("출금할 금액을 적어주세요.(단위: 만원) : ");
            int Output = Convert.ToInt32(Console.ReadLine());
            if (Output <= BankMoney)
            {
                BankMoney -= Output;
                System.Console.WriteLine($"\n{Output}만원 출금되었습니다.");
            }
            else
            {
                System.Console.WriteLine("\n돈이 부족하여 출금이 취소되었습니다.");
                Output = 0;
            }

            return Output;
        }
        public void TransferMoney(Bank Bbank)
        {
            System.Console.Write("(A통장에서 B통장으로 예금할 금액을 적어주세요.(단위: 만원) : ");
            int Trancefer = Convert.ToInt32(Console.ReadLine());

            if (Trancefer <= BankMoney)
            {
                BankMoney -= Trancefer;
                Bbank.BankMoney += Trancefer;
                System.Console.WriteLine($"\n{Trancefer}만원 예금되었습니다.");
            }
            else
                System.Console.WriteLine("\n돈이 부족하여 예금이 취소되었습니다.");
            System.Console.WriteLine($"\n현재 B통장 잔고는 {Bbank.BankMoney}만원 입니다.");
        }
    }
    */
    #endregion

    /* 가위바위보 하나빼기
    class RSP
    {
        public void ComputerChoice(int Myhand1, int Myhand2, int Comhand1, int Comhand2)
        {

        }
    }
    */

    /* 인터페이스 연습
    interface monster
    {
        void HitFromPlayer(int damage);
    }

    class DarkMonster : monster
    {
        int hp = 100;
        public void HitFromPlayer(int damage)
        {
            hp = hp - damage;
            Console.WriteLine($"Monster : I'm Hit! my Hp is {hp}");
        }
    }

    class LightMonster : monster
    {
        int hp = 100;
        public void HitFromPlayer(int damage)
        {
            hp = hp - (damage / 2);
            Console.WriteLine($"Monster : I'm Hit! but half, my Hp is {hp}");
        }
    }

    class Player
    {
        int AttackDamage = 15;

        public void AttackMonster(monster monster)
        {
            Console.WriteLine("Plater : I'm Attacking Monster!");
            monster.HitFromPlayer(AttackDamage);
        }
    }
    */

    /* virtual override abstract
    class Player
    {
        int hp = 100;
        public void HitFromPlayer(int AttackValue)
        {
            hp = hp - AttackValue;
            Console.WriteLine($"Player : I'm Hit! my Hp is {hp}");
        }
    }

    //virtual
    abstract class DarkMonster
    {
        int attackValue = 10;

        public abstract void AttackPlayer(Player player);

    }

    class Zombie : DarkMonster
    {
        public override void AttackPlayer(Player player)
        {
            Console.WriteLine("Monster : Player Bleesing");
        }
    }
    class Ghoul : DarkMonster
    {
        public override void AttackPlayer(Player player)
        {
            Console.WriteLine("Monster(Ghoul) : Player Cursel");
        }
    }
    */

    #region 인터페이스 버츄얼 플레이어 vs 몬스터
    /*
    class Entity
    {
        public virtual void Attack(Entity entity)     // 공격하기, 공격 받는 대상(적)을 매개변수로
        {

        }
        public virtual void TakeDamage()    // 공격받기
        {
            Random rand = new Random();
            int randInt = rand.Next(0, 2);
            if (randInt == 0)   // 0인 경우 데미지 안 받음, 회피
            {
                Avoid();
            }
            else            // 1인 경우 데미지 받음
            {
                ReduceHP();
            }
        }
        public virtual void Avoid()         // 회피하기
        {

        }
        public virtual void ReduceHP()      // 피해받기
        {

        }
    }
    
    class Player : Entity
    {
        public int hp = 3;
        public override void Attack(Entity entity)
        {
            Console.WriteLine("플레이어가 몬스터를 공격함!!!");
            entity.TakeDamage();
        }

        public override void Avoid()
        {
            Console.WriteLine("플레이어가 회피함!");
        }

        public override void ReduceHP()
        {
            hp--;
            Console.WriteLine($"플레이어가 데미지를 입음!  플레이어 체력 : {hp}");
        }

        public override void TakeDamage()
        {
            Random rand = new Random();
            int randInt = rand.Next(0, 2);
            if (randInt == 0)   // 0인 경우 데미지 안 받음, 회피
            {
                Avoid();
            }
            else            // 1인 경우 데미지 받음
            {
                ReduceHP();
            }
        }
        
    }

    class Monster : Entity
    {
        public int hp = 3;
        public override void Attack(Entity entity)
        {
            Console.WriteLine("몬스터가 플레이어를 공격함!!!");
            entity.TakeDamage();
        }

        public override void Avoid()
        {
            Console.WriteLine("몬스터가 회피함!");
        }

        public override void ReduceHP()
        {
            hp--;
            Console.WriteLine($"몬스터가 데미지를 입음!  몬스터 체력 : {hp}");
        }
        
        public override void TakeDamage()
        {
            Random rand = new Random();
            int randInt = rand.Next(0, 2);
            if (randInt == 0)   // 0인 경우 데미지 안 받음, 회피
            {
                Avoid();
            }
            else            // 1인 경우 데미지 받음
            {
                ReduceHP();
            }
        }
        
    }
    */
    #endregion


    class City
    {
        public string name;
        public void IntroduceCity()
        {
            Console.WriteLine($"This city is {name}");
        }
    }

    class Monster
    {
        public string name;
        public void IntroduceMonster()
        {
            Console.WriteLine($"This Monster is {name}");
        }
    }


}
