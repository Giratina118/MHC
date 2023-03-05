# MHC

## MHC\CSharpStudy\개인 프로젝트\Personal_Project
- 제작자: 유민혁
- 제작 기간: 2023/02/20 ~ 2023/03/05
- 게임 3개 (경마, 블랙젝, 스플랜더)

### 경마
#### 플레이
시작하면 말들이 달리기 시작, 도착한 순서에 따라 순위가 정해진다.

#### 사용 기술

  Thread.Sleep(50);
  Console.Clear();
  Console.WriteLine();
  for (int i = 0; i < horse.Length; i++)
  {
    if (horse[i].Distance < 100)    // 말 이동 거리, 말이 아직 도착하지 않았을 때 이동
    {
      horse[i].LastDis = rand.Next(1, 5);   // 랜덤으로 말 이동 거리 정하기
      horse[i].Distance += horse[i].LastDis;    // 말 이동 거리에 추가
      horse[i].GoalTime++;          // 골 시간, 들어오는 순간 측정이 끝난다.

      if (horse[i].Distance >= 100) // 도착하면 끝(도착점: 100)
      {
        i--;
        continue;
      }
      horse[i].HorseDraw();   // 달리는 말 그림
    }
    else
      horse[i].GoalHorseDraw(i);    // 도착한 말 그림
    Console.WriteLine("                                                                                                         |");
  }
위 과정을 계속 반복하여 말들의 이돌거리를 증가시킨다.


### 블랙젝
#### 플레이
21에 가까우면 승리
A -> 11 or 1로 취급
J, Q, K -> 10으로 취급
A ~ K, ♠︎ ♥︎ ◆ ♣︎, 13 × 4 = 총 52장

딜러와 참가자 하나씩 번갈아가며 카드 2개 받는다 (랜덤)
처음 2장이 에이스, 10(J Q K)면 블랙잭, 그대로 게임 종료
블랙잭이 아니면 21에 가까워지게 카드를 받을지 받지 않을지 결정

합이 21이 될 때까지 혹은 그만 받기로 결정할 때까지 반복해서 받는다. (while문)

21점이 초과되면 즉시 패배

딜러가 처음에 가진 2장의 합계가 16점 이하이면 
반드시 1장을 추가해야 하고, 17점 이상이면 추가할 수 없다

딜러보다 높으면 승리, 같으면 무승부, 낮으면 패배

#### 사용 기술
class Card를 만들어 모든 카드들의 정보를 저장, 관리하고
플레이어와 딜러(컴퓨터)가 각각 class BlackjackPlayer, class BlackjackComputer라는 Card클래스에서 상속받은 클래스를 통해 자신들의 정보를 저장, 게임 진행 과정을 관리한다.

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


### 스플랜더
#### 플레이 순서
1. 자신의 턴에 토큰 가져가기 or 카드 구매하기 중 한 가지를 선택하여 행동한다.

2. 토큰 가져오는 경우
  서로 다른 3개지 색의 토큰을 1개씩 가져오거나 같은 색의 토큰 2개 혹은 황금색의 조커 토큰 1개를 가져올 수 있다.\
	한 플레이어가 가지고 있을 수 있는 토큰은 최대 10개이며 10개를 초과할 시 토큰을 10개에 맞춰 버려야 한다.\
	만일 가져올 수 있는 토큰이 3종류가 안 되는 경우 2개 혹은 1개만 가져오게 될 수도 있다.

3. 카드 구매하기 (한 턴에 한 장만)
	카드에 표시된 토큰 수 만큼 지불하여 카드를 구매하며 조커토큰은 모든 토큰을 대신할 수 있다.\
	구매한 카드에 적힌 점수와 보너스 토큰을 획득하며 보너스 토큰이 있는 경우 영구적으로 그 토큰의 가격이 하나씩 할인된다.\
	예) 파란 보너스 토큰의 카드를 하나 가지고 있는 경우 \
	빨강2, 파랑1, 초록3 개의 토큰이 필요한 카드를 빨강2, 파랑0, 초록3의 가격으로 
	구매할 수 있으며 이렇게 한 번 할인 받은 후에도 보너스 토큰은 없어지지 않고 계속 사용된다.

