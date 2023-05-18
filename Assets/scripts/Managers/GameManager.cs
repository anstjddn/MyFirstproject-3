using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    private static DataManager dataManager;
    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }
    public static DataManager Data
    {
        get
        {
            return dataManager;
        }
    }
    private void Awake()                    // 유니티 싱글톤만드는건 new보다는 에드 컨포넌트하던가 컴포넌트로 추가한다.
    {
        if (instance != null)
        {
            Destroy(this);  //스크립트
            return;
        }
        DontDestroyOnLoad(this); //씬이 전환되고 gamemanager가 유지되게끔 이거 설정하면 dondestroy씬이 생성되고 배정된다.
        instance = this;
        InitManagers();
    }
    // 따라서 다른게임오브젝트에 게임매니저를 컴포넌트로 추가해도 하나만 유지되게끔 삭제한다.

    private void OnDestroy()
    {
        if (instance == this)
        {
            instance = null;
        }
    }
    // 주의: 씬전환상황에서도 싱글톤을 유지해줘야하낟.
    // 주의: 게임매니저가 포함

    private void InitManagers()
    {
        // DataManager init
        GameObject dataObj = new GameObject() { name = "DataManager" };
        dataObj.transform.SetParent(transform);
        dataManager = dataObj.AddComponent<DataManager>();
    }
}
