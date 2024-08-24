using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossIsAttacked : MonoBehaviour
{
    public GameObject bossList;

    private void Start()
    {
        bossList = GameObject.Find("bossList");
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "attackObject")
        {
            bossList.GetComponent<bossHp>().hp -= 1;
        }
    }
}
