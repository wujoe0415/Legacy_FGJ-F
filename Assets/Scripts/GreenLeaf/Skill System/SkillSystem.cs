using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSystem : MonoBehaviour
{
    public List<BasicSkill> AvailableSkills = new List<BasicSkill>();
    private void Start()
    {
        StartCoroutine(CheckSkill());
    }
    IEnumerator CheckSkill()
    {
        while(true)
        {
            foreach(BasicSkill skill in AvailableSkills)
            {
                if(skill.CanUseSkill())
                {
                    skill.UseSkill();
                }
            }
            yield return null;
        }
    }
    public void AppendSkill(BasicSkill skill)
    {
        AvailableSkills.Add(skill);
    }
}
