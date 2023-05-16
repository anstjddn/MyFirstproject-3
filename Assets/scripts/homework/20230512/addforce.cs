using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class addforce : MonoBehaviour
{
    private  Rigidbody rb;
    private Vector3 movedir;
    [SerializeField]
    private float MovePower;
    [SerializeField]
    private float jumppower;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {

        Move();
       
    }

    public void Move()
    {
        rb.AddForce(movedir * MovePower, ForceMode.Force);

    }
    public void OnMove(InputValue value)
    {
        movedir.x = value.Get<Vector2>().x;
        movedir.z = value.Get<Vector2>().y;
    }
    public void Jump()
    {
        rb.AddForce(Vector3.up * jumppower, ForceMode.Impulse);
    }
    public void OnJump(InputValue value)
    {
        Jump();
    }

}
