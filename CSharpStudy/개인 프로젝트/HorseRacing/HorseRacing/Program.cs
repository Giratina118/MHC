using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum GameState
{
    ready, start, racing, result
}


public class Horses : MonoBehaviour
{
    int rank = 1;       //등수
    GameState state = GameState.ready;  //게임 상태 (초기: 준비)
    char[,] initrace = new char[5, 15]{ { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#'},
            { '#', '@', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '|', '#', '#'},
            { '#', '@', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '|', '#', '#'},
            { '#', '@', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '|', '#', '#'},
            { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#'},
        };  //게임 초기 경기판
    char[,] race = new char[5, 15]; //게임 진행 경기판
    int[] position = new int[] { 1, 1, 1 }; //말들의 현재 위치

    // Start is called before the first frame update
    void Start()
    {
        Initrace();
        print("게임을 시작하기 위해 마우스를 클릭해 주세요.");
    }

    // Update is called once per frame
    void Update()
    {
        // 마우스를 눌렀고, 게임이 준비 상태라면
        if (Input.GetMouseButtonDown(0) && state == GameState.ready)
        {
            state = GameState.start;    //게임 시작
        }

        if (state == GameState.start)   //게임 시작 시
        {
            state = GameState.racing;   //게임 진행 중으로 바꾸기
            PrintRace();                //경기판 출력
        }

        else if (state == GameState.racing) //게임 진행 중
        {
            Proceed();                  //말 랜덤한 스피드로 앞으로 나아가기
            PrintRace();                //경기판 출력
            Ranking();                  //도착 시 등수 출력
        }

        else if (state == GameState.result) //게임 결과
        {
            PrintRace();                    //마지막 최종 등수 출력
            print("게임을 다시 시작하기 위해 마우스를 클릭해 주세요.");
            Result();                       //게임 초기화
        }
    }
    void PrintRace()
    {
        string output = "";
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 15; j++)
            {
                output += race[i, j];
            }
            output += "\n";
        }
        print(output);
    }
    void Proceed()
    {
        int speed;
        int temp;
        for (int i = 0; i < 3; i++)
        {
            speed = UnityEngine.Random.Range(0, 2);
            temp = position[i] + speed;
            if (temp >= 12)
            {
                temp = 13;
            }
            if (position[i] == -1)  //이미 도착한 말이라면 더 이상 앞으로 나아가지 않는다.
            {
                continue;
            }
            race[i + 1, position[i]] = '#'; //말의 이전 위치는 말 비우기
            race[i + 1, temp] = '@';        //말의 다음 위치에 말 위치시키기
            position[i] = temp;             //말의 현재 위치 저장
        }
    }
    void Ranking()
    {
        for (int i = 0; i < 3; i++)
        {
            if (position[i] == 13)  //결승선에 말이 도착했다면
            {
                position[i] = -1;   //더 이상 앞으로 나아가지 않게끔
                race[i + 1, 13] = char.Parse(rank.ToString());  //결승선에 등수 출력
                rank++;             //다음 등수
            }
        }

        if (rank == 4)               //만약 3개의 모든 말이 등수를 출력했다면
        {
            state = GameState.result;//게임 결과 상태로 변환
        }
    }
    void Result()
    {
        Initrace();                 //경기판 초기화
        for (int i = 0; i < 3; i++)
        {
            position[i] = 1;        //말의 현위치 초기화
        }
        rank = 1;                   //등수 초기화
        state = GameState.ready;    //게임 준비 상태
    }

    void Initrace()
    {
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 15; j++)
            {
                race[i, j] = initrace[i, j];    //현재 경기판을 초기화 시킨다.
            }
        }
    }

}