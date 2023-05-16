using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// [RequireComponent(typeof(Rigidbody))] 리지드바디 컴포넌트를 요구한다.
// 이거적으면 리지드바디 자동으로 들어가게되고 만약에 리지드바디 삭제하게 된다면 삭제되는걸 막는다.

public class bulet : MonoBehaviour
{
    [SerializeField]
    private float bulletspeed;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        rb.velocity = transform.forward*bulletspeed;
        Destroy(gameObject, 5f);
    }
}
