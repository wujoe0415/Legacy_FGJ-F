using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energyball : BasicSkill
{
    public float Damage = 10f;
    public override bool CanUseSkill()
    {
        if(CoolDownTime > CurrentCoolDownTime)
            return false;
        if(!Input.GetKey(SkillKey))
            return false;
        return true;
    }
    public override void Skill()
    {
        Debug.Log("FireBall!");
    }
    public override void LevelUp()
    {
        Damage += 5;
    }
}