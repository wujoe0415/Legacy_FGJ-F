using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossAttack : MonoBehaviour
{
    public GameObject[] attackList;

    private void Start()
    {
        int attackItem = Random.Range(0, attackList.Length - 1);
        GameObject obj = Instantiate(attackList[attackItem]);
        obj.SetActive(true);
    }
}
