using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BasicSkill : MonoBehaviour
{
    public KeyCode SkillKey = KeyCode.Space;
    [Range(0.01f, 20f)]
    public float CoolDownTime = 0.5f;
    protected float CurrentCoolDownTime = 0f;
    [Range(0, 5)]
    public int MPCost = 1;
    private int _maxProficency = 5;
    public int CurrentProficency = 1;
    private int _proficiency = 1;
    private int _usageTimes = 0;
    public int UsageLevelStandard = 6;
    public Action OnSkillRelease;
    public virtual bool CanUseSkill()
    {
        if(Input.GetKeyDown(SkillKey) && CoolDownTime < CurrentCoolDownTime)
            return true;
        else
            return false;
    }
    public void UseSkill(){
        if(PlayerStatus.Instance.DecreaseMP(MPCost))
        {
            Skill();
            OnSkillRelease?.Invoke();
            _usageTimes++;
            if(_usageTimes%UsageLevelStandard == 0 && _usageTimes != 0 && _proficiency < _maxProficency)
            {
                LevelUp();
                _proficiency++;
            }
            return;
        }
    }
    public virtual void Skill()
    {
        Debug.Log("Use Skill!");
    }
    public virtual void LevelUp()
    {
        Debug.Log("Level Up Skill!");
    }
    private void Update()
    {
        if (CurrentCoolDownTime <= CoolDownTime)
            CurrentCoolDownTime += Time.deltaTime;
    }
}
