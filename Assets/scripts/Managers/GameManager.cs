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
    private void Awake()                    // ����Ƽ �̱��游��°� new���ٴ� ���� ������Ʈ�ϴ��� ������Ʈ�� �߰��Ѵ�.
    {
        if (instance != null)
        {
            Destroy(this);  //��ũ��Ʈ
            return;
        }
        DontDestroyOnLoad(this); //���� ��ȯ�ǰ� gamemanager�� �����ǰԲ� �̰� �����ϸ� dondestroy���� �����ǰ� �����ȴ�.
        instance = this;
        InitManagers();
    }
    // ���� �ٸ����ӿ�����Ʈ�� ���ӸŴ����� ������Ʈ�� �߰��ص� �ϳ��� �����ǰԲ� �����Ѵ�.

    private void OnDestroy()
    {
        if (instance == this)
        {
            instance = null;
        }
    }
    // ����: ����ȯ��Ȳ������ �̱����� ����������ϳ�.
    // ����: ���ӸŴ����� ����

    private void InitManagers()
    {
        // DataManager init
        GameObject dataObj = new GameObject() { name = "DataManager" };
        dataObj.transform.SetParent(transform);
        dataManager = dataObj.AddComponent<DataManager>();
    }
}
