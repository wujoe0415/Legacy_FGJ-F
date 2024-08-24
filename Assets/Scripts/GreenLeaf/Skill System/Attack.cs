using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : BasicSkill
{
    public float Damage = 1f;
    public override bool CanUseSkill()
    {   
        if(CoolDownTime > CurrentCoolDownTime)
            return false;
        if(!Input.GetKeyDown(SkillKey))
            return false;
        return true;
    }
    public override void Skill()
    {
        // TODO: Attack Animation
        // Enemy.DecreaseHP();
        Debug.Log("Attack!");
    }
    public override void LevelUp()
    {
        Damage += 5;
    }
}