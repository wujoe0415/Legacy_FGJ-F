using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : BasicSkill
{
    public GameObject Player;
    public float Distance = 1f;
    private IEnumerator _coroutine;
    public int InvincibleFrames = 15;
    private void Awake()
    {
        Player = GameObject.FindWithTag("Player");
    }
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
        Vector3 faceDir = Player.GetComponent<SpriteRenderer>().flipY? Vector3.left:Vector3.right;
        
        for(int i = 0;i<InvincibleFrames;i++)
        {
            PlayerStatus.Instance.isInvincible = true;
            Player.transform.position += faceDir * Distance/InvincibleFrames;
            yield return null;
        }
            PlayerStatus.Instance.isInvincible = false;
    }
    public override void LevelUp()
    {
        InvincibleFrames++;
        Distance *= 1.1f;
    }
}
