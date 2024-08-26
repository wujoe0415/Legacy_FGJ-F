using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : BasicSkill
{
    public float HealAmount = 1;
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
        PlayerStatus.Instance.IncreaseHP(HealAmount);
    }
    public override void LevelUp()
    {
        HealAmount += 0.4f;
    }
}