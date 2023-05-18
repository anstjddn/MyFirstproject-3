using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


//게임 시작하자마자 설정해야되는 설정들을 넣자
// 이소스는 게임 만들기 시작하자마자 만든다. 대신 남발하지말고 몰빵 ㄴㄴ 중간몬스터정도는 싱글톤하지마라
//관리자에만 사용 
public class GameSetting 
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]      //씬이 로드되기전에 생성
   private static void Init()
    {
        //게임을 시작하기전에 필요한 설정들 세팅
        if(GameManager.Instance == null)
        {
            GameObject gameManager = new GameObject() { name = "GameManager" };
            gameManager.AddComponent<GameManager>();
        }
    }
}
