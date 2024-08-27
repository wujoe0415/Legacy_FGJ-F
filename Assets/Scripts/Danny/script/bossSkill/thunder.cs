using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thunder : BossBasicSkill
{
    private GameObject aim1, aim2, aim3;
    private GameObject thunder1, thunder2, thunder3;
    private int count = 0;
    private void Start()
    {
        aim1 = transform.GetChild(1).gameObject;
        aim2 = transform.GetChild(3).gameObject;
        aim3 = transform.GetChild(5).gameObject;

        thunder1 = transform.GetChild(0).gameObject;
        thunder2 = transform.GetChild(2).gameObject;
        thunder3 = transform.GetChild(4).gameObject;

        thunder1.SetActive(false);
        thunder2.SetActive(false);
        thunder3.SetActive(false);

        InvokeRepeating("aimDisplay",0f, 1f);
    }
    private void aimDisplay()
    {
        if (count == 3)
        {
            thunder1.SetActive(true);
            thunder2.SetActive(true);
            thunder3.SetActive(true);

            aim1.SetActive(false);
            aim2.SetActive(false);
            aim3.SetActive(false);

            StartCoroutine("destroyItem");
        }
        count += 1;
    }

    IEnumerator destroyItem()
    {
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
    }
}
