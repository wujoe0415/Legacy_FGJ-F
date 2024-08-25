using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossAttack : MonoBehaviour
{
    public GameObject[] attackList;

    private void OnEnable()
    {
        Invoke("attack", 2f);
    }

    private void attack()
    {
        int attackItem = Random.Range(0, attackList.Length);
        Debug.Log(attackItem);
        GameObject obj = null;
        if (attackItem == 2)
        {
            if (this.transform.position.x > 0)
            {
                obj = Instantiate(attackList[attackItem], new Vector3(7f, 3.5f, 0f), Quaternion.identity);
            }
            else
            {
                obj = Instantiate(attackList[attackItem], new Vector3(-7f, 3.5f, 0f), Quaternion.identity);
            }

        }
        else if (attackItem == 3)
        {
            this.gameObject.GetComponent<bulletSet>().shotting = true;
        }
        else if (attackItem == 4)
        {
            Invoke("attackWithType4", 0f);
            Invoke("attackWithType4", 1f);
            Invoke("attackWithType4", 2f);
            Invoke("attackWithType4", 3f);
        }
        else
        {
            obj = Instantiate(attackList[attackItem]);
        }

        if (attackItem != 3 && attackItem != 4)
        {
            obj.SetActive(true);
        }
    }

    private void attackWithType4()
    {
        this.gameObject.GetComponent<claw>().attackDisplay();
    }
}
