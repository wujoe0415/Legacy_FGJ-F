using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class claw : MonoBehaviour
{
    private GameObject claw1, claw2;
    private GameObject attackEffect1, attackEffect2;

    private GameObject player;

    private int count = 0;
    private void Start()
    {
        player = GameObject.Find("player");

        claw1 = transform.GetChild(0).gameObject;
        claw2 = transform.GetChild(2).gameObject;

        attackEffect1 = transform.GetChild(1).gameObject;
        attackEffect2 = transform.GetChild(3).gameObject;
    }

    public void attackDisplay()
    {
        if (this.gameObject.transform.position.x > player.transform.position.x)
        {
            claw1.SetActive(true);
        }
        else if (this.gameObject.transform.position.x < player.transform.position.x)
        {
            claw2.SetActive(true);
        }

        if (count == 3)
        {
            if (this.gameObject.transform.position.x > player.transform.position.x)
            {
                attackEffect1.SetActive(true);
            }
            else if (this.gameObject.transform.position.x < player.transform.position.x)
            {
                attackEffect2.SetActive(true);
            }

            claw1.SetActive(false);
            claw2.SetActive(false);

            StartCoroutine("displayItem");
        }
        count += 1;
    }

    IEnumerator displayItem()
    {
        yield return new WaitForSeconds(1f);
        claw1.SetActive(false);
        claw2.SetActive(false);
        attackEffect1.SetActive(false);
        attackEffect2.SetActive(false);
    }

}
