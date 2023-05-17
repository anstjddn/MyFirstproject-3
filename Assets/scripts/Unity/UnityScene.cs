using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UnityScene : MonoBehaviour
{
    /************************************************************************
      * �� (Scene)
      * 
      * ����Ƽ���� ���ӿ��带 �����ϴ� ����
      * ������Ʈ�� ���ϴ� ����ŭ ���� ������ �� ����
      * ���� ������ ������ ������ ������ ���� ������, ���� ���� ��ȯ�ϸ� ������ ���� �� ���� ����
      * ���� ���� �̿��Ͽ� ���� ���� ���ÿ� ���� ���� ���ӿ��忡�� ��뵵 ������
      ************************************************************************/
    // �������� ������ ����Ҽ�������
    // ����ε��� �������� �ε��������� ���߾���

    // <���� ����>
    // ���� ���� ��ũ���� ��, ���� ���� �������� ���� ���Խ��Ѿ� �ش� ���� ��� ����
    // �������ϸ���� �����۾����ҋ��� �ʿ��� ���� ���忡 �÷��� ���� �ȴ�.


    // ���Ŵ������ �⺻ Ŭ������ �ִ�
    // <�� �ε�>
    public void ChangeSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);  // Single �̾��� �ε��ϰ� ������ ������
                                                                    // add�� ���߰�������
    }
        
    // �����Ҷ� ������ ��ȣ�� �����Ǽ� int�� �ҷ��ü����ִ�.
    public void ChangeSceneByIndex(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex, LoadSceneMode.Single);
    }

    // <�� �߰�>
    public void AddSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
    }

    public void AddSceneByIndex(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex, LoadSceneMode.Additive);
    }
    // �� �ε��Ҷ� ����ٰ� �Ѿ�µ� ���������ֱ��ϴ�
    //���� ũ�� �ε��ϴµ� ���Ա⶧���� �񵿱� �� �ε� ���

    // <�񵿱� �� �ε�>---�ε�ȭ�� �����ҋ� �߿�
    public void ChangeSceneASync(string sceneName)
    {
        // �񵿱� �� �ε� : ��׶���� ���� �ε��ϵ��� �Ͽ� ���� �� ������ ������ ��
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);

        asyncOperation.allowSceneActivation = true;     // �� �ε� �Ϸ�� �ٷ� �� �ε带 �����ϴ��� ���� false �� �ε�Ȯ���ϰ� ����
        bool isLoad = asyncOperation.isDone;            // �� �ε��� �Ϸ�Ǿ����� �Ǵ�
        float progress = asyncOperation.progress;       // �� �ε��� Ȯ��
        asyncOperation.completed += (oper) => { };      // �� �ε� �Ϸ�� ������ �̺�Ʈ �߰�
    }

    // <Don't destroy on load>(Ư����)
    // ���� ��ȯ���� ���ŵ��� �ʱ� ���ϴ� ���ӿ�����Ʈ�� ��� �������� �ʴ� ���� ������Ʈ�� �߰��ϴ� ����� ���
    // (���� ����� ���� ���� ���� �ε�ÿ� ���ŵ��� �ʴ� ���� �����ϴ� ���)
    public void SetDontDestroyOnLoad(GameObject go)
    {
        DontDestroyOnLoad(go);      // ���ٲ� ������Ʈ ����
    }

}
