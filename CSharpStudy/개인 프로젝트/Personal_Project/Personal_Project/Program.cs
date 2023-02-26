using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Diagnostics;
using System.Drawing;

namespace Personal_Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PokemonRPG();

            /*
            Console.WriteLine("할 게임을 선택해 주세요.\n1. 경마     2. 블랙잭     3. RPG");
            int GameSelect = Convert.ToInt32(Console.ReadLine());

            switch (GameSelect)
            {
                case 1:
                {
                        HorseRacing();
                        break;
                }
                case 2:
                {
                        Blackjack();
                        break;
                }
                case 3:
                {
                        PokemonRPG();
                        break;
                }
                default:
                    Console.WriteLine("잘못 선택하셨습니다.");
                    break;
            }
            */
            

        }


        static void HorseRacing()       // 경마 Horse Racing
        {
            // 나중에 시간 남으면 말마다 승리 확률 다르게, 그에 따라 돈 배당률 다르게 설정하고 그 승률, 평균 등수, 통과 기록(시간) 보여주기

            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();

            HorseRacingSystem racingSystem = new HorseRacingSystem();
            Horse[] horse = new Horse[8];
            for (int i = 0; i < horse.Length; i++)
                horse[i] = new Horse();

            Random rand = new Random();

            racingSystem.Ready();            // 경마 준비상태에서 출발하기까지 과정

            int HorseRacingEnd;
            int Escape = 0;

            while (true)        // 모든 말이 들어올 때까지 반복
            {
                Thread.Sleep(50);
                Console.Clear();
                Console.WriteLine();
                for (int i = 0; i < horse.Length; i++)
                {
                    if (horse[i].Distance < 100)            // 아직 도착하지 않았으면 이동(말 달리기)
                    {
                        horse[i].LastDis = rand.Next(1, 5);
                        horse[i].Distance += horse[i].LastDis;
                        horse[i].GoalTime++;

                        if (horse[i].Distance >= 100)
                        {
                            i--;
                            continue;
                        }
                        horse[i].HorseDraw();
                    }
                    else
                        horse[i].GoalHorseDraw(i);
                    Console.WriteLine("                                                                                                         |");
                }

                racingSystem.RankingSystem(ref horse);      // 순위 조정
                racingSystem.RaceTrack();

                HorseRacingEnd = 0;
                for (int i = 0; i < horse.Length; i++)      // 모든 말이 결승선에 통과하면 경마 프로그램 종료
                    if (horse[i].Distance >= 100)
                        HorseRacingEnd++;

                if (HorseRacingEnd == horse.Length)         // 갱신된 랭킹으로 마지막 그림을 그리기 위해 함 번 더 프로세스 진행
                {
                    Escape++;
                    if (Escape > 1)
                        break;
                }
            }
        }

        static void Blackjack()         // 블랙잭
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            
            int[] cardSet = new int[52];                // 기본 카드더미(cardset)에 값이 0이면 그 카드가 없는 것
            for (int i = 0; i < cardSet.Length; i++)    // 나누기( / ) 13 -> 0: 스페이드,  1: 다이아,  2: 클로버,  3: 하트
                cardSet[i] = i + 1;                     // 나머지( % ) 13 -> 0~12 -> A 2 3 4 5 6 7 8 9 10 J Q K

            BlackjackPlayer player = new BlackjackPlayer();
            BlackjackComputer computer = new BlackjackComputer();

            for (int i = 0; i < 2; i++) // 플레이어(1) -> 컴퓨터(1)+플레이어(1) -> 컴퓨터(1)+플레이어(2) -> 컴퓨터(2)+플레이어(2)
            {
                player.GetCard(ref cardSet);
                computer.GetCard(ref cardSet);

                computer.ShowFieldComputer(0);
                player.ShowFieldPlayer();

                computer.ShowFieldComputer(1);
                player.ShowFieldPlayer();
                
                if (i == 0)
                    Console.Clear();
            }

            if (player.totalPoint == 21 && computer.totalPoint != 21) // 처음에 합이 21일 경우 블랙잭, 돈 1.5배(돈은 나중에 구현), 게임 끝내기
            {
                Console.WriteLine("블랙잭!     당신의 승리입니다!\n");
                return;
            }
            
            while (player.totalPoint < 21)      // 받기 싫다고 입력하거나 합 21 넘기 전까지 무한반복으로 카드 뽑기
            {
                int cardPick = player.AskPickCard();

                if (cardPick == 1)
                    break;
                else if (cardPick == 2)
                    continue;

                player.GetCard(ref cardSet);

                computer.ShowFieldComputer(1);
                player.ShowFieldPlayer();
            }

            if (player.totalPoint > 21)     // 카드 합이 21을 넘으면 바로 패배
            {
                Console.WriteLine("플레이어의 카드 합이 21을 넘었습니다.\n당신의 패배입니다.\n");
                return;
            }
            else
            {
                if (player.totalPoint == 21)
                    Console.WriteLine("플레이어의 카드 합이 21입니다.");
                Thread.Sleep(1000);

                Console.WriteLine("컴퓨터(딜러)의 차례를 시작합니다.");
                Thread.Sleep(1000);
                while (computer.totalPoint < 17)    // 딜러는 16 이하면 무조건 히트(더 뽑고), 17 이상이면 무조건 스테이(그만 뽑는다)
                {
                    computer.GetCard(ref cardSet);

                    computer.ShowFieldComputer(1);
                    player.ShowFieldPlayer();
                }
            }

            computer.ShowFieldComputer(2);
            player.ShowFieldPlayer();

            player.GameResult(computer.totalPoint);     // 승무패 결과 출력

        }

        static void PokemonRPG()
        {
            int story = 0;

            const int pokemonNum = 154;
            Pokemon[] pokemon = new Pokemon[pokemonNum];        // 텍스트 파일에서 포켓몬 정보 받아들일 배열
            for (int j = 0; j < pokemonNum; j++)
                pokemon[j] = new Pokemon();

            MyPokemon myPokemon = new MyPokemon();
            Menu menu = new Menu();
            


            List<string> pokeIndexList = new List<string>();       // 1번 ~ 151번 도감 순, 0번 -> 피카츄(스타팅으로 고른 경우만)

            string[] lines1 = File.ReadAllLines("PokemonIndex.txt");
            
            int inputData = 0;
            foreach (string line in lines1)
            {
                pokeIndexList.Add(line);
                inputData++;
            }
            
            for (int i = 0; i < 3; i++)
            {
                string[] pokeInfo = pokeIndexList[i].Split(new char[] { ' ' });
                pokemon[i].pokemonInfo[0] = Convert.ToInt32(pokeInfo[0]);    // 도감 번호

                for (int j = 0; j < 3; j++)                 // 이름, 타입1, 타입2
                    pokemon[i].nameType[j] = pokeInfo[j + 1];
                for (int j = 1; j < 10; j++)                // 능력치, 정보
                    pokemon[i].pokemonInfo[j] = Convert.ToInt32(pokeInfo[j + 3]);

                int k = 14;
                for (int j = 0; j < (pokeInfo.Length - 14) / 2; j++)      // 36개 -> 50 - 14,  18바퀴 돌면 된다.
                {
                    pokemon[i].getSkillLevel.Add(Convert.ToInt32(pokeInfo[k++]));
                    pokemon[i].Skill.Add(Convert.ToInt32(pokeInfo[k++]));
                }
            }



            const int skillNum = 154;
            Skill[] skill = new Skill[skillNum];
            for (int j = 0; j < skillNum; j++)
                skill[j] = new Skill();

            List<string> skillList = new List<string>();        // 텍스트 파일에서 스킬 정보 받아들일 배열

            string[] lines2 = File.ReadAllLines("SkillIndex");

            inputData = 0;
            foreach (string line in lines2)
            {
                skillList.Add(line);
                inputData++;
            }

            for (int i = 0; i < skillNum; i++)
            {
                string[] skillInfo = skillList[i].Split(new char[] { ' ' });
                skill[i].skillData[0] = Convert.ToInt32(skillInfo[0]);      // 기술 번호

                for (int j = 0; j < 2; j++)
                    skill[i].skillNameType[j] = skillInfo[j + 1];           // 기술 이름, 기술 타입
                for (int j = 0; j < 6; j++)
                    skill[i].skillData[j + 1] = Convert.ToInt32(skillInfo[j + 3]);  // 기술 위력 명중률 pp 부가효과 부가효과확률

            }


            Trainer trainer = new Trainer();
            Enemy enemy = new Enemy();


            ConsoleKeyInfo key;

            int x = 10;
            int y = 10;

            Map map = new Map();
            map.map1Setting();

            Console.Clear();

            while (true)
            {
                //Console.Clear();
                
                Console.SetCursorPosition(0, 0);
                map.MapDraw();

                Console.SetCursorPosition(x, y);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("★");
                key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.LeftArrow:
                        if (map.map[y, x - 2] == 0 || map.map[y, x - 2] > 100)
                        {
                            x -= 2;
                        }
                            
                        else if (map.map[y, x - 2] != 1 && map.map[y, x - 2] != 2)
                        {
                            map.MapSetting(ref x, ref y, map.map[y, x - 2]);
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (map.map[y, x + 2] == 0 || map.map[y, x + 2] > 100)
                        {
                            x += 2;
                        }
                            
                        else if (map.map[y, x + 2] != 1 && map.map[y, x + 2] != 2)
                        {
                            map.MapSetting(ref x, ref y, map.map[y, x + 2]);
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        if (map.map[y - 1, x] == 0 || map.map[y - 1, x] > 100)
                        {
                            y--;
                        }
                            
                        else if (map.map[y - 1, x] != 1 && map.map[y - 1, x] != 2)
                        {
                            map.MapSetting(ref x, ref y, map.map[y - 1, x]);
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (map.map[y + 1, x] == 0 || map.map[y + 1, x] > 100)
                        {
                            y++;
                        }
                            
                        else if (map.map[y + 1, x] != 1 && map.map[y + 1, x] != 2)
                        {
                            map.MapSetting(ref x, ref y, map.map[y + 1, x]);
                        }
                        break;
                    case ConsoleKey.Z:
                        switch (map.map[y, x])      // 스토리 진행에 따라 대사 바뀜, 나중에 스토리 클래스로 따로 뺼 것
                        {
                            case 101:
                                if (story == 0)
                                {
                                    Console.WriteLine("\n\n\n\n\n\n\n\n이 중 같이 모험할 포켓몬을 한 마리를 고르렴");
                                    Thread.Sleep(200);
                                    Console.WriteLine("이상해씨: 0,  파이리: 1,  꼬부기: 2,  피키츄: 3");
                                    int starting = Convert.ToInt32(Console.ReadLine());

                                    switch (starting)
                                    {
                                        case 3:
                                            myPokemon.hand6[0] = pokemon[0];
                                            myPokemon.hand6[0].Level = 5;
                                            myPokemon.hand6[0].RealValueSetting();
                                            myPokemon.hand6[0].WildSkillSetting();
                                            Console.WriteLine($"{myPokemon.hand6[0].nameType[0]}  Lv{myPokemon.hand6[0].Level}");
                                            Console.WriteLine($"HP: {myPokemon.hand6[0].realAbility[0]}  공격: {myPokemon.hand6[0].realAbility[1]}  방어: {myPokemon.hand6[0].realAbility[2]}  특수공격: {myPokemon.hand6[0].realAbility[3]}  특수방어: {myPokemon.hand6[0].realAbility[4]}  스피드: {myPokemon.hand6[0].realAbility[5]}");
                                            Console.WriteLine($"{myPokemon.hand6[0].Skill4[0]} {myPokemon.hand6[0].Skill4[1]} {myPokemon.hand6[0].Skill4[2]} {myPokemon.hand6[0].Skill4[2]}");
                                            Console.ReadKey();      // 키 눌러야 다음으로 넘어감
                                            break;

                                    }

                                    story++;
                                }
                                else
                                {
                                    Console.WriteLine("\n\n\n\n\n\n\n\n다른 포켓몬은 안 된다. 이 욕심쟁이야.");
                                    Console.ReadKey();
                                    trainer.DoctorOkid(pokemon);
                                    BattleSystemTrainer(myPokemon, trainer);
                                }
                                break;
                        }
                        break;
                    case ConsoleKey.X:      // 자신의 정보 보는 메뉴 창 (포켓몬, 가방, 지도, 다음 목표, 저장, 종료)
                        menu.menuCommon(myPokemon, skill);
                        break;
                }
            
            }
            

        }
        static float type_sangsung(string s, string t1, string t2)        // 타입 상성 함수, s -> 공격 기술 타입,  t1 t2 -> 방어 포켓몬 타입
        {
            string[] t0 = new string[2] { t1, t2 };         // 방어쪽 타입
            float sangsung = 1;
            string[] t = new string[18] { "노말", "불꽃", "물", "전기", "풀", "얼음", "격투", "독", "땅", "비행", "에스퍼", "벌레", "바위", "고스트", "드래곤", "악", "강철", "페어리" };

            for (int i = 0; i < 2; i++)
            {
                if (t0[i] == "없음")
                    break;
                if (s == t[0] && t0[i] == t[12] || s == t[0] && t0[i] == t[16] || s == t[1] && t0[i] == t[1] || s == t[1] && t0[i] == t[2] || s == t[1] && t0[i] == t[12] || s == t[1] && t0[i] == t[14] ||
                    s == t[2] && t0[i] == t[2] || s == t[2] && t0[i] == t[4] || s == t[2] && t0[i] == t[14] || s == t[3] && t0[i] == t[3] || s == t[3] && t0[i] == t[4] || s == t[3] && t0[i] == t[14] ||
                    s == t[4] && t0[i] == t[1] || s == t[4] && t0[i] == t[4] || s == t[4] && t0[i] == t[7] || s == t[4] && t0[i] == t[9] || s == t[4] && t0[i] == t[11] || s == t[4] && t0[i] == t[14] ||
                    s == t[4] && t0[i] == t[16] || s == t[5] && t0[i] == t[1] || s == t[5] && t0[i] == t[2] || s == t[5] && t0[i] == t[5] || s == t[5] && t0[i] == t[16] || s == t[6] && t0[i] == t[7] ||
                    s == t[6] && t0[i] == t[9] || s == t[6] && t0[i] == t[10] || s == t[6] && t0[i] == t[11] || s == t[6] && t0[i] == t[17] || s == t[7] && t0[i] == t[7] || s == t[7] && t0[i] == t[8] ||
                    s == t[7] && t0[i] == t[12] || s == t[7] && t0[i] == t[13] || s == t[8] && t0[i] == t[4] || s == t[8] && t0[i] == t[11] || s == t[9] && t0[i] == t[3] || s == t[9] && t0[i] == t[12] ||
                    s == t[9] && t0[i] == t[16] || s == t[10] && t0[i] == t[10] || s == t[10] && t0[i] == t[16] || s == t[11] && t0[i] == t[1] || s == t[11] && t0[i] == t[6] || s == t[11] && t0[i] == t[7] ||
                    s == t[11] && t0[i] == t[9] || s == t[11] && t0[i] == t[13] || s == t[11] && t0[i] == t[16] || s == t[11] && t0[i] == t[17] || s == t[12] && t0[i] == t[6] || s == t[12] && t0[i] == t[8] ||
                    s == t[12] && t0[i] == t[16] || s == t[13] && t0[i] == t[15] || s == t[14] && t0[i] == t[16] || s == t[15] && t0[i] == t[6] || s == t[15] && t0[i] == t[15] || s == t[15] && t0[i] == t[17] ||
                    s == t[16] && t0[i] == t[1] || s == t[16] && t0[i] == t[2] || s == t[16] && t0[i] == t[3] || s == t[16] && t0[i] == t[16] || s == t[17] && t0[i] == t[1] || s == t[17] && t0[i] == t[7] ||
                    s == t[17] && t0[i] == t[16])
                    sangsung *= 0.5f;

                else if (s == t[1] && t0[i] == t[4] || s == t[1] && t0[i] == t[5] || s == t[1] && t0[i] == t[11] || s == t[1] && t0[i] == t[16] || s == t[2] && t0[i] == t[1] || s == t[2] && t0[i] == t[8] ||
                    s == t[2] && t0[i] == t[12] || s == t[3] && t0[i] == t[2] || s == t[3] && t0[i] == t[9] || s == t[4] && t0[i] == t[2] || s == t[4] && t0[i] == t[8] || s == t[4] && t0[i] == t[12] ||
                    s == t[5] && t0[i] == t[4] || s == t[5] && t0[i] == t[8] || s == t[5] && t0[i] == t[9] || s == t[5] && t0[i] == t[14] || s == t[6] && t0[i] == t[0] || s == t[6] && t0[i] == t[5] ||
                    s == t[6] && t0[i] == t[12] || s == t[6] && t0[i] == t[15] || s == t[6] && t0[i] == t[16] || s == t[7] && t0[i] == t[4] || s == t[7] && t0[i] == t[17] || s == t[8] && t0[i] == t[1] ||
                    s == t[8] && t0[i] == t[3] || s == t[8] && t0[i] == t[7] || s == t[8] && t0[i] == t[12] || s == t[8] && t0[i] == t[16] || s == t[9] && t0[i] == t[4] || s == t[9] && t0[i] == t[6] ||
                    s == t[9] && t0[i] == t[11] || s == t[10] && t0[i] == t[6] || s == t[10] && t0[i] == t[7] || s == t[11] && t0[i] == t[4] || s == t[11] && t0[i] == t[10] || s == t[11] && t0[i] == t[15] ||
                    s == t[12] && t0[i] == t[1] || s == t[12] && t0[i] == t[5] || s == t[12] && t0[i] == t[9] || s == t[12] && t0[i] == t[11] || s == t[13] && t0[i] == t[10] || s == t[13] && t0[i] == t[13] ||
                    s == t[14] && t0[i] == t[14] || s == t[15] && t0[i] == t[10] || s == t[15] && t0[i] == t[13] || s == t[16] && t0[i] == t[5] || s == t[16] && t0[i] == t[12] || s == t[16] && t0[i] == t[17] ||
                    s == t[17] && t0[i] == t[6] || s == t[17] && t0[i] == t[14] || s == t[17] && t0[i] == t[15])
                    sangsung *= 2.0f;

                else if (s == t[0] && t0[i] == t[13] || s == t[3] && t0[i] == t[8] || s == t[6] && t0[i] == t[13] || s == t[7] && t0[i] == t[16] ||
                    s == t[8] && t0[i] == t[9] || s == t[10] && t0[i] == t[15] || s == t[13] && t0[i] == t[0] || s == t[14] && t0[i] == t[17])
                    sangsung *= 0.0f;

            }
            return sangsung;
        }

        static void BattleSystemTrainer(MyPokemon myPokemon, Trainer trainer)
        {
            int my = 0;
            int tr = 0;
            int turn = 0;

            Console.Clear();
            BattleField field = new BattleField();
            Console.WriteLine($"{trainer.trainerName}은(는) {trainer.hand6[0].nameType[0]}을(를) 내보냈다.");
            Thread.Sleep(500);

            while (true)
            {
                if (myPokemon.hand6[my].pokemonInfo[0] == 0 || trainer.hand6[my].pokemonInfo[0] == 0)
                    break;




            }


            Console.WriteLine($"{myPokemon.hand6[0]}");
            

            //myPokemon.hand6[0]
        }

        static int Damage()
        {
            return 0;
        }
    }

    class Horse
    {
        public int Distance;        // 총 달린 거리
        public int Ranking;         // 순위
        public int GoalTime;        // 골까지 걸린 시간(횟수)
        public int LastDis;         // 마지막(가장 최근의) 이동 거리

        public void HorseDraw()     // 현재 달리고 있는 말들 그림 표시
        {
            BehindHoresSpace();
            Console.Write("___/>");
            FrontHorseSpace();

            BehindHoresSpace();
            if (GoalTime % 2 == 0)
                Console.Write("/  \\ ");
            else
                Console.Write(" \\/  ");
            FrontHorseSpace();
        }
        public void BehindHoresSpace()      // 말 뒤(이미 말이 지나간 공간),  뒤 말 앞 순서
        {
            for (int j = 0; j < Distance / 10; j++)
                Console.Write("          ");
            for (int j = 0; j < Distance % 10; j++)
                Console.Write(" ");

            Console.ForegroundColor = ConsoleColor.DarkYellow;
        }
        public void FrontHorseSpace()       // 말 앞(말이 지나가야 할 공간),  뒤 말 앞 순서
        {
            for (int j = 0; j < (100 - Distance) / 10; j++)
                Console.Write("          ");
            for (int j = 0; j < (100 - Distance) % 10; j++)
                Console.Write(" ");

            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("|");
        }
        public void GoalHorseDraw(int i)        // 도착한 말들 그림 표시
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("                                                                                                    ___/>");

            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($"|  {i + 1}번 경주마");

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("                                                                                                    /  \\ ");

            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($"|   순위: {Ranking}등");
        }
    }
    class HorseRacingSystem
    {
        public void Ready()     // 경마 준비상태에서 출발하기까지 과정
        {
            ReadyHorseDraw();
            Countdown();
        }
        public void ReadyHorseDraw()        // 출발전 준비상태 말들 그림
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            for (int i = 0; i < 8; i++)
            {
                Console.Write(@"
___/>                                                                                                    |
/  \                                                                                                     |
                                                                                                         |"
);
            }
                
        }
        public void Countdown()     // 출발 전 카운트다운
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Thread.Sleep(500);
            Console.Write("\n");
            for (int i = 3; i > 0; i--)
            {
                Console.Beep();
                Console.Write($"{i}     ");
                Thread.Sleep(500);
            }
            Console.Beep();
            Console.Write("출발!     ");
        }
        public void RaceTrack()     // 말들 밑에 경승선까지의 거리 표시
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("     |------------------------|------------------------|------------------------|------------------------|");
            Console.WriteLine("     0                        25                       50                       75                      100");
        }
        public void RankingSystem(ref Horse[] horse)        // 말들 순위 정하는 코드
        {
            for (int i = 0; i < horse.Length; i++)
            {
                horse[i].Ranking = 1;
                for (int j = 0; j < horse.Length; j++)
                {
                    if (horse[i].GoalTime > horse[j].GoalTime)
                        horse[i].Ranking++;
                    else if (horse[i].GoalTime == horse[j].GoalTime)
                    {
                        int iGoalDetail = (100 - horse[i].Distance + horse[i].LastDis) * 60 / horse[i].LastDis;
                        int jGoalDetail = (100 - horse[j].Distance + horse[j].LastDis) * 60 / horse[j].LastDis;

                        if (iGoalDetail > jGoalDetail)
                            horse[i].Ranking++;
                        else if (iGoalDetail == jGoalDetail && horse[i].Distance < horse[j].Distance)
                            horse[i].Ranking++;

                    }
                }
            }
        }
        
    }

    class Card      // 상속으로 플레이어와 컴퓨터 구분하기
    {
        public int[] card = new int[11];        // 현재 가지고 있는 카드들 정보
        public int[] handPoint = new int[11];   // 현재 가지고 있는 카드들의 점수 정보
        public string[] cardPattern = new string[4] { "♠", "◆", "♣", "♥" };     
        public string[] cardNumber = new string[13] { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
        public int[] cardPoint = new int[13] { 11, 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10 };
        public int totalPoint;                  // 현재 카드 점수 합
        public int hand;                        // 가지고 있는 카드 수

        public void CardPrint(int i)        // 카드 그림 그리기 종합(위쪽 + 중간 + 아래쪽)
        {
            CardPrintTop(i);
            CardPrintMiddleNormal(i);
            CardPrintBottom(i);
        }
        public void CardPrintTop(int i)     // 카드 그림 그리기 (위쪽, 숫자 나오기 전) │
        {
            for (int j = 0; j <= i; j++)
                Console.Write(" ㅡㅡㅡ   ");
            Console.WriteLine();
            for (int j = 0; j <= i; j++)
                Console.Write("ㅣ    ㅣ  ");
            Console.WriteLine();
        }
        public void CardPrintMiddleNormal(int i)        // 카드 그림 그리기 (중간, 숫자 포함)
        {
            for (int j = 0; j <= i; j++)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("ㅣ");

                CardPrintMiddle(j);
            }
        }
        public void CardPrintMiddle(int j)          // 카드 그림 그리기 (중간, 무늬, 숫자 부분만)
        {
            if ((card[j] / 13) % 2 == 1)
                Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"{cardPattern[card[j] / 13]}");

            if (card[j] % 13 == 9)
                Console.Write($"{cardNumber[card[j] % 13]}");
            else
                Console.Write($" {cardNumber[card[j] % 13]}");

            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("ㅣ  ");
        }
        public void CardPrintBottom(int i)          // 카드 그림 그리기 (아래쪽, 숫자 이후)
        {
            Console.WriteLine();
            for (int j = 0; j <= i; j++)
                Console.Write("ㅣ    ㅣ  ");
            Console.WriteLine();
            for (int j = 0; j <= i; j++)
                Console.Write(" ㅡㅡㅡ   ");
        }
        public void GetCard(ref int[] cardSet)          // 카드 랜덤으로 뽑아 얻기
        {
            Random rand = new Random();
            while (true)
            {
                int randomCard = rand.Next(0, 52);
                if (cardSet[randomCard] != 0)
                {
                    card[hand] = randomCard;
                    cardSet[randomCard] = 0;
                    totalPoint += cardPoint[card[hand] % 13];
                    handPoint[hand] = cardPoint[card[hand] % 13];
                    hand++;
                    break;
                }
            }
            if (totalPoint > 21)        // 21을 넘었을 때 A를 11에서 1로 바꾸기
                AnumChange();
        }
        public void AnumChange()        // 21을 넘었을 때 A를 11에서 1로 바꾸기
        {
            for (int j = 0; j < hand; j++)
            {
                if (handPoint[j] == 11)
                {
                    handPoint[j] = 1;
                    totalPoint -= 10;
                    break;
                }
            }
        }
    }

    class BlackjackPlayer : Card
    {
        public int AskPickCard()        // 카드 더 뽑을지 여부 묻기
        {
            Console.Write("카드를 뽑으시겠습니까? ( Y / N ): ");
            string YorN = Console.ReadLine();

            if (YorN == "N" || YorN == "n")
            {
                Console.WriteLine("그만 뽑기를 선택하셨습니다.");
                Thread.Sleep(1000);
                return 1;
            }
            else if (YorN != "Y" && YorN != "y")
            {
                Console.WriteLine("잘못 입력되었습니다. 다시 입력해주세요.");
                return 2;
            }
            return 3;
        }
        public void ShowFieldPlayer()       // 플레이어 카드 정보 화면 출력 (컴퓨터 카드 정보 아래 화면)
        {
            Console.WriteLine($"\n\n\n\n\n\n\n플레이어 카드\t\t\t\t\t\t\t\t   플레이어 카드 합: {totalPoint}\n");
            CardPrint(hand - 1);

            Console.WriteLine("\nㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ\n");
            Thread.Sleep(1000);
        }
        public void GameResult(int computerTotal)  // 게임 결과, (승, 무, 패) 결정
        {
            if (computerTotal > 21)       // 딜러가 21을 넘으면 바로 딜러 패배(플레이어 승리)
                Console.WriteLine("컴퓨터(딜러)의 카드 합이 21을 넘었습니다.\n당신의 승리입니다.\n");
            else        // 21을 넘지 않으면 (17 ~ 21)에서 스테이 되면 플레이어와 숫자 비교하여 승무패 결정
            {
                if (totalPoint > computerTotal)
                    Console.WriteLine("당신의 승리입니다.\n");
                else if (totalPoint < computerTotal)
                    Console.WriteLine("당신의 패배입니다.\n");
                else
                    Console.WriteLine("무승부입니다.\n");
            }
        }
    }
    class BlackjackComputer : Card
    {
        public void CardPrintCom(int i)     // 카드 그리기 종합 (컴퓨터의 1번 카드 안 보이도록 처리)
        {
            CardPrintTop(i);
            CardPrintMiddleHidden(i);
            CardPrintBottom(i);
        }
        public void CardPrintMiddleHidden(int i)    // 컴퓨터의 첫번째 패 숨기기
        {
            for (int j = 0; j <= i; j++)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("ㅣ");

                if (j == 0)
                {
                    Console.Write("  ? ㅣ  ");
                    continue;
                }

                CardPrintMiddle(j);
            }
        }
        public void ShowFieldComputer(int i)        // 컴퓨터 카드 정보 화면 출력 (플레이어 카드 정보 위 화면)
        {
            Console.Clear();
            switch (i)
            {
                case 0:
                    Console.WriteLine("\n\n컴퓨터(딜러) 카드\n");
                    if (hand == 1)
                        Console.WriteLine("\n\n\n");
                    else if (hand == 2)
                        CardPrintCom(0);
                    break;
                case 1:
                    Console.WriteLine("\n\n컴퓨터(딜러) 카드\n");
                    CardPrintCom(hand - 1);
                    break;
                case 2:
                    Console.WriteLine($"\n\n컴퓨터(딜러) 카드\t\t\t\t\t\t       컴퓨터(딜러) 카드 합: {totalPoint}\n");
                    CardPrint(hand - 1);
                    break;
                default:
                    break;
            }
        }
    }


    

    class Pokemon
    {

        // 포켓몬 파일, 기술 파일 따로 만들고 포켓몬 파일에 기술의 번호만 적기, 그 번호를 총해 기술 사용
        public string[] nameType = new string[3];       // 0: 이름,  1: 타입1,  2: 타입2
        public int[] pokemonInfo = new int[11];         // 0: 도감번호,  1: 체력종족값,  2: 공격종족값,  3: 방어종족값,  4: 특수공격종족값,  5: 특수방어종족값,  6: 스피드 종족값,  
                                                        // 7: 진화레벨,  8: 진화포켓몬(의 도감번호),  9: 포획률,  10: 필요경험치(필요한 경험치의 유형, 빠름 보통 느림)
        public List<int> getSkillLevel = new List<int>();   // 스킬을 배우는 레벨
        public List<int> Skill = new List<int>();           // 배우는 스킬, getSkillLevel[i]의 레벨때 Skill[i]의 스킬을 배운다
        public int Level = 1;

        public int[] realAbility = new int[6];          // 0: 체력실수치,  1: 공격실수치,  2: 방어실수치,  3: 특수공격실수치,  4: 특수방어실수치,  5: 스피드실수치
        public int[] rank = new int[6];                 // 랭크업 (0: 체력,  1: 공격,  2: 방어,  3: 특공,  4: 특방,  5: 스피드)
        public int[] rate = new int[3];                 // 0: 명중률,  1: 회피율,  2: 급소율
        public int[] condition = new int[10];           // 상태이상 (0: 독,  1: 맹독,  2: 화상,  3: 마비,  4: 잠듦,  5: 얼음,  6: 맹독 턴,  7: 잠듦 턴,  8: 혼란,  9: 혼란 턴,  10: 풀죽음
        public int nowHP;                               // 현재 HP
        public int[] Exp = new int[3];                  // 0: 다음 레벨까지 경험치,  1: 현재 경험치,  2: 넘친 경험치
        public int[] Skill4 = new int[4];               // 가지고 있는 기술 4개
        
        public void RealValueSetting()
        {
            realAbility[0] = pokemonInfo[1] * 2 * Level / 100 + Level + 10;
            for (int i = 0; i < 5; i++)
                realAbility[i + 1] = pokemonInfo[i + 2] * 2 * Level / 100 + 5;


            switch (pokemonInfo[10])
            {
                case 0:
                    Exp[0] = (3 * Level * Level - 3 * Level + 1) * 4 / 5;
                    break;
                case 1:
                    Exp[0] = 3 * Level * Level - 3 * Level + 1;
                    break;
                case 2:
                    Exp[0] = (3 * Level * Level - 3 * Level + 1) * 5 / 4;
                    break;
            }

            Exp[0] = 3 * Level * Level - 3 * Level + 1;
            nowHP = realAbility[0];
        }

        public void WildSkillSetting()
        {
            int count = 0;
            for (int i = 0; i < Level; i++)
            {
                if (getSkillLevel[i] <= Level)
                {
                    Skill4[count] = Skill[i];
                    count++;
                }
            }
        }

        public void SkillSetting()
        {

        }
        public void LevelUp(Skill[] skill)
        {
            Console.WriteLine($"레벨이 {Level - 1}에서 {Level}(으)로 올랐습니다.");
            Console.ReadKey();
            Exp[2] = Exp[1] - Exp[0];
            Exp[1] = 0;
            RealValueSetting();
            Exp[0] += Exp[2];
            Exp[2] = 0;

            for (int i = 0; i < getSkillLevel.Count; i++)
            {
                if (getSkillLevel[i] == Level)
                {
                    Console.WriteLine($"{nameType[0]}은(는) {skill[Skill[i]].skillNameType[0]}을(를) 배우고 싶다.");
                    Thread.Sleep(5000);
                }
                break;
            }
        }

    }


    class MyPokemon : Pokemon
    {
        public Pokemon[] hand6 = new Pokemon[6];
        public Pokemon[,] pokeBox = new Pokemon[8, 30];

    }

    class Enemy : Pokemon
    {
        public Pokemon[] hand6 = new Pokemon[6];
    }

    class Trainer : Enemy
    {
        public string trainerName = "오박사";

        public void DoctorOkid (Pokemon[] pokemon)
        {
            hand6[0] = pokemon[0];
            hand6[0].Level = 2;

            hand6[1] = pokemon[1];
            hand6[1].Level = 3;

            hand6[0].RealValueSetting();
            hand6[1].RealValueSetting();

            hand6[0].Skill4[0] = 79;
            hand6[0].Skill4[1] = 125;
            hand6[0].Skill4[2] = 126;
            hand6[0].Skill4[3] = 9;

            hand6[1].Skill4[0] = 79;
            hand6[1].Skill4[1] = 125;
            hand6[1].Skill4[2] = 126;
            hand6[1].Skill4[3] = 9;

        }
    }

    class BattleField
    {
        public void VsTrainer(MyPokemon myPokemon, Trainer trainer, int my, int tr)
        {
            Console.Clear();
            Console.WriteLine($"\n\n\n\t\t\t\t\t\t\t\t\t\t{trainer.hand6[tr].nameType[0]}");
            Console.WriteLine($"\t\t\t\t\t\t\t\t\t\tHP: {trainer.hand6[tr].nowHP} / {trainer.hand6[tr].realAbility[0]}");
            Console.WriteLine($"\n\n\n\n\n\n\n\n\n\n\t{myPokemon.hand6[my].nameType[0]}");
            Console.WriteLine($"\tHP: {myPokemon.hand6[my].nowHP} / {myPokemon.hand6[my].realAbility[0]}");
        }
    }

    class Map   // x축(2차원배열의 2번째 숫자)은 2칸씩 이동이기에 실제 칸 수 x2 - 1, 홀수로 할것
    {           // 0: 지나다닐 수 있는 도로,  1: 지나다닐 수 없는 벽,  2: 바다,  3: 내리막길(일방통행만 가능),  4 ~: 다른 맵으로 이동, 이벤트 발동
        //int x = 45;
        //int y = 23;
        public int[,] map = new int[200, 200];
        public int nowMap;

        public void MapSetting(ref int x, ref int y, int mapnum)
        {
            Console.Clear();
            for (int i = 0; i < 200; i++)
            {
                for (int j = 0; j < 200; j++)
                {
                    map[i, j] = 0;
                }
            }

            switch (mapnum)
            {
                case 0:
                    map1Setting();
                    break;
                case 6:
                    pokemonLabSetting();
                    x = 12;
                    y = 9;
                    nowMap = 1;
                    break;
                case 7:
                    x = 46;
                    y = 18;
                    nowMap = 0;
                    break;

            }
        }
        public void MapDraw()
        {
            switch (nowMap)
            {
                case 0:
                    map1Draw();
                    break;
                case 1:
                    pokemonLabDraw();
                    break;
            }
        }

        public void map1Setting()           5여기 // 맵 이동할 때 안 되는거 고치기
        {
            /*
            int x = 45;
            int y = 23;
            for (int i = 0; i < y; i++)
            {
                if (i < 2 || i > y - 3)
                    for (int j = 0; j < x; j++)
                        map[i, j] = 1;
                else
                {
                    for (int j = 0; j < x; j++)
                    {
                        if (j < 3 || j > x - 4)
                            map[i, j] = 1;
                        else
                            map[i, j] = 0;
                    }
                }
            }

            for (int i = 19; i <= 25; i++)
                map[0, i] = 3;
            for (int i = 19; i <= 25; i++)
                map[1, i] = 0;

            for (int i = 12; i <= 14; i++)
                map[4,i] = 1;
            for (int i = 30; i <= 31; i++)
                map[4, i] = 1;

            for (int i = 10; i <= 16; i++)
                map[5, i] = 1;
            for (int i = 28; i <= 34; i++)
                map[5, i] = 1;

            for (int i = 8; i <= 18; i++)
                map[6, i] = 1;
            for (int i = 26; i <= 36; i++)
                map[6, i] = 1;

            for (int i = 10; i <= 16; i++)
                map[7, i] = 1;
            for (int i = 28; i <= 34; i++)
                map[7, i] = 1;

            for (int i = 10; i <= 16; i++)
                map[8, i] = 1;
            for (int i = 28; i <= 34; i++)
                map[8, i] = 1;

            for (int i = 10; i <= 16; i++)
                map[9, i] = 1;
            for (int i = 28; i <= 34; i++)
                map[9, i] = 1;

            for (int i = 26; i <= 36; i++)
                map[12, i] = 1;
            for (int i = 26; i <= 36; i++)
                map[13, i] = 1;
            for (int i = 26; i <= 36; i++)
                map[14, i] = 1;
            for (int i = 26; i <= 36; i++)
                map[15, i] = 1;
            for (int i = 26; i <= 36; i++)
                map[16, i] = 1;

            map[9, 12] = 4;
            map[9, 30] = 5;
            map[16, 30] = 6;
            */

            int x = 66;
            int y = 23;
            for (int i = 0; i < y; i++)
            {
                if (i < 2 || i > y - 3)
                    for (int j = 0; j < x; j++)
                        map[i, j] = 1;
                else
                {
                    for (int j = 0; j < x; j++)
                    {
                        if (j < 4 || j > x - 5)
                            map[i, j] = 1;
                        else
                            map[i, j] = 0;
                    }
                }
            }

            for (int i = 30; i <= 35; i++)
                map[0, i] = 3;
            for (int i = 30; i <= 35; i++)
                map[1, i] = 0;

            for (int i = 16; i <= 21; i++)
                map[4, i] = 1;
            for (int i = 44; i <= 49; i++)
                map[4, i] = 1;

            for (int i = 12; i <= 25; i++)
                map[5, i] = 1;
            for (int i = 40; i <= 53; i++)
                map[5, i] = 1;

            for (int i = 8; i <= 29; i++)
                map[6, i] = 1;
            for (int i = 36; i <= 59; i++)
                map[6, i] = 1;

            for (int i = 12; i <= 25; i++)
                map[7, i] = 1;
            for (int i = 40; i <= 53; i++)
                map[7, i] = 1;

            for (int i = 12; i <= 25; i++)
                map[8, i] = 1;
            for (int i = 40; i <= 53; i++)
                map[8, i] = 1;

            for (int i = 12; i <= 25; i++)
                map[9, i] = 1;
            for (int i = 40; i <= 53; i++)
                map[9, i] = 1;

            for (int i = 36; i <= 57; i++)
                map[13, i] = 1;
            for (int i = 36; i <= 57; i++)
                map[14, i] = 1;
            for (int i = 36; i <= 57; i++)
                map[15, i] = 1;
            for (int i = 36; i <= 57; i++)
                map[16, i] = 1;
            for (int i = 36; i <= 57; i++)
                map[17, i] = 1;

            map[9, 18] = 4;
            map[9, 46] = 5;
            map[17, 46] = 6;
            



        }

        public void map1Draw()
        {
            /*
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 40; j++)
                {
                    if (map1[i, j] == 1)
                        Console.ForegroundColor = ConsoleColor.White;
                    else
                        Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("■");
                }
                Console.WriteLine();
            }
            */

            Console.ForegroundColor = ConsoleColor.White;

            // 이 화면에선 네모 1칸이 스페이스바 2칸과 같은 간격으로 나오지만
            // 콘솔 창에선 스페이스바 1칸과 네모 1칸이 같은 간격으로 나온다
            /*
            Console.WriteLine(@"■■■■■■■■■■■■■■■■■■■       ■■■■■■■■■■■■■■■■■■■
■■■■■■■■■■■■■■■■■■■       ■■■■■■■■■■■■■■■■■■■
■■■                                       ■■■
■■■                                       ■■■
■■■         ■■■               ■■■         ■■■
■■■       ■■■■■■■           ■■■■■■■       ■■■
■■■     ■■■■■■■■■■■       ■■■■■■■■■■■     ■■■
■■■       ■■■■■■■           ■■■■■■■       ■■■
■■■       ■■■■■■■           ■■■■■■■       ■■■
■■■       ■■∩■■■■           ■■∩■■■■       ■■■
■■■                                       ■■■
■■■                                       ■■■
■■■                       ■■■■■■■■■■■     ■■■
■■■                      포켓몬 연구소    ■■■
■■■                       ■■■■■■■■■■■     ■■■
■■■                       ■■■■■■■■■■■     ■■■
■■■                       ■■■■∩■■■■■■     ■■■
■■■                                       ■■■
■■■                                       ■■■
■■■                                       ■■■
■■■                                       ■■■
■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■");
            */
            
            Console.WriteLine(@"■■■■■■■■■■■■■■■      ■■■■■■■■■■■■■■■
■■■■■■■■■■■■■■■      ■■■■■■■■■■■■■■■
■■                                                          ■■
■■                                                          ■■
■■            ■■■                      ■■■            ■■
■■        ■■■■■■■              ■■■■■■■        ■■
■■    ■■■■■■■■■■■      ■■■■■■■■■■■    ■■
■■        ■■■■■■■              ■■■■■■■        ■■
■■        ■■■■■■■              ■■■■■■■        ■■
■■        ■■■∩■■■              ■■■∩■■■        ■■
■■                                                          ■■
■■                                                          ■■
■■                                                          ■■
■■                                ■■■■■■■■■■■    ■■
■■                                ■  포켓몬  연구소  ■    ■■
■■                                ■■■■■■■■■■■    ■■
■■                                ■■■■■■■■■■■    ■■
■■                                ■■■■■∩■■■■■    ■■
■■                                                          ■■
■■                                                          ■■
■■                                                          ■■
■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■");



        }

        public void pokemonLabSetting()
        {
            int x = 26;
            int y = 11;
            for (int i = 0; i < y; i++)
            {
                if (i == 0 || i == y - 1)
                    for (int j = 0; j < x; j++)
                        map[i, j] = 1;
                else
                {
                    for (int j = 0; j < x; j++)
                    {
                        if (j < 2 || j > x - 3)
                            map[i, j] = 1;
                        else
                            map[i, j] = 0;
                    }
                }
            }

            map[10, 12] = 7;
            map[3, 12] = 1;
            map[2, 12] = map[4, 12] = map[3, 10] = map[3, 14] = 101;

        }

        public void pokemonLabDraw()
        {
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine(@"■■■■■■■■■■■■■
■                      ■
■                      ■
■          ★          ■
■                      ■
■                      ■
■                      ■
■                      ■
■                      ■
■                      ■
■■■■■■  ■■■■■■");
        }



    }

    class Menu
    {

        public void menuCommon(MyPokemon myPokemon, Skill[] skill)        // 자신의 정보 보는 메뉴 창 (포켓몬, 가방, 지도, 다음 목표, 저장, 뒤로, 게임 종료)
        {
            int x = 0;
            int y = 0;
            

            while (true)
            {
                int exit = 0;
                Console.Clear();

                Console.WriteLine(@"   포켓몬
   가방
   지도
   내 정보
   다음 목표
   저장
   게임 종료
   뒤로");
                Console.SetCursorPosition(x, y);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("▶");

                ConsoleKeyInfo key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (y > 0)
                            y--;
                        break;
                    case ConsoleKey.DownArrow:
                        if (y < 7)
                            y++;
                        break;
                    case ConsoleKey.Z:
                        if (y == 0)
                        {
                            menuPokemon(myPokemon, skill);
                        }
                        else if (y == 7)
                        {
                            exit = 1;
                        }
                        break;
                }
                if (exit == 1)
                    break;
            }

        }

        public void menuPokemon(MyPokemon myPokemon, Skill[] skill)
        {
            Console.Clear();
            for (int i = 0; i < 1; i++)
            {
                Console.WriteLine($"   {myPokemon.hand6[i].nameType[0]}     Lv{myPokemon.hand6[i].Level}    타입: {myPokemon.hand6[i].nameType[1]}, {myPokemon.hand6[i].nameType[2]}    HP: {myPokemon.hand6[i].nowHP} / {myPokemon.hand6[i].realAbility[0]}    EXP: {myPokemon.hand6[i].Exp[1]} / {myPokemon.hand6[i].Exp[0]}");
                Console.WriteLine($"            공격: {myPokemon.hand6[i].realAbility[1]}   방어: {myPokemon.hand6[i].realAbility[2]}   특수공격: {myPokemon.hand6[i].realAbility[3]}   특수방어: {myPokemon.hand6[i].realAbility[4]}   스피드: {myPokemon.hand6[i].realAbility[5]}");
                Console.Write($"            기술: ");
                for (int j = 0; j < 4; j++)
                {
                    if (myPokemon.hand6[i].Skill4[j] < 1)
                        break;
                    Console.Write($"{skill[myPokemon.hand6[i].Skill4[j] - 1].skillNameType[0]} ");

                }
                Console.ReadKey();
            }
            
        }
    }

    class Skill
    {
        // 번호 이름 타입 위력 명중률 pp 우선도 특수효과종류 특수효과확률
        public int[] skillData = new int[7]; // 0: 번호  1: 위력  2: 명중률  3: pp  4: 우선도  5: 특수효과종류  6: 특수효과확률
        public string[] skillNameType = new string[2]; // 0: 스킬 이름  1: 스킬 타입
        public int skillpp;

        public void skillPPreset()
        {
            skillpp = skillData[4];
        }
        

        /*
        0없음 1독 2맹독 3화상 4마비 5잠듦 6얼음 7혼란 8풀죽음 9급소확률1랭높음 10확정급소 
        11상대공격1랭다운 12상대공격2랭다운 13상대방어1랭다운 14상대방어2랭다운
        15상대특공1랭다운 16상대특공2랭다운 17상대특방1랭다운 18상대특방2랭다운
        19상대스피드1랭다운 20상대스피드2랭다운
        21자신공격1랭업 22자신공격2랭업 23자신방어1랭업 24자신방어2랭업
        25자신특공1랭업 26자신특공2랭업 27자신특방1랭업 28자신특방2랭업
        29자신스피드1랭업 30자신스피드2랭업
        311/2흡수 321/2회복 33아쿠아링(매턴1/16회복) 34리플랙터(물리1/2) 35빛의장막(특수1/2)
        36자신공특공1랭업 37자신공방1랭업 38자신특공특방1랭업 39자신공격스피드1랭업
        40자신방특방1랭다운,공특공스피드2랭업
        41다음턴못움직임 421/4반동 43숨었다공격 44자신특공,상대물리방어로공격계산
        45상대빛의장막,리플렉터 파괴 
        46자신스피드1랭다운 47자신방특방1랭다운 48자신특공2랭다운
        49상대의hp제외한능력치,기술(pp5)을복사(변신)
        */


    }

    class Stroy
    {

    }

}