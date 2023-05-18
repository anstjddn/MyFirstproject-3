using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


//���� �������ڸ��� �����ؾߵǴ� �������� ����
// �̼ҽ��� ���� ����� �������ڸ��� �����. ��� ������������ ���� ���� �߰����������� �̱�����������
//�����ڿ��� ��� 
public class GameSetting 
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]      //���� �ε�Ǳ����� ����
   private static void Init()
    {
        //������ �����ϱ����� �ʿ��� ������ ����
        if(GameManager.Instance == null)
        {
            GameObject gameManager = new GameObject() { name = "GameManager" };
            gameManager.AddComponent<GameManager>();
        }
    }
}
