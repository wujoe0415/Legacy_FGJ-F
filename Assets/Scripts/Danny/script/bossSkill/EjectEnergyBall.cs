using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EjectEnergyBall : BossBasicSkill
{
    public GameObject EnergyBall;

    public override void UseSkill()
    {
        Instantiate(EnergyBall, new Vector3(Random.Range(-7f, 7f), Random.Range(2f, 3.5f), 0f), Quaternion.identity);
    }
}
