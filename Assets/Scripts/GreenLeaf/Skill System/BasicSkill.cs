using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(AudioSource), typeof(SpriteRenderer))]
public class BasicSkill : MonoBehaviour
{
    [Header("Numerical Data")]
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
    public Action OnSkillStart;

    [Header("Special Effect")]
    public SpriteRenderer SpecialEffect;
    public Transform RightCGPoint;
    public Transform LeftCGPoint;
    public bool isDetach = false;
    private bool _spriteRightFaced = true;
    private SpriteRenderer _playerFaceDir;
    public float SpecialEffectDuration = 0.5f;
    private AudioSource _audioSource;
    protected bool isRight
    {
        get
        {
            return !_playerFaceDir.flipX;
        }
    }

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _playerFaceDir = transform.parent.parent.GetComponent<SpriteRenderer>();
        CurrentCoolDownTime = CoolDownTime + 1f;
        _spriteRightFaced = SpecialEffect.flipX;
    }
    private void OnEnable()
    {
        OnSkillStart += StartSpecialEffect;
        OnSkillRelease += () => { CurrentCoolDownTime = 0; Invoke("EndSpecialEffect", SpecialEffectDuration); };
    }
    private void OnDisable()
    {
        OnSkillStart = delegate { };
        OnSkillRelease = delegate { };
    }
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
            OnSkillStart?.Invoke();
            Skill();
            OnSkillRelease?.Invoke();
            _usageTimes++;
            if(_usageTimes % UsageLevelStandard == 0 && _usageTimes != 0 && _proficiency < _maxProficency)
            {
                LevelUp();
                _proficiency++;
            }
            return;
        }
    }
    public void StartSpecialEffect()
    {
        SpecialEffect.gameObject.SetActive(true);
        if (isDetach)
            SpecialEffect.transform.parent = null;
        SpecialEffect.flipX = isRight? _spriteRightFaced:!_spriteRightFaced;
        SpecialEffect.transform.position = isRight ? RightCGPoint.position: LeftCGPoint.position;
    }
    public void EndSpecialEffect()
    {
        //SpecialEffect.transform.position = transform.position;
        if(isDetach)
            SpecialEffect.transform.parent = transform;
        SpecialEffect.gameObject.SetActive(false);
        
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
