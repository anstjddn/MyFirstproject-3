using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class homeworkbullet : MonoBehaviour
{
  
    private Rigidbody bulletRb;
    [SerializeField]
    private int bulletspeed;

    private void Awake()
    {
        bulletRb = GetComponent<Rigidbody>();

    }
    private void Start()
    {
        bulletRb.velocity = transform.forward * bulletspeed;
        Destroy(bulletRb, 10f);
    }
}
