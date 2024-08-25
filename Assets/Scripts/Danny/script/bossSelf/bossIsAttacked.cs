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
    public void TakeDamage(int damage)
    {
        bossList.GetComponent<bossHp>().hp -= damage;
    }
}
