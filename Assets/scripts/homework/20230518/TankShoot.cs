using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class TankShoot : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private float repeatTime;
    [SerializeField]
    private Transform bulletpoint;
    private Animator animator;

    public UnityEvent OnFired;


    private void Awake()
    {
     
        animator = GetComponent<Animator>();
    }
    private void OnFire(InputValue value)
    {
        Fire();
    }
    public void Fire()
    {
        Instantiate(bullet, bulletpoint.transform.position, bulletpoint.transform.rotation);
        animator.SetTrigger("Fire");
        GameManager.Data.AddShootCount(1);
        OnFired?.Invoke();
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
}
