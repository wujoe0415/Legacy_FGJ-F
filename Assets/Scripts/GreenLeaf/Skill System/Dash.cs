using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : BasicSkill
{
    public float Distance = 1f;
    private IEnumerator _coroutine;
    public int InvincibleFrames = 15;
    public int DashFrame = 35;
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
        StartCoroutine(InvincibleDash());
    }
    private IEnumerator InvincibleDash(){
        Vector3 faceDir = isRight? Vector3.right: Vector3.left;
        Vector2 invFrames = new Vector2((DashFrame - InvincibleFrames) / 2, (DashFrame - InvincibleFrames) / 2 + InvincibleFrames);
        for(int i = 0;i<DashFrame;i++)
        {
            if(i>= invFrames[0] && i < invFrames[1])
                PlayerStatus.Instance.isInvincible = true;
            else 
                PlayerStatus.Instance.isInvincible = false;

            transform.parent.parent.position += faceDir * Distance/ (float)DashFrame;
            yield return null;
        }
    }
    public override void LevelUp()
    {
        InvincibleFrames++;
        Distance *= 1.1f;
    }
}
