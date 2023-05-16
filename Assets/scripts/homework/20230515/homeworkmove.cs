using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class homeworkmove : MonoBehaviour
{
    private Rigidbody Rb;
    private Vector3 movedir;
    [SerializeField]
    private int movespeed;
    [SerializeField]
    private int Rotatespeed;
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private Transform bulletpoint;
    [SerializeField]
    private float repeatTime;
  
    private void Awake()
    {
        Rb = GetComponent<Rigidbody>();
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
    private void OnFire(InputValue value)
    {
        Instantiate(bullet, bulletpoint.transform.position, bulletpoint.transform.rotation);
       
    }
    private void OnRepeatFire(InputValue value)
    {
        if (value.isPressed)
        {
            corotine = StartCoroutine(repeatcorotine());
        }
        else
        {
            StopCoroutine(corotine);
        }
    }
 

    private Coroutine corotine;
    IEnumerator repeatcorotine()
    {
        while (true)
        {
            Instantiate(bullet, bulletpoint.transform.position, bulletpoint.transform.rotation);
           
            yield return new WaitForSeconds(repeatTime);
        }
    }


    private void OnShift(InputValue vlaue)
    {
        if (vlaue.isPressed)
        {
            Rb.GetComponentInChildren<CinemachineVirtualCamera>().Priority = 20;

        }
        else
        { 
            Rb.GetComponentInChildren<CinemachineVirtualCamera>().Priority = 5; 
        }
    }
}
