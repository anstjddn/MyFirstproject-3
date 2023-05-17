using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UnityScene : MonoBehaviour
{
    /************************************************************************
      * 씬 (Scene)
      * 
      * 유니티에서 게임월드를 구성하는 단위
      * 프로젝트에 원하는 수만큼 씬을 포함할 수 있음
      * 단일 씬에서 간단한 게임을 빌드할 수도 있으며, 여러 씬을 전환하며 게임을 진행 할 수도 있음
      * 다중 씬을 이용하여 여러 씬을 동시에 열어 같은 게임월드에서 사용도 가능함
      ************************************************************************/
    // 여러씬을 붙혀서 사용할수도있음
    // 보통로딩은 씬때문에 로딩들어가있으면 다중씬임

    // <빌드 설정>
    // 씬에 대한 스크립팅 전, 게임 빌드 설정에서 씬을 포함시켜야 해당 씬을 사용 가능
    // 게임파일만드는 빌드작업을할떄는 필요한 씬만 빌드에 올려서 쓰면 된다.


    // 씬매니저라는 기본 클래스가 있다
    // <씬 로드>
    public void ChangeSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);  // Single 이씬만 로드하고 나머지 버리고
                                                                    // add로 씬추가도있음
    }
        
    // 빌드할때 씬마다 번호가 지정되서 int로 불러올수도있다.
    public void ChangeSceneByIndex(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex, LoadSceneMode.Single);
    }

    // <씬 추가>
    public void AddSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
    }

    public void AddSceneByIndex(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex, LoadSceneMode.Additive);
    }
    // 씬 로드할때 멈췄다가 넘어가는데 렉먹을수있긴하다
    //씬이 크면 로딩하는데 렉먹기때문에 비동기 씬 로드 사용

    // <비동기 씬 로드>---로딩화면 구현할떄 중요
    public void ChangeSceneASync(string sceneName)
    {
        // 비동기 씬 로드 : 백그라운드로 씬을 로딩하도록 하여 게임 중 멈춤이 없도록 함
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);

        asyncOperation.allowSceneActivation = true;     // 씬 로딩 완료시 바로 씬 로드를 진행하는지 여부 false 는 로딩확인하고 진행
        bool isLoad = asyncOperation.isDone;            // 씬 로딩이 완료되었는지 판단
        float progress = asyncOperation.progress;       // 씬 로딩률 확인
        asyncOperation.completed += (oper) => { };      // 씬 로딩 완료시 진행할 이벤트 추가
    }

    // <Don't destroy on load>(특별씬)
    // 씬의 전환에도 제거되지 않기 원하는 게임오브젝트의 경우 지워지지 않는 씬의 오브젝트로 추가하는 방법을 사용
    // (동작 방법은 다중 씬을 통한 로드시에 제거되지 않는 씬을 구성하는 방법)
    public void SetDontDestroyOnLoad(GameObject go)
    {
        DontDestroyOnLoad(go);      // 씬바뀌어도 오브젝트 유지
    }

}
