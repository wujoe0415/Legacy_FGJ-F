using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastThunder : BossBasicSkill
{
    public GameObject Thunder1;
    public GameObject Thunder2;

    public override void UseSkill()
    {
        if (Random.Range(0, 10) > 5)
            Instantiate(Thunder1);
        else
            Instantiate(Thunder2);
    }
}
