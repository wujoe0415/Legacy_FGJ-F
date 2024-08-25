using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defend : BasicSkill
{
    public float Defense = 0.5f;
    private float _pastDefense = 0f;
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
        _pastDefense = PlayerStatus.Instance.DefensePoint;
        PlayerStatus.Instance.DefensePoint = Defense;
        Invoke("ResetDefense", Mathf.Min(0.4f, CoolDownTime - 0.1f));
    }
    private void ResetDefense()
    {
        PlayerStatus.Instance.DefensePoint = _pastDefense;
        OnSkillRelease.Invoke();
    }
    public override void LevelUp()
    {
        Defense += 0.5f;
    }
    
}