using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSystem : MonoBehaviour
{
    public List<BasicSkill> AvailableSkills = new List<BasicSkill>();

    private void Update()
    {
        foreach(BasicSkill skill in AvailableSkills)
        {
            if(skill.CanUseSkill())
            {
                skill.UseSkill();
            }
        }
    }
    public void AppendSkill(BasicSkill skill)
    {
        AvailableSkills.Add(skill);
    }
}
