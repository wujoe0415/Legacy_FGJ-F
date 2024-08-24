using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defend : BasicSkill
{
    public float Defense = 0.5f;
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
        // TODO: BattleSystem Increment Defense
        Debug.Log("Defense");
    }
    public override void LevelUp()
    {
        Defense += 0.5f;
    }
    private void Awake()
    {
        OnSkillRelease += ()=>{Debug.Log("Recover defense");};
    }
}