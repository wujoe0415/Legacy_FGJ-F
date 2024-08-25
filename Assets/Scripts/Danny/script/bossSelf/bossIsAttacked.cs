using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossIsAttacked : MonoBehaviour
{
    public GameObject bossList;
    public AudioClip hitSound;
    AudioSource audiosource;


    private void Start()
    {
        audiosource = GetComponent<AudioSource>();
        bossList = GameObject.Find("bossList");
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "attackObject")
        {
            audiosource.PlayOneShot(hitSound);
            bossList.GetComponent<bossHp>().hp -= 1;
        }
    }
}
