using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : BasicSkill
{
    public float HealAmount = 1;
    public GameObject HealEffect;
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
        HealEffect.SetActive(true);
        Invoke("CloseEffect", 0.5f);
    }
    private void CloseEffect()
    {
        HealEffect.SetActive(false);
    }
    public override void LevelUp()
    {
        HealAmount += 0.4f;
    }
}