using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnityScripts : MonoBehaviour
{
    /************************************************************************
      * 컴포넌트 (Component)
      * 
      * 특정한 기능을 수행할 수 있도록 구성한 작은 기능적 단위
      * 게임오브젝트의 작동과 관련한 부품
      * 게임오브젝트에 추가, 삭제하는 방식의 조립형 부품
      ************************************************************************/

    // Component>Behaviour>MonoBehaviour  순으로 상위개념
    // Component안에 Behaviour 있고 Behaviour 안에  MonoBehaviour 있다.

    /************************************************************************
	 * MonoBehaviour
	 * 
	 * 스크립트는 무조건 포함되어있다.
	 * 컴포넌트를 기본클래스로 하는 클래스로 유니티 스크립트가 파생되는 기본 클래스
	 * 게임 오브젝트에 스크립트를 컴포넌트로서 연결할 수 있는 구성을 제공
	 * 스크립트 직렬화 기능, 유니티메시지 이벤트를 받는 기능, 코루틴 기능을 포함함
	 ***********************************************************************/
    // 파일이름과 클래스 이름 다르면 오류난다.
    // 파일이름 바꾸면 클래스 이름도 바꿔주자.

    // <스크립트 직렬화 기능>
    // 인스펙터 창에서 컴포넌트의 맴버변수 값을 확인하거나 변경하는 기능
    // 컴포넌트의 값형식 데이터를 확인하거나 변경
    // 컴포넌트의 참조형식 데이터를 드래그 앤 드랍 방식으로 연결
    // 나중에 유니티 상에서 바꾸면 그게 우선됨
    // 
    // <인스펙터창 직렬화가 가능한 자료형>
    [Header("C# Type")]
    public bool boolValue;          // 유니티 상에서 체크하면 true
    public int intValue;
    public float floatValue;
    public string stringValue;
    // 그 외 기본 자료형

    // 기본 자료형의 선형자료구조       // 해시테이블 안됨
    public int[] array;
    public List<int> list;

    [Header("Unity Type")]
    public Vector3 vector3;             // 2D vector2 3D vector3 갖는다. 하지만 2d게임이라도 vector3 쓸떄도 있따.
    public Color color;
    public LayerMask layerMask;
    public AnimationCurve curve;
    public Gradient gradient;       // 그라데이션

    [Header("Unity GameObject")]        // 클래스도 직렬화 가능 none == null;
    public GameObject obj;
    public Rigidbody rb;

    [Header("Unity Component")]
    public new Transform transform;
    public new Rigidbody rigidbody;
    public new Collider collider;

    [Header("Unity Event")]   //델리게이트 직렬화X 쓰고싶으면 UnityAction 사용해
    public UnityEvent OnEvent;

    // 직렬화 private는 inspector창에서 안보인다


    // priavte를 inspector창에서 컨트롤하고싶으면 어트리뷰트 사용

    // <어트리뷰트>(속성)
    // 클래스, 프로퍼티 또는 함수 위에 명시하여 특별한 동작을 나타낼 수 있는 마커

    [Space(30)]         //대괄호에 적음

    [Header("Unity Attribute")]
    [SerializeField]            // priavte지만 보인다.
    private int privateValue;
    [HideInInspector]   //pbulic 이지만 안보이게 가린다.
    public int publicValue;

    [Range(0, 10)]          // 슬라이브바 생성 최소0 최대 10
    public float rangeValue;

    [TextArea(3, 5)]      // 입력가능한 텍스트 박스 설정
    public string textField;
}
