using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// [RequireComponent(typeof(Rigidbody))] ������ٵ� ������Ʈ�� �䱸�Ѵ�.
// �̰������� ������ٵ� �ڵ����� ���Եǰ� ���࿡ ������ٵ� �����ϰ� �ȴٸ� �����Ǵ°� ���´�.

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