4. 귀족
	자신의 턴을 마칠 때 만일 귀족 타일에 적힌 조건을 만족했다면 귀족 타일의 점수를 얻는다.\
	귀족 타일은 일반 카드를 구매하여 얻은 보너스 토큰으로만 조건을 충족시킬 수 있으며, 귀족 타일을 얻은 이후에도 보너스 토큰은 없어지지 않는다.

#### 게임 종료, 승리 조건
 - 한 플레이어가 15점 이상을 획득하게 되면 그 라운드를 마지막으로 게임이 종료된다.
 - 모든 플레이어가 해당 라운드를 마친 후 더 점수가 높은 사람이 승자가 된다.
 - 동점일 경우 구매한 카드의 수가 적은 사람이 승자가 되며 구매한 카드의 수도 같을 경우에는 플레이를 더 늦게 시작한 사람이 승자가 된다.

#### 사용 기술
class SplendorSystem    // 입력값이 잘못됐을 경우 뒤로가기, 카드 구매 과정, 귀족 획득 과정, 토큰 10개 맞추는 과정, 순위 산출 과정 등 전반적인 시스템 묶어둠
 - 카드 구매 과정
 1. public bool CardCanBuy(SplendorPlayer player, SplendorField field, int buy, int joker) 구매할 카드의 단계 체크
 2. public bool CardCanBuySimple(SplendorPlayer player, SplendorCard[] cardField, int buy,  int joker) 구분한 단계에 따라 카드를 구매할 수 있는지 체크 후 true of false 전달
 3. public void CardBuy(SplendorPlayer player, SplendorField field, int buy) true 라면 구매 돌입, 카드 단계 구분
 4. public void CardBuySimple(SplendorPlayer player, SplendorCard[] cardField, int[] fieldToken, int buy) 구분한 단계에 따라 카드 구매

class SplendorCard      // 카드 정보

class SplendorCardInfo  // 카드 종류들 저장 (총 90장)  -> class SplendorCard 클래스를 배열 형식으로 선언한 뒤 90장의 카드를 저장

class SplendorRoyal     // 귀족 타일 정보

class RoyalInfo         // 귀족 타일 종류들 저장  -> class SplendorRoyal 클래스를 배열 형식으로 선언한 뒤 10장의 귀족 타일을 저장

class SplendorPlayer    // 플레이어 정보(점수, 순위, 보너스 토큰 수, 토큰 수, 구매한 카드 수) 저장, 표시

class enemyPlayerInfo   // 상대 정보 표시  -> 플레이어 정보와 틀은 유사, 총 게임 참여 인원 수, 현재 플레이 중인 플레이어에 맞춰 나머지 플레이어들을 화면에 표시

class SplendorField     // 필드에 표시될 정보들(깔려있는 카드, 귀족타일, 토큰) 작성, 필드에 표시

##### 후기
원래 스플랜더에서는 토큰 가져오기에서 조커토큰 1개를 가져오는 것이 아닌 카드 한 장을 찜하며 조커토큰을 가져오는 과정이 있는데
카드를 찜하는 것을 만드는 과정을 시간이 부족해 생략하고 조커토큰 하나를 가져오는 것으로 바꾸었다.
게임이 진행되는 필드 또한 가운데로 옮기려 했으나 시간이 부족해 현재 왼쪽에 치우쳐진 모양으로 남아있다. 

시간이 부족해진 이유가 원래 포켓몬 RPG를 만드려 했으나 ref를 적절히 사용하지 않아 저장 데이터가 꼬이는 상황이 발생하여 시간 내에 만들 수 없다고 판단, 급하게 만드는 것을 바꿨기 때문이다.


