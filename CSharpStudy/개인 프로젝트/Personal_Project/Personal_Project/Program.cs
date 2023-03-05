using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.Serialization.Formatters;
using System.Diagnostics.Eventing.Reader;
using static System.Net.Mime.MediaTypeNames;
using System.Runtime.CompilerServices;
using System.Configuration;
using System.Xml.Serialization;
using System.Reflection;
using System.Dynamic;

namespace Personal_Project
{
    internal class Program

    {
        static void Main(string[] args)
        {
            //Splendor();
            bool game = true;

            while (game)
            {
                Console.Clear();
                Console.WriteLine("할 게임을 선택해 주세요.\n1. 경마     2. 블랙잭     3. 스플랜더");
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
                            Splendor();
                            break;
                        }
                    default:
                        Console.WriteLine("잘못 선택하셨습니다.");
                        break;
                }
                Console.ReadKey();
                if (gameEnd() == 0)
                    break;

            }
        }

        static int gameEnd()        // 게임 종료 여부 묻기
        {
            while (true)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();
                Console.Write("게임을 계속하시겠습니까? ( Y / N ): ");
                string keepGoing = Console.ReadLine();

                if (keepGoing == "y" || keepGoing == "Y")
                    return 1;
                else if (keepGoing == "n" || keepGoing == "N")
                    return 0;
            }
        }

        static void HorseRacing()       // 경마
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


        static void Splendor()          // 스플랜더
        {
            SplendorSystem spSystem = new SplendorSystem();
            SplendorCardInfo card = new SplendorCardInfo();
            RoyalInfo royal = new RoyalInfo();
            SplendorField field = new SplendorField();
            SplendorPlayer[] players;
            enemyPlayerInfo enemy = new enemyPlayerInfo();
            int playerNum = 0;
            card.cardSet();
            royal.royalSet();
            field.fieldCardFirstSet(card);
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            bool game = true;

            while (true)
            {
                Console.Write("몇인용으로 플레이할지 입력해 주세요(2인 ~ 4인): ");    // 몇인용 게임인지 설정
                playerNum = Convert.ToInt32(Console.ReadLine());
                if (playerNum < 2 || playerNum > 4)
                    continue;
                players = new SplendorPlayer[playerNum];
                for (int i = 0; i < playerNum; i++)
                    players[i] = new SplendorPlayer();
                break;
            }
            field.fieldTokenRoyalFirstSet(royal, playerNum);

            while (game)
            {
                int action = 0;
                for (int i = 0; i < playerNum; i++)
                {
                    Console.Clear();
                    
                    //enemy.ShowEnemyPlayerInfo(players, playerNum, i, field);

                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    field.ShowField(playerNum, card);
                    Console.WriteLine($"\n플레이어{i + 1}의 차례");
                    players[i].ShowPlayerInfo();

                    Console.WriteLine("토큰 가져오기(1)     카드 구매하기(2)");
                    action = Convert.ToInt32(Console.ReadLine());
                    if (action == 1)
                    {
                        Console.WriteLine("다른 종류 토큰 3개 가져오기(1)  같은 종류 토큰 2개 가져오기(2)  조커 토큰 1개 가져오기(3)");
                        int tokenAction = Convert.ToInt32(Console.ReadLine()); 
                        
                        if (tokenAction == 1)
                        {
                            int able = 0;
                            for (int j = 0; j < 5; j++)
                                if (field.token[j] != 0)
                                    able++;

                            Console.WriteLine("어떤 토큰을 가져올지 선택해 주세요 ( 하양(0)  파랑(1)  초록(2)  빨강(3)  검정(4) )");
                            
                            if (able == 2)
                            {
                                Console.WriteLine("주의! 필드 위에 남은 토큰 수가 적어 2개의 토큰만 가져올 수 있습니다.");
                                int token1 = Convert.ToInt32(Console.ReadLine());
                                int token2 = Convert.ToInt32(Console.ReadLine());
                                if (token1 < 0 || token1 > 4 || token2 < 0 || token2 > 4)
                                {
                                    i += spSystem.Backint(0);   // 숫자 벗어남, 필드 토큰 부족, 토큰 부족, 중복 금지, 4개 이상
                                    continue;
                                }
                                if (field.token[token1] == 0 || field.token[token2] == 0)
                                {
                                    i += spSystem.Backint(1);   // 숫자 벗어남, 필드 토큰 부족, 토큰 부족, 중복 금지, 4개 이상
                                    continue;
                                }
                                if (token1 == token2)
                                {
                                    i += spSystem.Backint(3);   // 숫자 벗어남, 필드 토큰 부족, 토큰 부족, 중복 금지, 4개 이상
                                    continue;
                                }
                                players[i].ownToken[token1]++;
                                players[i].ownToken[token2]++;
                                field.token[token1]--;
                                field.token[token2]--;
                            }
                            else if (able == 1)
                            {
                                Console.WriteLine("주의! 필드 위에 남은 토큰 수가 적어 1개의 토큰만 가져올 수 있습니다.");
                                int token1 = Convert.ToInt32(Console.ReadLine());
                                if (token1 < 0 || token1 > 4)
                                {
                                    i += spSystem.Backint(0);   // 숫자 벗어남, 필드 토큰 부족, 토큰 부족, 중복 금지, 4개 이상
                                    continue;
                                }
                                if (field.token[token1] == 0)
                                {
                                    i += spSystem.Backint(1);   // 숫자 벗어남, 필드 토큰 부족, 토큰 부족, 중복 금지, 4개 이상
                                    continue;
                                }
                                players[i].ownToken[token1]++;
                                field.token[token1]--;
                            }
                            else
                            {
                                int token1 = Convert.ToInt32(Console.ReadLine());
                                int token2 = Convert.ToInt32(Console.ReadLine());
                                int token3 = Convert.ToInt32(Console.ReadLine());
                                if (token1 < 0 || token1 > 4 || token2 < 0 || token2 > 4 || token3 < 0 || token3 > 4)
                                {
                                    i += spSystem.Backint(0);   // 숫자 벗어남, 필드 토큰 부족, 토큰 부족, 중복 금지, 4개 이상
                                    continue;
                                }
                                if (field.token[token1] <= 0 || field.token[token2] <= 0 || field.token[token3] <= 0)
                                {
                                    i += spSystem.Backint(1);   // 숫자 벗어남, 필드 토큰 부족, 토큰 부족, 중복 금지, 4개 이상
                                    continue;
                                }
                                if (token1 == token2 || token1 == token3 || token2 == token3)
                                {
                                    i += spSystem.Backint(3);   // 숫자 벗어남, 필드 토큰 부족, 토큰 부족, 중복 금지, 4개 이상
                                    continue;
                                }
                                players[i].ownToken[token1]++;
                                players[i].ownToken[token2]++;
                                players[i].ownToken[token3]++;
                                field.token[token1]--;
                                field.token[token2]--;
                                field.token[token3]--;
                            }
                        }
                        else if (tokenAction == 2)
                        {
                            int able = 0;
                            for (int j = 0; j < 5; j++)
                                if (field.token[j] >= 4)
                                    able++;
                            if (able == 0)
                            {
                                i += spSystem.Backint(4);   // 숫자 벗어남, 필드 토큰 부족, 토큰 부족, 중복 금지, 4개 이상
                                continue;
                            }
                            Console.WriteLine("어떤 토큰을 가져올지 선택해 주세요 ( 하양(0)  파랑(1)  초록(2)  빨강(3)  검정(4) )");
                            int token1 = Convert.ToInt32(Console.ReadLine());
                            if (field.token[token1] < 4)
                            {
                                i += spSystem.Backint(4);   // 숫자 벗어남, 필드 토큰 부족, 토큰 부족, 중복 금지, 4개 이상
                                continue;
                            }
                            if (token1 < 0 || token1 > 4)
                            {
                                i += spSystem.Backint(0);   // 숫자 벗어남, 필드 토큰 부족, 토큰 부족, 중복 금지, 4개 이상
                                continue;
                            }

                            players[i].ownToken[token1] += 2;
                            field.token[token1] -= 2;
                        }
                        else if (tokenAction == 3)
                        {
                            if (field.token[5] == 0)
                            {
                                i += spSystem.Backint(2);   // 숫자 벗어남, 필드 토큰 부족, 토큰 부족, 중복 금지, 4개 이상
                                continue;
                            }
                            players[i].ownToken[5]++;
                            field.token[5]--;
                        }
                        else
                        {
                            i += spSystem.Backint(0);   // 숫자 벗어남, 필드 토큰 부족, 토큰 부족, 중복 금지, 4개 이상
                            continue;
                        }

                        spSystem.TokenOver10(players, field, card, i, playerNum, enemy);
                        #region
                        
                        int totalToken = 0;
                        for (int j = 0; j < 6; j++)
                            totalToken += players[i].ownToken[j];
                        if (totalToken > 10)
                        {
                            while (totalToken > 10)
                            {
                                field.ShowField(playerNum, card);
                                Console.WriteLine($"\n플레이어{i + 1}의 차례");
                                players[i].ShowPlayerInfo();
                                Console.WriteLine("소지 중인 토큰의 수가 10개를 초과했습니다. 버릴 토큰을 하나씩 선택해 주세요.( 하양(0)  파랑(1)  초록(2)  빨강(3)  검정(4)  조커(5))");
                                int tokenReturn = Convert.ToInt32(Console.ReadLine());
                                if (tokenReturn >= 0 && tokenReturn <= 5)
                                {
                                    players[i].ownToken[tokenReturn]--;
                                    field.token[tokenReturn]++;
                                    totalToken--;
                                }
                            }
                        }
                        
                        #endregion
                    }
                    else if (action == 2)
                    {
                        bool able = true;
                        int joker = players[i].ownToken[5];

                        Console.WriteLine("구매할 카드를 선택해 주세요(카드의 우측 하단 번호): ");
                        int buy = Convert.ToInt32(Console.ReadLine());
                        if (buy < 0 || buy > 11)
                        {
                            i += spSystem.Backint(0);   // 숫자 벗어남, 필드 토큰 부족, 토큰 부족, 중복 금지, 4개 이상
                            continue;
                        }

                        able = spSystem.CardCanBuy(players[i], field, buy, joker);  // 카드를 살 수 있는지 확인
                        #region
                        /*
                        if (buy < 4)    // 카드를 살 수 있는지 확인
                        {
                            for (int j = 0; j < 5; j++)
                            {
                                if (players[i].ownBonusToken[j] + players[i].ownToken[j] + joker >= field.card1Field[buy % 4].cardPrice[j])
                                {
                                    if (players[i].ownBonusToken[j] + players[i].ownToken[j] < field.card1Field[buy % 4].cardPrice[j])
                                    {
                                        joker -= (field.card1Field[buy % 4].cardPrice[j] - players[i].ownToken[j] - players[i].ownBonusToken[j]);
                                    }
                                }
                                else
                                {
                                    able = false;
                                    break;
                                }
                            }
                        }
                        else if (buy < 8)
                        {
                            for (int j = 0; j < 5; j++)
                            {
                                if (players[i].ownBonusToken[j] + players[i].ownToken[j] + joker >= field.card2Field[buy % 4].cardPrice[j])
                                {
                                    if (players[i].ownBonusToken[j] + players[i].ownToken[j] < field.card2Field[buy % 4].cardPrice[j])
                                    {
                                        joker -= (field.card2Field[buy % 4].cardPrice[j] - players[i].ownToken[j] - players[i].ownBonusToken[j]);
                                    }
                                }
                                else
                                {
                                    able = false;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            for (int j = 0; j < 5; j++)
                            {
                                if (players[i].ownBonusToken[j] + players[i].ownToken[j] + joker >= field.card3Field[buy % 4].cardPrice[j])
                                {
                                    if (players[i].ownBonusToken[j] + players[i].ownToken[j] < field.card3Field[buy % 4].cardPrice[j])
                                    {
                                        joker -= (field.card3Field[buy % 4].cardPrice[j] - players[i].ownToken[j] - players[i].ownBonusToken[j]);
                                    }
                                        
                                }
                                else
                                {
                                    able = false;
                                    break;
                                }
                            }
                        }
                        */
                        #endregion

                        if (able == false)
                        {
                            i += spSystem.Backint(2);   // 숫자 벗어남, 필드 토큰 부족, 토큰 부족, 중복 금지, 4개 이상
                            continue;
                        }

                        spSystem.CardBuy(players[i], field, buy);
                        #region
                        /*
                        if (buy < 4)    // 카드를 구매
                        {
                            for (int j = 0; j < 5; j++)
                            {
                                if (players[i].ownBonusToken[j] + players[i].ownToken[j] >= field.card1Field[buy % 4].cardPrice[j])
                                {
                                    players[i].ownToken[j] -= field.card1Field[buy % 4].cardPrice[j] - players[i].ownBonusToken[j];
                                    field.token[j] += field.card1Field[buy % 4].cardPrice[j] - players[i].ownBonusToken[j];
                                }
                                else
                                {
                                    field.token[j] += players[i].ownToken[j];
                                    players[i].ownToken[5] -= (field.card1Field[buy % 4].cardPrice[j] - players[i].ownToken[j] - players[i].ownBonusToken[j]);
                                    field.token[5] += (field.card1Field[buy % 4].cardPrice[j] - players[i].ownToken[j] - players[i].ownBonusToken[j]);
                                    players[i].ownToken[j] = 0;
                                }
                            }
                            players[i].ownBonusToken[field.card1Field[buy % 4].cardJewel]++;
                            players[i].point += field.card1Field[buy % 4].cardPoint;
                            field.card1Field[buy % 4].ownPlayer = true;
                        }
                        else if (buy < 8)
                        {
                            for (int j = 0; j < 5; j++)
                            {
                                if (players[i].ownBonusToken[j] + players[i].ownToken[j] >= field.card2Field[buy % 4].cardPrice[j])
                                {
                                    players[i].ownToken[j] -= field.card2Field[buy % 4].cardPrice[j] - players[i].ownBonusToken[j];
                                    field.token[j] += field.card2Field[buy % 4].cardPrice[j] - players[i].ownBonusToken[j];
                                }
                                else
                                {
                                    field.token[j] += players[i].ownToken[j];
                                    players[i].ownToken[5] -= (field.card2Field[buy % 4].cardPrice[j] - players[i].ownToken[j] - players[i].ownBonusToken[j]);
                                    field.token[5] += (field.card2Field[buy % 4].cardPrice[j] - players[i].ownToken[j] - players[i].ownBonusToken[j]);
                                    players[i].ownToken[j] = 0;
                                }
                            }
                            players[i].ownBonusToken[field.card2Field[buy % 4].cardJewel]++;
                            players[i].point += field.card2Field[buy % 4].cardPoint;
                            field.card2Field[buy % 4].ownPlayer = true;
                        }
                        else
                        {
                            for (int j = 0; j < 5; j++)
                            {
                                if (players[i].ownBonusToken[j] + players[i].ownToken[j] >= field.card3Field[buy % 4].cardPrice[j])
                                {
                                    players[i].ownToken[j] -= field.card3Field[buy % 4].cardPrice[j] - players[i].ownBonusToken[j];
                                    field.token[j] += field.card3Field[buy % 4].cardPrice[j] - players[i].ownBonusToken[j];
                                }
                                else
                                {
                                    field.token[j] += players[i].ownToken[j];
                                    players[i].ownToken[5] -= (field.card3Field[buy % 4].cardPrice[j] - players[i].ownToken[j] - players[i].ownBonusToken[j]);
                                    field.token[5] += (field.card3Field[buy % 4].cardPrice[j] - players[i].ownToken[j] - players[i].ownBonusToken[j]);
                                    players[i].ownToken[j] = 0;
                                }
                            }
                            players[i].ownBonusToken[field.card3Field[buy % 4].cardJewel]++;
                            players[i].point += field.card3Field[buy % 4].cardPoint;
                            field.card3Field[buy % 4].ownPlayer = true;
                        }
                        */
                        #endregion

                        field.CardRefill(card);
                        players[i].buyCardNum++;
                    }
                    else
                    {
                        i += spSystem.Backint(0);   // 숫자 벗어남, 필드 토큰 부족, 토큰 부족, 중복 금지, 4개 이상
                        continue;
                    }

                    spSystem.RoyalCheck(field.royalField, players[i], playerNum);
                    #region
                    /*
                    for (int j = 0; j < playerNum + 1; j++) // 귀족 체크
                    {
                        if (field.royalField[j].ownPlayer == true)
                            continue;
                        bool able = true;

                        for (int k = 0; k < 5; k++)
                            if (players[i].ownBonusToken[k] < field.royalField[j].cardJewel[k])
                            {
                                able = false;
                                break;
                            }

                        if (able == true)
                        {
                            Console.WriteLine("귀족 카드를 위한 조건이 충족되었습니다. 귀족 카드를 얻고 점수를 획득합니다.");
                            players[i].point += field.royalField[j].royalPoint;
                            field.royalField[j].ownPlayer = true;
                            break;
                        }
                    }
                    */
                    #endregion

                    if (players[i].point >= 15)
                    {
                        Console.WriteLine("15점에 도달했습니다. 이번 바퀴를 마지막으로 게임을 종료합니다.");
                        Console.ReadKey();
                        game = false;
                    }

                }
                if (game == false)
                {
                    spSystem.FinalRanking(players, playerNum);
                    break;
                }
            }
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
        public void RankingSystem(ref Horse[] horse)        // 말들 순위 정하는 코드, 순위 정하는 방법 ( GoalTime(도착시간(턴 단위)) -> GoalDetail(도착 시간 (마지막 골 타이밍) -> Distance(누가 조금 더 멀리서 끝냈는지) )
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
                Console.Write("┎─────┒   ");
                
            Console.WriteLine();
            for (int j = 0; j <= i; j++)
                Console.Write("┃     ┃   ");
                
            Console.WriteLine();
        }
        public void CardPrintMiddleNormal(int i)        // 카드 그림 그리기 (중간, 숫자 포함)
        {
            for (int j = 0; j <= i; j++)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                //Console.Write("ㅣ");
                Console.Write("┃ ");
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
            //Console.Write("ㅣ  ");
            Console.Write("┃   ");
        }
        public void CardPrintBottom(int i)          // 카드 그림 그리기 (아래쪽, 숫자 이후)
        {
            Console.WriteLine();
            for (int j = 0; j <= i; j++)
                Console.Write("┃     ┃   ");

            Console.WriteLine();
            for (int j = 0; j <= i; j++)
                Console.Write("┖─────┚   ");
                
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
            Console.ReadKey();
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
                Console.Write("┃ ");

                if (j == 0)
                {
                    Console.Write("  ? ┃   ");
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


    class SplendorSystem    // 입력값이 잘못됐을 경우 뒤로가기, 카드 구매 과정, 귀족 획득 과정, 토큰 10개 맞추는 과정, 순위 산출 과정 등 전반적인 시스템 묶어둠
    {
        public int Backint(int i)   // 숫자 벗어남, 필드 토큰 부족, 토큰 부족, 중복 금지, 4개 이상
        {
            switch (i)
            {
                case 0:
                    Console.WriteLine("숫자 범위를 벗어났습니다.");
                    break;
                case 1:
                    Console.WriteLine("필드 위에 그 토큰이 부족합니다.");
                    break;
                case 2:
                    Console.WriteLine("토큰이 부족합니다.");
                    break;
                case 3:
                    Console.WriteLine("같은 토큰을 중복해서 가져올 수 없습니다.");
                    break;
                case 4:
                    Console.WriteLine("같은 종류 토큰 2개 가져오기는 필드의 그 토큰 수가 4개 이상일 때만 가능합니다.");
                    break;
            }
            Console.ReadKey();
            return -1;
        }
        public bool CardCanBuy(SplendorPlayer player, SplendorField field, int buy, int joker)
        {
            switch (buy / 4)
            {
                case 0:
                    return CardCanBuySimple(player, field.card1Field, buy, joker);
                case 1:
                    return CardCanBuySimple(player, field.card2Field, buy, joker);
                default:
                    return CardCanBuySimple(player, field.card3Field, buy, joker);
            }
        }
        public bool CardCanBuySimple(SplendorPlayer player, SplendorCard[] cardField, int buy,  int joker)
        {
            for (int j = 0; j < 5; j++)
            {
                if (player.ownBonusToken[j] + player.ownToken[j] + joker >= cardField[buy % 4].cardPrice[j])
                {
                    if (player.ownBonusToken[j] + player.ownToken[j] < cardField[buy % 4].cardPrice[j])
                        joker -= (cardField[buy % 4].cardPrice[j] - player.ownToken[j] - player.ownBonusToken[j]);
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
        public void CardBuy(SplendorPlayer player, SplendorField field, int buy)
        {
            switch (buy / 4)
            {
                case 0:
                    CardBuySimple(player, field.card1Field, field.token, buy);
                    break;
                case 1:
                    CardBuySimple(player, field.card2Field, field.token, buy);
                    break;
                case 2:
                    CardBuySimple(player, field.card3Field, field.token, buy);
                    break;
            }
        }
        public void CardBuySimple(SplendorPlayer player, SplendorCard[] cardField, int[] fieldToken, int buy)
        {
            for (int j = 0; j < 5; j++)
            {
                if (cardField[buy % 4].cardPrice[j] != 0)
                {
                    if (player.ownBonusToken[j] + player.ownToken[j] >= cardField[buy % 4].cardPrice[j])
                    {
                        if (cardField[buy % 4].cardPrice[j] > player.ownBonusToken[j])
                        {
                            player.ownToken[j] -= (cardField[buy % 4].cardPrice[j] - player.ownBonusToken[j]);
                            fieldToken[j] += cardField[buy % 4].cardPrice[j] - player.ownBonusToken[j];
                        }
                    }
                    else
                    {
                        fieldToken[j] += player.ownToken[j];
                        player.ownToken[5] -= (cardField[buy % 4].cardPrice[j] - player.ownToken[j] - player.ownBonusToken[j]);
                        fieldToken[5] += (cardField[buy % 4].cardPrice[j] - player.ownToken[j] - player.ownBonusToken[j]);
                        player.ownToken[j] = 0;
                    }
                }
            }
            player.ownBonusToken[cardField[buy % 4].cardJewel]++;
            player.point += cardField[buy % 4].cardPoint;
            cardField[buy % 4].ownPlayer = true;
        }
        public void RoyalCheck(SplendorRoyal[] royalField, SplendorPlayer player, int playerNum)    // 귀족 조건을 충족했는지 확인
        {
            for (int j = 0; j < playerNum + 1; j++) // 귀족 체크
            {
                if (royalField[j].ownPlayer == true)
                    continue;
                bool able = true;

                for (int k = 0; k < 5; k++)
                    if (player.ownBonusToken[k] < royalField[j].cardJewel[k])
                    {
                        able = false;
                        break;
                    }
                if (able == true)
                {
                    Console.WriteLine("귀족 카드를 위한 조건이 충족되었습니다. 귀족 카드를 얻고 점수를 획득합니다.");
                    player.point += royalField[j].royalPoint;
                    royalField[j].ownPlayer = true;
                    Console.ReadKey();
                    break;
                }
            }
        }
        public void TokenOver10(SplendorPlayer[] players, SplendorField field, SplendorCardInfo card, int i, int playerNum, enemyPlayerInfo enemy)
        {
            int totalToken = 0;
            for (int j = 0; j < 6; j++)
                totalToken += players[i].ownToken[j];
            if (totalToken > 10)
            {
                while (totalToken > 10)
                {
                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    Console.Clear();
                    //enemy.ShowEnemyPlayerInfo(players, playerNum, i, field);

                    field.ShowField(playerNum, card);
                    Console.WriteLine($"\n플레이어{i + 1}의 차례");
                    players[i].ShowPlayerInfo();
                    Console.WriteLine("소지 중인 토큰의 수가 10개를 초과했습니다. 버릴 토큰을 하나씩 선택해 주세요.( 하양(0)  파랑(1)  초록(2)  빨강(3)  검정(4)  조커(5))");
                    int tokenReturn = Convert.ToInt32(Console.ReadLine());
                    if (tokenReturn >= 0 && tokenReturn <= 5)
                    {
                        players[i].ownToken[tokenReturn]--;
                        field.token[tokenReturn]++;
                        totalToken--;
                    }
                }
            }
        }
        public void FinalRanking(SplendorPlayer[] players, int playerNum)
        {
            for (int i = 0; i < playerNum; i++)
            {
                for (int j = i + 1; j < playerNum; j++)
                    if (players[i].point < players[j].point || players[i].point == players[j].point && players[i].buyCardNum >= players[j].buyCardNum)
                        players[i].ranking++;
            }
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("게임을 종료합니다.");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("최종 순위");
            for (int i = 0; i < playerNum; i++)
                Console.WriteLine($"플레이어{i + 1}   {players[i].ranking}위   {players[i].point}점");
        }

    }

    class SplendorCard      // 카드 정보
    {
        public int[] cardPrice = new int[5] { 0, 0, 0, 0, 0 };      // 카드 구매 시 필요 토큰, 하양 파랑 초록 빨강 검정 순
        public int cardPoint = 0;                                   // 카드 구매 시 획득 점수
        public int cardJewel = 0;                                   // 카드 구매 시 획득 보너스 토큰
        public bool existDeck = true;                               // 랜덤으로 덱에서 필드에 카드를 깔 떄 중복이 일어나지 않도록 덱에 존재하는지 체크
        public bool ownPlayer = false;                              // 플레이어가 필드의 카드를 샀을 떄 그 자리를 덱에 있는 새 카드로 채우기 위해 체크
    }

    class SplendorCardInfo  // 카드 종류들 저장 (총 90장)
    {
        public SplendorCard[] Card1 = new SplendorCard[40];     // 1단계 카드 뭉치    카드의 단계가 높을 수록 카스의 가격과 점수가 높아진다.
        public SplendorCard[] Card2 = new SplendorCard[30];     // 2단계 카드 뭉치
        public SplendorCard[] Card3 = new SplendorCard[20];     // 3단계 카드 뭉치
        public void cardSet()
        {
            for (int i = 0; i < Card1.Length; i++)      // 1단계 카드 지정 (총 40장, 5가지 모양, 8개의 유형)
            {
                Card1[i] = new SplendorCard();
                Card1[i].cardJewel = i / 8;
                switch (i % 8)
                {
                    case 0:
                        Card1[i].cardPrice[(i / 8 + 1) % 5] = 3;
                        break;
                    case 1:
                        Card1[i].cardPrice[(i / 8 + 3) % 5] = 2;
                        Card1[i].cardPrice[(i / 8 + 4) % 5] = 1;
                        break;
                    case 2:
                        Card1[i].cardPrice[(i / 8 + 1) % 5] = 2;
                        Card1[i].cardPrice[(i / 8 + 4) % 5] = 2;
                        break;
                    case 3:
                        Card1[i].cardPrice[(i / 8 + 1) % 5] = 1;
                        Card1[i].cardPrice[(i / 8 + 2) % 5] = 1;
                        Card1[i].cardPrice[(i / 8 + 3) % 5] = 1;
                        Card1[i].cardPrice[(i / 8 + 4) % 5] = 1;
                        break;
                    case 4:
                        Card1[i].cardPrice[i / 8] = 3;
                        Card1[i].cardPrice[(i / 8 + 1) % 5] = 1;
                        Card1[i].cardPrice[(i / 8 + 4) % 5] = 1;
                        break;
                    case 5:
                        Card1[i].cardPrice[(i / 8 + 1) % 5] = 1;
                        Card1[i].cardPrice[(i / 8 + 2) % 5] = 2;
                        Card1[i].cardPrice[(i / 8 + 3) % 5] = 1;
                        Card1[i].cardPrice[(i / 8 + 4) % 5] = 1;
                        break;
                    case 6:
                        Card1[i].cardPrice[(i / 8 + 1) % 5] = 2;
                        Card1[i].cardPrice[(i / 8 + 2) % 5] = 2;
                        Card1[i].cardPrice[(i / 8 + 4) % 5] = 1;
                        break;
                    case 7:
                        Card1[i].cardPrice[(i / 8 + 2) % 5] = 4;
                        Card1[i].cardPoint = 1;
                        break;
                }
            }
            for (int i = 0; i < Card2.Length; i++)      // 2단계 카드 지정 (총 30장, 5가지 모양, 6개의 유형)
            {
                Card2[i] = new SplendorCard();
                Card2[i].cardJewel = i / 6;
                switch (i % 6)
                {
                    case 0:
                        Card2[i].cardPrice[(i / 6 + 2) % 5] = 3;
                        Card2[i].cardPrice[(i / 6 + 3) % 5] = 2;
                        Card2[i].cardPrice[(i / 6 + 4) % 5] = 2;
                        Card2[i].cardPoint = 1;
                        break;
                    case 1:
                        Card2[i].cardPrice[i / 6] = 2;
                        Card2[i].cardPrice[(i / 6 + 1) % 5] = 3;
                        Card2[i].cardPrice[(i / 6 + 3) % 5] = 3;
                        Card2[i].cardPoint = 1;
                        break;
                    case 2:
                        Card2[i].cardPrice[(i / 6 + 3) % 5] = 5;
                        Card2[i].cardPoint = 2;
                        break;
                    case 3:
                        Card2[i].cardPrice[(i / 6 + 2) % 5] = 1;
                        Card2[i].cardPrice[(i / 6 + 3) % 5] = 4;
                        Card2[i].cardPrice[(i / 6 + 4) % 5] = 2;
                        Card2[i].cardPoint = 2;
                        break;
                    case 4:
                        Card2[i].cardPrice[(i / 6 + 3) % 5] = 5;
                        Card2[i].cardPrice[(i / 6 + 4) % 5] = 3;
                        Card2[i].cardPoint = 2;
                        break;
                    case 5:
                        Card2[i].cardPrice[i / 6] = 6;
                        Card2[i].cardPoint = 3;
                        break;
                }
            }
            for (int i = 0; i < Card3.Length; i++)      // 3단계 카드 지정 (총 20장, 5가지 모양, 4개의 유형)
            {
                Card3[i] = new SplendorCard();
                Card3[i].cardJewel = i / 4;
                switch (i % 4)
                {
                    case 0:
                        Card3[i].cardPrice[(i / 4 + 1) % 5] = 3;
                        Card3[i].cardPrice[(i / 4 + 2) % 5] = 3;
                        Card3[i].cardPrice[(i / 4 + 3) % 5] = 5;
                        Card3[i].cardPrice[(i / 4 + 4) % 5] = 3;
                        Card3[i].cardPoint = 3;
                        break;
                    case 1:
                        Card3[i].cardPrice[(i / 4 + 4) % 5] = 7;
                        Card3[i].cardPoint = 4;
                        break;
                    case 2:
                        Card3[i].cardPrice[i / 4] = 3;
                        Card3[i].cardPrice[(i / 4 + 3) % 5] = 3;
                        Card3[i].cardPrice[(i / 4 + 4) % 5] = 6;
                        Card3[i].cardPoint = 4;
                        break;
                    case 3:
                        Card3[i].cardPrice[i / 4] = 3;
                        Card3[i].cardPrice[(i / 4 + 4) % 5] = 7;
                        Card3[i].cardPoint = 5;
                        break;
                }
            }
        }
    }

    class SplendorRoyal     // 귀족 타일 정보
    {
        public int[] cardJewel = new int[5] { 0, 0, 0, 0, 0 };      // 귀족 타일 획득 조건(필요 보너스 토큰), 하양 파랑 초록 빨강 검정 순
        public int royalPoint = 3;                                  // 귀족 타일 점수
        public bool exist = true;                                   // 랜덤으로 덱에서 필드에 귀족 타일을 깔 떄 중복이 일어나지 않도록 덱에 존재하는지 체크
        public bool ownPlayer = false;                              // 귀족 타일을 플레이어가 얻었는지 체크 (귀족 타일 중복 획득 방지)
    }

    class RoyalInfo         // 귀족 타일 종류들 저장 
    {
        public SplendorRoyal[] royal = new SplendorRoyal[10];       // 전체 귀족 타일 뭉치

        public void royalSet()      // 전체 귀족 타일의 정보 입력
        {
            for (int i = 0; i < 5; i++)
            {
                royal[i] = new SplendorRoyal();
                royal[i].cardJewel[i] = 3;
                royal[i].cardJewel[(i + 1) % 5] = 3;
                royal[i].cardJewel[(i + 2) % 5] = 3;
            }
            for (int i = 5; i < 10; i++)
            {
                royal[i] = new SplendorRoyal();
                royal[i].cardJewel[i % 5] = 4;
                royal[i].cardJewel[(i + 1) % 5] = 4;
            }
        }
    }

    class SplendorPlayer    // 플레이어 정보 저장, 표시
    {
        public int[] ownBonusToken = new int[5] { 0, 0, 0, 0, 0 };  // 플레이어가 가지고 있는 보너스 토큰, 하양 파랑 초록 빨강 검정 순, (보너스 토큰은 카드 구매로만 획득)
        public int[] ownToken = new int[6] { 0, 0, 0, 0, 0, 0 };    // 플레이어가 가지고 있는 토큰, 하양 파랑 초록 빨강 검정 조커 순, (토큰은 한 사람당 최대 10개까지 보유 가능)
        public int point = 0;                                       // 점수, 15점 획득 시 승리
        public int buyCardNum = 0;                                  // 산 카드 개수, 점수가 같을 시 산 카드 개수로 순위 결정 (산 카드가 적은 사람이 높은 순위)
        public int ranking = 1;                                     // 순위

        SplendorField field = new SplendorField();

        public void ShowPlayerInfo()
        {
            int totalTokenNum = 0;
            for (int i = 0; i < 6; i++)
                totalTokenNum += ownToken[i];

            field.ColorChange(6);
            Console.Write("┎────────────────────────────────────────┒    ");
            Console.WriteLine();
            if (point >= 10)
            {
                if (buyCardNum >= 10)
                {
                    if (totalTokenNum >= 10)
                        Console.Write($"┃ 점수: {point}점  토큰 수: {totalTokenNum}  산 카드 수: {buyCardNum}┃    ");
                    else
                        Console.Write($"┃ 점수: {point}점  토큰 수: {totalTokenNum}  산 카드 수: {buyCardNum} ┃    ");
                }
                else
                {
                    if (totalTokenNum >= 10)
                        Console.Write($"┃ 점수: {point}점  토큰 수: {totalTokenNum}  산 카드 수: {buyCardNum} ┃    ");
                    else
                        Console.Write($"┃ 점수: {point}점   토큰 수: {totalTokenNum}   산 카드 수: {buyCardNum}┃    ");
                }
                Console.WriteLine();
            }
            else
            {
                if (buyCardNum >= 10)
                {
                    if (totalTokenNum >= 10)
                        Console.Write($"┃ 점수: {point}점  토큰 수: {totalTokenNum}  산 카드 수: {buyCardNum} ┃    ");
                    else
                        Console.Write($"┃ 점수: {point}점   토큰 수: {totalTokenNum}   산 카드 수: {buyCardNum}┃    ");
                }
                else
                {
                    if (totalTokenNum >= 10)
                        Console.Write($"┃ 점수: {point}점   토큰 수: {totalTokenNum}   산 카드 수: {buyCardNum}┃    ");
                    else
                        Console.Write($"┃ 점수: {point}점   토큰 수: {totalTokenNum}   산 카드 수: {buyCardNum} ┃    ");
                }
                Console.WriteLine();
            }
            Console.Write("┃ 보너스 토큰:  ");
            for (int i = 0; i < 5; i++)
            {
                field.ColorChange(i);
                Console.Write($"■{ownBonusToken[i]}  ");
            }
            field.ColorChange(6);
            Console.Write("┃               \n┃ 토큰:    ");
            for (int i = 0; i < 6; i++)
            {
                field.ColorChange(i);
                Console.Write($"●{ownToken[i]}  ");
            }
            field.ColorChange(6);
            Console.WriteLine("┃               \n┖────────────────────────────────────────┚    ");
        }
    }

    class enemyPlayerInfo   // 상대 정보 표시
    {
        public void ShowEnemyPlayerInfo(SplendorPlayer[] players, int playerNum, int player, SplendorField field)
        {
            field.ColorChange(6);
            for (int i = 0; i < playerNum - 1; i++)
            {
                Console.Write($" 플레이어{(player + playerNum - 1 - i) % 4 + 1}                                    ");
            }
            Console.WriteLine();

            for (int i = 0; i < playerNum - 1; i++)
                Console.Write("┎────────────────────────────────────────┒    ");
            Console.WriteLine();

            for (int i = 0; i < playerNum - 1; i++)
            {
                int totalTokenNum = 0;
                for (int j = 0; j < 6; j++)
                    totalTokenNum += players[(player + playerNum - 1 - i) % 4].ownToken[j];

                if (players[(player + playerNum - 1 - i) % 4].point >= 10)
                {
                    if (players[(player + playerNum - 1 - i) % 4].buyCardNum >= 10)
                    {
                        if (totalTokenNum >= 10)
                            Console.Write($"┃ 점수: {players[(player + playerNum - 1 - i) % 4].point}점  토큰 수: {totalTokenNum}  산 카드 수: {players[(player + playerNum - 1 - i) % 4].buyCardNum}┃    ");
                        else
                            Console.Write($"┃ 점수: {players[(player + playerNum - 1 - i) % 4].point}점  토큰 수: {totalTokenNum}  산 카드 수: {players[(player + playerNum - 1 - i) % 4].buyCardNum} ┃    ");
                    }
                    else
                    {
                        if (totalTokenNum >= 10)
                            Console.Write($"┃ 점수: {players[(player + playerNum - 1 - i) % 4].point}점  토큰 수: {totalTokenNum}  산 카드 수: {players[(player + playerNum - 1 - i) % 4].buyCardNum} ┃    ");
                        else
                            Console.Write($"┃ 점수: {players[(player + playerNum - 1 - i) % 4].point}점   토큰 수: {totalTokenNum}   산 카드 수: {players[(player + playerNum - 1 - i) % 4].buyCardNum}┃    ");
                    }
                }
                else
                {
                    if (players[(player + playerNum - 1 - i) % 4].buyCardNum >= 10)
                    {
                        if (totalTokenNum >= 10)
                            Console.Write($"┃ 점수: {players[(player + playerNum - 1 - i) % 4].point}점  토큰 수: {totalTokenNum}  산 카드 수: {players[(player + playerNum - 1 - i) % 4].buyCardNum} ┃    ");
                        else
                            Console.Write($"┃ 점수: {players[(player + playerNum - 1 - i) % 4].point}점   토큰 수: {totalTokenNum}   산 카드 수: {players[(player + playerNum - 1 - i) % 4].buyCardNum}┃    ");
                    }
                    else
                    {
                        if (totalTokenNum >= 10)
                            Console.Write($"┃ 점수: {players[(player + playerNum - 1 - i) % 4].point}점   토큰 수: {totalTokenNum}   산 카드 수: {players[(player + playerNum - 1 - i) % 4].buyCardNum}┃    ");
                        else
                            Console.Write($"┃ 점수: {players[(player + playerNum - 1 - i) % 4].point}점   토큰 수: {totalTokenNum}   산 카드 수: {players[(player + playerNum - 1 - i) % 4].buyCardNum} ┃    ");
                    }
                    
                }
            }
            Console.WriteLine();

            for (int j = 0; j < playerNum - 1; j++)
            {
                Console.Write("┃ 보너스 토큰:  ");
                for (int i = 0; i < 5; i++)
                {
                    field.ColorChange(i);
                    Console.Write($"■{players[(player + playerNum - 1 - j) % 4].ownBonusToken[i]}  ");
                }
                field.ColorChange(6);
                Console.Write("┃    ");
            }
            
            Console.WriteLine();

            for (int j = 0; j < playerNum - 1; j++)
            {
                Console.Write("┃ 토큰:    ");
                for (int i = 0; i < 6; i++)
                {
                    field.ColorChange((i + 5) % 6);
                    Console.Write($"●{players[(player + playerNum - 1 - j) % 4].ownToken[(i + 5) % 6]}  ");
                }
                field.ColorChange(6);
                Console.Write("┃    ");
            }

            Console.WriteLine();

            for (int j = 0; j < playerNum - 1; j++)
                Console.Write("┖────────────────────────────────────────┚    ");
            Console.WriteLine();
        }
    }

    class SplendorField     // 필드에 표시될 정보들(깔려있는 카드, 귀족타일, 토큰) 작성, 필드에 표시
    {
        public int[] token = new int[6] { 0, 0, 0, 0, 0, 0 };
        public SplendorCard[] card1Field = new SplendorCard[4];
        public SplendorCard[] card2Field = new SplendorCard[4];
        public SplendorCard[] card3Field = new SplendorCard[4];
        public SplendorRoyal[] royalField = new SplendorRoyal[5];
        Random rand = new Random();


        public void fieldTokenRoyalFirstSet(RoyalInfo royalInfo, int peopleNum)   // 여기를 ref로 해야 할지 테스트, 2->4 3->5 4->7
        {
            for (int i = 0; i < 5; i++)
                token[i] = (peopleNum * 3 / 2 + 1);
            token[5] = 5;

            for (int i = 0; i < peopleNum + 1; i++)
                royalField[i] = new SplendorRoyal();
            for (int i = 0; i < peopleNum + 1; i++)
            {
                int randRoyal = rand.Next(0, 10);
                if (royalInfo.royal[randRoyal].exist == false)
                {
                    i--;
                    continue;
                }
                royalInfo.royal[randRoyal].exist = false;
                royalField[i] = royalInfo.royal[randRoyal];
            }
        }

        public void fieldCardFirstSet(SplendorCardInfo cardInfo)          // 여기를 ref로 해야 할지 테스트
        {
            int randCard = 0;

            for (int i = 0; i < 4; i++)
            {
                card1Field[i] = new SplendorCard();
                card2Field[i] = new SplendorCard();
                card3Field[i] = new SplendorCard();
            }
            for (int i = 0; i < 4; i++)     // 카드1 랜덤 필드로   
            {
                randCard = rand.Next(0, 40);
                if (cardInfo.Card1[randCard].existDeck == false)
                {
                    i--;
                    continue;
                }
                cardInfo.Card1[randCard].existDeck = false;
                card1Field[i] = cardInfo.Card1[randCard];
            }
            for (int i = 0; i < 4; i++)     // 카드2 랜덤 필드로
            {
                randCard = rand.Next(0, 30);
                if (cardInfo.Card2[randCard].existDeck == false)
                {
                    i--;
                    continue;
                }
                cardInfo.Card2[randCard].existDeck = false;
                card2Field[i] = cardInfo.Card2[randCard];
            }
            for (int i = 0; i < 4; i++)     // 카드3 랜덤 필드로
            {
                randCard = rand.Next(0, 20);
                if (cardInfo.Card3[randCard].existDeck == false)
                {
                    i--;
                    continue;
                }
                cardInfo.Card3[randCard].existDeck = false;
                card3Field[i] = cardInfo.Card3[randCard];
            }
        }

        public void ShowField(int peopleNum, SplendorCardInfo cardInfo)
        {
            
            // 필드에 깔린 귀족 타일
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            // 여기에 귀족 타일 수(플에이어 수) 에 따라 \t 을 어느정도 출력하여 간격 정하기


            for (int i = 0; i < peopleNum + 1; i++)
                Console.Write("┎────────┒  ");
            Console.WriteLine();
            for (int i = 0; i < peopleNum + 1; i++)
            {
                Console.Write("┃ ");
                ColorChange(6);
                Console.Write($"{royalField[i].royalPoint}점    ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("┃  ");
            }
            Console.WriteLine();

            for (int k = 0; k < 3; k++)     // 귀족타일 안의 내용물
            {
                // 여기에 귀족 타일 수(플에이어 수) 에 따라 \t 을 어느정도 출력하여 간격 정하기

                for (int i = 0; i < peopleNum + 1; i++)
                {
                    if (royalField[i].ownPlayer == true)
                        Console.Write("┃        ┃  ");
                    else
                    {
                        int count = 0;
                        for (int j = 0; j < 5; j++)
                        {
                            if (royalField[i].cardJewel[j] != 0)
                            {
                                if (count == k)
                                {
                                    Console.Write("┃ ");
                                    ColorChange(j);
                                    Console.Write($"■{royalField[i].cardJewel[j]}    ");
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.Write("┃  ");
                                    break;
                                }
                                count++;
                            }
                            if (j == 4)
                                Console.Write("┃        ┃  ");
                        }
                    }

                }
                Console.WriteLine();
            }
            // 여기에 귀족 타일 수(플에이어 수) 에 따라 \t 을 어느정도 출력하여 간격 정하기
            for (int i = 0; i < peopleNum + 1; i++)
                Console.Write("┖────────┚  ");
            Console.WriteLine();
            ColorChange(6);

            for (int i = 3; i > 0; i--)
                CardDraw(cardInfo, i);

            Console.Write("필드의 토큰    ");
            for (int i = 0; i < 6; i++)
            {
                ColorChange(i);
                Console.Write("●");
                ColorChange(6);
                Console.Write($"{token[i]}개  ");
            }
            Console.WriteLine();

        }

        public void CardRefill(SplendorCardInfo cardInfo)
        {
            int randCard = 0;
            for (int i = 0; i < 4; i++)
            {
                if (card1Field[i].ownPlayer == true)
                {
                    randCard = rand.Next(0, 40);
                    if (cardInfo.Card1[randCard].existDeck == false)
                    {
                        i--;
                        continue;
                    }
                    cardInfo.Card1[randCard].existDeck = false;
                    card1Field[i] = cardInfo.Card1[randCard];
                }
                else if (card2Field[i].ownPlayer == true)
                {
                    randCard = rand.Next(0, 30);
                    if (cardInfo.Card2[randCard].existDeck == false)
                    {
                        i--;
                        continue;
                    }
                    cardInfo.Card2[randCard].existDeck = false;
                    card2Field[i] = cardInfo.Card2[randCard];
                }
                else if (card3Field[i].ownPlayer == true)
                {
                    randCard = rand.Next(0, 20);
                    if (cardInfo.Card3[randCard].existDeck == false)
                    {
                        i--;
                        continue;
                    }
                    cardInfo.Card3[randCard].existDeck = false;
                    card3Field[i] = cardInfo.Card3[randCard];
                }
            }
        }

        public void CardDraw(SplendorCardInfo cardInfo, int num)
        {
            SplendorCard[] cardField = new SplendorCard[4];
            switch (num)
            {
                case 1:
                    for (int i = 0; i < 4; i++)
                    {
                        cardField[i] = new SplendorCard();
                        cardField[i] = card1Field[i];
                    }
                    break;
                case 2:
                    for (int i = 0; i < 4; i++)
                    {
                        cardField[i] = new SplendorCard();
                        cardField[i] = card2Field[i];
                    }
                    break;
                case 3:
                    for (int i = 0; i < 4; i++)
                    {
                        cardField[i] = new SplendorCard();
                        cardField[i] = card3Field[i];
                    }
                    break;
            }

            for (int i = 0; i < 5; i++)
                Console.Write("┎────────┒  ");
            Console.Write($"\n┃ {num} 단계 ┃  ");

            for (int i = 0; i < 4; i++)
            {
                Console.Write($"┃ {cardField[i].cardPoint}점  ");
                ColorChange(cardField[i].cardJewel);
                Console.Write("■");
                ColorChange(6);
                Console.Write("┃  ");
            }
            Console.WriteLine();

            for (int k = 0; k < 4; k++)
            {
                switch (k)
                {
                    case 0:
                        Console.Write("┃ 카드덱 ┃  ");
                        break;
                    case 2:
                        Console.Write("┃남은카드┃  ");
                        break;
                    case 3:
                        int cardNum = 0;
                        switch (num)
                        {
                            case 1:
                                for (int i = 0; i < 40; i++)
                                    if (cardInfo.Card1[i].existDeck == true)
                                        cardNum++;
                                break;
                            case 2:
                                for (int i = 0; i < 30; i++)
                                    if (cardInfo.Card2[i].existDeck == true)
                                        cardNum++;
                                break;
                            case 3:
                                for (int i = 0; i < 20; i++)
                                    if (cardInfo.Card3[i].existDeck == true)
                                        cardNum++;
                                break;
                        }
                        if (cardNum >= 10)
                            Console.Write($"┃  {cardNum}개  ┃  ");
                        else
                            Console.Write($"┃  {cardNum}개   ┃  ");
                        break;
                    default:
                        Console.Write("┃        ┃  ");
                        break;
                }

                for (int i = 0; i < 4; i++)
                {
                    int count = 0;
                    for (int j = 0; j < 5; j++)
                    {
                        if (cardField[i].cardPrice[j] != 0)
                        {
                            if (count == k)
                            {
                                Console.Write("┃ ");
                                ColorChange(j);
                                Console.Write($"●{cardField[i].cardPrice[j]}");
                                ColorChange(6);
                                if (k == 3)
                                {
                                    if (num * 4 - 4 + i >= 10)
                                        Console.Write($"  {num * 4 - 4 + i}┃  ");
                                    else
                                        Console.Write($"   {num * 4 - 4 + i}┃  ");
                                }
                                else
                                    Console.Write("    ┃  ");
                                break;
                            }
                            count++;
                        }
                        if (j == 4)
                        {
                            if (k == 3)
                            {
                                if (num * 4 - 4 + i >= 10)
                                    Console.Write($"┃      {num * 4 - 4 + i}┃  ");
                                else
                                    Console.Write($"┃       {num * 4 - 4 + i}┃  ");
                            }
                            else
                                Console.Write($"┃        ┃  ");
                        }
                    }
                }
                Console.WriteLine();
            }

            for (int i = 0; i < 5; i++)
                Console.Write("┖────────┚  ");
            Console.WriteLine();
        }

        public void ColorChange(int color)
        {
            switch (color)
            {
                case 0:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case 1:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case 4:
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;
                case 5:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;
            }
        }

    }
}