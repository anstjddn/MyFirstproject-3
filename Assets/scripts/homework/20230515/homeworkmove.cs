using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
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

    private Animator animator;
    

    public UnityEvent OnFired;

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
    private void OnFire(InputValue value)
    {
        Instantiate(bullet, bulletpoint.transform.position, bulletpoint.transform.rotation);
        animator.SetTrigger("Fire");
        GameManager.Data.AddShootCount(1);
    }
    public void Fire()
    {
        Instantiate(bullet, bulletpoint.transform.position, bulletpoint.transform.rotation);
        animator.SetTrigger("Fire");
        GameManager.Data.AddShootCount(1);
        OnFired?.Invoke();              // 유니티 이벤트 실행
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
            animator.SetTrigger("Fire");
            GameManager.Data.AddShootCount(1);
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
    // 유니티 이벤트추가할때 AddListener쓰면됨
    // 유니티이벤트말고 c#이벤트쓸때는 딜리게이트체인슬때처럼 +=하면됨
}
