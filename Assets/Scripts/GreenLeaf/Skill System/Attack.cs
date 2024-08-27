using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : BasicSkill
{
    public float Damage = 1f;
    public GameObject LeftDamageZone;
    public GameObject RightDamageZone;
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
        if (isRight)
        {
            RightDamageZone.GetComponent<PlayerAttackCollider>().Damage = Damage;
            RightDamageZone.SetActive(true);
        }
        else
        {
            LeftDamageZone.GetComponent<PlayerAttackCollider>().Damage = Damage;
            LeftDamageZone.SetActive(true);
        }
        Invoke("DisableSword", SpecialEffectDuration);
    }
    private void DisableSword()
    {
        RightDamageZone.SetActive(false);
        LeftDamageZone.SetActive(false);
    } 
    public override void LevelUp()
    {
        Damage += 5;
    }
}