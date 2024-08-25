using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossAttack : MonoBehaviour
{
    public GameObject[] attackList;

    private void Start()
    {
        int attackItem = Random.Range(0, attackList.Length);
        Debug.Log(attackItem);
        GameObject obj = null;
        if (attackItem == 2)
        {
            if(this.transform.position.x > 0)
            {
                obj = Instantiate(attackList[attackItem],new Vector3(7f, 3.5f,0f),Quaternion.identity);
            }
            else
            {
                obj = Instantiate(attackList[attackItem], new Vector3(-7f, 3.5f, 0f), Quaternion.identity);
            }
            
        }
        else
        {
            obj = Instantiate(attackList[attackItem]);
        }

        obj.SetActive(true);
    }
}
