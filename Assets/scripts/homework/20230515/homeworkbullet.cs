using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class homeworkbullet : MonoBehaviour
{
  
    private Rigidbody bulletRb;
    [SerializeField]
    private int bulletspeed;
    [SerializeField]
    private GameObject effect;

    private void Awake()
    {
        bulletRb = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        bulletRb.velocity = transform.forward * bulletspeed;
        Destroy(gameObject, 2f);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(effect, bulletRb.transform.position, bulletRb.transform.rotation);
        Destroy(gameObject);

    }
}
