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
    public Transform _ball;
    public bool _readyShoot = false;
    private Transform _player;
    private void Awake(){
        _player = transform.parent.parent;
        _ball = Instantiate(Ball, transform.position, Quaternion.identity, transform).transform;
        _ball.gameObject.SetActive(false);
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
        _ball.GetComponent<PlayerAttackCollider>().Damage = Damage;
        bool isRight= !_player.GetComponent<SpriteRenderer>().flipY;
        _ball.GetComponent<Animator>().SetTrigger("Release");
        // add force to ball
        _ball.GetComponent<Rigidbody2D>().AddForce(isRight ? Vector2.right * ShootSpeed : Vector2.left * ShootSpeed, ForceMode2D.Impulse);
        Invoke("DisableBall", 0.8f);
        _readyShoot = false;
    }
    public override void LevelUp()
    {
        Damage += 5;
    }
    private void DisableBall()
    {
        _ball.gameObject.SetActive(false);
    }
    private void Update()
    {
        
        if (CurrentCoolDownTime <= CoolDownTime){
            CurrentCoolDownTime += Time.deltaTime;
            return;
        }
        if(Input.GetKeyDown(SkillKey)){
            StartCoroutine(PreservingBall());
        }
    }
    private IEnumerator PreservingBall()
    {
        _ball.localScale = Vector3.zero;
        _ball.localPosition = Vector3.zero;
        _ball.gameObject.SetActive(true);
        float currentTime = 0f;
        for (currentTime = 0f; currentTime < PreservingTime + 1f; currentTime += Time.deltaTime)
        {
            if(!Input.GetKey(SkillKey))
                break;
            _ball.localScale = Vector3.one * (Mathf.Min(currentTime, PreservingTime) / PreservingTime);
            _ball.localPosition = Vector3.zero;
            //Debug.Log(_ball.transform.localScale);
            yield return null;
        }
        if(currentTime< PreservingTime){
            // Fail preserving
            _readyShoot = false;
            _ball.gameObject.SetActive(false);
        }
        else{
            // Success preserving
            _readyShoot = true;
        }
    }
}