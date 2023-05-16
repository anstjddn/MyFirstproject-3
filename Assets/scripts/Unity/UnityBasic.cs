using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class UnityBasic : MonoBehaviour
{
    public GameObject Player;

    public void Start()
    {
        GameObjectBasic();
    }
    public void GameObjectBasic()
    {

        // <게임오브젝트 접근>
        // 컴포넌트가 붙어있는 게임오브젝트는 gameObject 속성을 이용하여 접근가능
        // 컴포넌트가 붙어있는 게임오브젝트
        // gameObject.name;                 // 게임오브젝트의 이름 접근
        // gameObject.active;         // 게임오브젝트의 활성화 여부 접근
        // gameObject.tag;                   // 게임오브젝트의 태그 접근
        // gameObject.layer;               // 게임오브젝트의 레이어 접근


        // <씬 내의 게임오브젝트 탐색>
       // GameObject.Find("Player");             // 조금 느린방식임
       //  GameObject.FindGameObjectWithTag("MainCamera");    // 태그로 하나 찾기
        //GameObject.FindGameObjectsWithTag("MyTag");	// 태그로 모두 찾기    // 여러개 있으면 배열로 찾아짐

        // <게임오브젝트 생성>
		GameObject newGameObject = new GameObject();
        

        // <게임오브젝트 삭제>
        //Destroy(gameObject.name, 5f); ///뒤에 숫자f면 5초뒤에 삭제(지연삭제)
                                        // 안넣으면 그냥 삭제

    }

    public void ComponentBasic()
    {
        // <게임오브젝트 내 컴포넌트 접근>
        // GetComponent를 이용하여 게임오브젝트 내 컴포넌트 접근
        // gameObjectGetComponent = GetComponent<AudioSource>();
        // 컴포넌트에서 GetComponent를 사용할 경우 부착되어 있는 게임오브젝트를 기준으로 접근
        //gameObjectGetComponent =gameObject.GetComponent<AudioSource>(); //게임오브젝트에서 참조할수도잇음

        //GetComponents<AudioSource>() // 컴포넌트 기준으로 여러컴포넌트 접근 배열로 반환함
        //GetComponetInChildren //자식게임오브젝트 포함 컨포넌트 접근
        //GetComponetsInChildren //자식게임오브젝트 포함 여러 컨포넌트 접근
        // 당연히 게임오브젝트에서 접근할수도잇다.
        //otherGameObject.GetComponentInParent<AudioSource>();        // 부모 게임오브젝트 포함 컴포넌트 접근
        //otherGameObject.GetComponentsInParent<AudioSource>();       // 부모 게임오브젝트 포함 컴포넌트들 접근


        // <씬 내의 컴포넌트 탐색>
        // FindObjectOfType<Rigidbody>();           // 씬 내의 컴포넌트 하나 찾기
        // FindObjectsOfType<Rigidbody>();			// 씬 내의 컴포넌트 모두 찾기

        // <컴포넌트 추가>
        // Rigidbody rigid = new Rigidbody();	// 가능하나 의미없음, 컴포넌트는 게임오브젝트에 부착되어 동작함에 의미가 있음
        // 게임오브젝트에 컴포넌트 추가
        //gameObject.AddComponent<AudioSoure>();  // 게임오브젝트에 컴포넌트 추가

        // <컴포넌트 삭제>
       // Destroy(destroyComponent);
    }
}
