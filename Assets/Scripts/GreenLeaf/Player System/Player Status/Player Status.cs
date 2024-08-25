using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    public static PlayerStatus Instance;
    public float CurrentHP = 10f;
    public int CurrentMP = 5;
    public float DefensePoint = 0f;
    public bool isInvincible = false;
    public Sprite ProfilePhoto;

    [Range(5f, 20f)]
    [SerializeField]
    private float _maxHealthPoint = 10f;
    private int _maxMagicPoint = 5;
    private IEnumerator _coroutine;
    private PlayerUIManager _playerUIManager;
    private void Awake()
    {
        _playerUIManager = Object.FindObjectOfType<PlayerUIManager>();
        _playerUIManager.ProfilePhotoDisplay.sprite = ProfilePhoto;
        _playerUIManager.HealthPointSlider.maxValue = _maxHealthPoint;
        _playerUIManager.HPHintSlider.maxValue = _maxHealthPoint;
        _maxMagicPoint = _playerUIManager.MagicPoints.Count;
        _playerUIManager.UpdateDisplayHP(_maxHealthPoint);
        _playerUIManager.UpdateDisplayMP(_maxMagicPoint);
        CurrentHP = _maxHealthPoint;
        CurrentMP = _maxMagicPoint;
        if (Instance != null && Instance!=this)
            Destroy(this);
        else
            Instance = this;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
            IncreaseHP(1f);
        if (Input.GetKeyDown(KeyCode.J))
            DecreaseHP(1f);
        
        if (Input.GetKeyDown(KeyCode.M))
            IncreaseMP(1);
        if (Input.GetKeyDown(KeyCode.N))
            DecreaseMP(1);
    }
    public void TakeDamage(float damage)
    {
        DecreaseHP(Mathf.Max(0f, damage - DefensePoint));
    }
    public void IncreaseHP(float amount)
    {
        CurrentHP += amount;
        CurrentHP = Mathf.Clamp(CurrentHP, 0f, _maxHealthPoint);
        _playerUIManager.UpdateDisplayHP(CurrentHP);
    }
    public void DecreaseHP(float amount)
    {
        if(isInvincible)
            return;
        CurrentHP -= amount;
        CurrentHP = Mathf.Clamp(CurrentHP, 0f, _maxHealthPoint);
        _playerUIManager.UpdateDisplayHP(CurrentHP, true);
        if (CurrentHP == 0f)
        {
            _playerUIManager.UpdateDisplayHP(CurrentHP);
            Object.FindObjectOfType<BattleFieldManager>().SwitchPlayer(gameObject);
            Destroy(gameObject);
        }
    }
    public void IncreaseMP(int amount)
    {
        CurrentMP += amount;
        CurrentMP = Mathf.Clamp(CurrentMP, 0, _maxMagicPoint);
        _playerUIManager.UpdateDisplayMP(CurrentMP);
    }
    public bool DecreaseMP(int amount)
    {
        if (CurrentMP < amount)
            return false;
        CurrentMP -= amount;        
        CurrentMP = Mathf.Clamp(CurrentMP, 0, _maxMagicPoint);
        _playerUIManager.UpdateDisplayMP(CurrentMP);
        return true;
    }
    
}
