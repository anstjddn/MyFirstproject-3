using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Transform : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 movedir;
    [SerializeField]
    private float MovePower;
    [SerializeField]
    private float RotatePower;
    [SerializeField]
    private GameObject bulletprefab;
    [SerializeField]
    private Transform bullletpoint;

     private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Move();
        Rotate();

    }
    private void Move()
    {
        transform.Translate(Vector3.forward*movedir.x*MovePower * Time.deltaTime);
    }

    private void Rotate()
    {
        transform.Rotate(Vector3.up, movedir.z * RotatePower * Time.deltaTime, Space.Self);

    }

    private void OnMove(InputValue value)
    {
        movedir.x = value.Get<Vector2>().y;
        movedir.z = value.Get<Vector2>().x;
    }

    private void OnFire(InputValue value)
    {
        GameObject obj = Instantiate(bulletprefab, bullletpoint.transform.position, bullletpoint.transform.rotation);          //프리팹을 인스턴스화?
     
    }
}
