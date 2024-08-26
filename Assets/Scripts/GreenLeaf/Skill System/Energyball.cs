using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energyball : BasicSkill
{
    public float PreservingTime = 1f;
    public float Damage = 10f;
    public float ShootSpeed = 10f;
    public GameObject Ball;
    private Transform _enemy;
    private Transform _heldBall;
    private bool _readyShoot = false;
    private AudioSource _gatheringSound;

    private void Awake(){
        _gatheringSound = GetComponent<AudioSource>();
        _enemy = Object.FindObjectOfType<EnemyManager>().transform;
    }
    public override bool CanUseSkill()
    {
        if(CoolDownTime > CurrentCoolDownTime)
            return false;
        if(Input.GetKeyUp(SkillKey) && _readyShoot)
        {
            Debug.Log("EnergyBall");
            return true;
        }
        else
            return false;
    }
    public override void Skill()
    {
        // TODO: Spawn Ball
        _heldBall.GetComponent<PlayerAttackCollider>().Damage = Damage;
        _heldBall.GetComponent<Animator>().SetTrigger("Release");
        // add force to ball
        Vector2 direction = _enemy.position - transform.position;
        _heldBall.GetComponent<Rigidbody2D>().AddForce(direction * ShootSpeed, ForceMode2D.Impulse);
        _readyShoot = false;
        _heldBall.gameObject.AddComponent<DestorySelf>();
        _heldBall = null;
    }
    public override void LevelUp()
    {
        Damage += 5;
    }

    private void Update()
    {
        if (CurrentCoolDownTime <= CoolDownTime){
            CurrentCoolDownTime += Time.deltaTime;
            return;
        }
        if(Input.GetKeyDown(SkillKey) && _heldBall == null && PlayerStatus.Instance.CurrentMP >= MPCost){
            _heldBall = Instantiate(Ball, transform.position, Quaternion.identity, transform).transform;
            StartCoroutine(PreservingBall());
        }
    }
    private IEnumerator PreservingBall()
    {
        _heldBall.localScale = Vector3.zero;
        _heldBall.localPosition = Vector3.zero;
        float currentTime = 0f;
        for (currentTime = 0f; currentTime < PreservingTime + 1f; currentTime += Time.deltaTime)
        {
            if(!Input.GetKey(SkillKey))
                break;
            _heldBall.localPosition = Vector3.zero;
            //Debug.Log(_heldBall.transform.localScale);
            yield return null;
        }
        if(currentTime< PreservingTime){
            // Fail preserving
            _readyShoot = false;
            Destroy(_heldBall.gameObject);
            _heldBall = null;
        }
        else{
            // Success preserving
            _gatheringSound.Play();
            _readyShoot = true;
        }
    }
}