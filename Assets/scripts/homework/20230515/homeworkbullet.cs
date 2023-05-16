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
    [SerializeField]
    private AudioSource audioSource;
    private AudioClip audioClip;

    private void Awake()
    {
        bulletRb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        audioClip = audioSource.GetComponent<AudioClip>();
    }
    private void Start()
    {
        bulletRb.velocity = transform.forward * bulletspeed;
        Destroy(gameObject, 2f);
    }
    private void OnCollisionEnter(Collision collision)
    {
      
        Instantiate(effect, bulletRb.transform.position, bulletRb.transform.rotation);
        audioSource.PlayOneShot(audioClip);
        Destroy(gameObject);
    }
}
