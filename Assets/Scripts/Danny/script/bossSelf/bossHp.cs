using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossHp : MonoBehaviour
{
    public int hp;
    

    private void Update()
    {
        if (hp <= 0)
        {
           GameManager.Instance.GameOver();
        }
    }
}
