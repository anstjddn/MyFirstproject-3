using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TankMove : MonoBehaviour
{
    private Rigidbody Rb;
    private Vector3 movedir;
    [SerializeField]
    private int movespeed;
    [SerializeField]
    private int Rotatespeed; 
    private Animator animator;

    private void Awake()
    {
        Rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        Move();
        Rotate();
    }
    private void Move()
    {
        transform.Translate(Vector3.forward * movedir.x * Time.deltaTime * movespeed);
    }
    private void OnMove(InputValue value)
    {
        movedir.x = value.Get<Vector2>().y;
        movedir.z = value.Get<Vector2>().x;

    }
    private void Rotate()
    {
        transform.Rotate(Vector3.up * movedir.z * Rotatespeed * Time.deltaTime, Space.Self);
    }
}
