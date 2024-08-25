using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : BasicSkill
{
    private Transform _player;
    public float Damage = 1f;
    public GameObject Sword;
    private GameObject _sword;
    public Transform RightHoldPoint;
    public Transform LeftHoldPoint;
    private void Awake()
    {
        _player = transform.parent.parent;
        _sword = Instantiate(Sword, transform.position, Quaternion.identity, transform);
        _sword.SetActive(false);
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
        _sword.SetActive(true);
        _sword.GetComponent<PlayerAttackCollider>().Damage = Damage;
        bool isRight= !_player.GetComponent<SpriteRenderer>().flipY;
        _sword.GetComponent<Animator>().SetBool("IsRight", isRight);
        _sword.transform.parent = isRight ? RightHoldPoint: LeftHoldPoint;
        Invoke("DisableSword", 0.26f);
        Debug.Log("Attack!");
    }
    private void DisableSword()
    {
        _sword.SetActive(false);
    } 
    public override void LevelUp()
    {
        Damage += 5;
    }
}