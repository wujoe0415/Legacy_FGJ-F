using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : BasicSkill
{
    public GameObject Player;
    public float Distance = 1f;
    private IEnumerator _coroutine;
    public int InvincibleFrames = 15;
    public GameObject DashEffect;
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
        bool isRight = Player.GetComponent<SpriteRenderer>().flipX;
        Vector3 faceDir = isRight? Vector3.left:Vector3.right;
        if(isRight)
            DashEffect.transform.rotation = Quaternion.Euler(0,0,0);
        else
            DashEffect.transform.rotation = Quaternion.Euler(0,180,0);
        DashEffect.SetActive(true);
        for(int i = 0;i<InvincibleFrames;i++)
        {
            PlayerStatus.Instance.isInvincible = true;
            Player.transform.position += faceDir * Distance/InvincibleFrames;
            yield return null;
        }
        PlayerStatus.Instance.isInvincible = false;
        DashEffect.SetActive(false);
    }
    public override void LevelUp()
    {
        InvincibleFrames++;
        Distance *= 1.1f;
    }
}
