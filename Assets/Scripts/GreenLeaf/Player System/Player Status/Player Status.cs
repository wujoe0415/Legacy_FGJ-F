using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    private static PlayerStatus Instance;

    [SerializeField]
    private Slider HealthPointSlider;
    [SerializeField]
    private Slider HPHintSlider;
    public float CurrentHP = 10f;
    public int CurrentMP = 5;
    public List<MPDisplay> MagicPoints = new List<MPDisplay>();

    [Range(5f, 20f)]
    [SerializeField]
    private float _maxHealthPoint = 10f;
    private int _maxMagicPoint = 5;
    private IEnumerator _coroutine;
    private void Awake()
    {
        HealthPointSlider.maxValue = _maxHealthPoint;
        HPHintSlider.maxValue = _maxHealthPoint;
        _maxMagicPoint = MagicPoints.Count;
        UpdateDisplayHP();
        UpdateDisplayMP();
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
        
        if (Input.GetKeyDown(KeyCode.N))
            IncreaseMP(1);
        if (Input.GetKeyDown(KeyCode.M))
            DecreaseMP(1);
    }
    public void IncreaseHP(float amount)
    {
        CurrentHP += amount;
        CurrentHP = Mathf.Clamp(CurrentHP, 0f, _maxHealthPoint);
        UpdateDisplayHP();
    }
    public void DecreaseHP(float amount)
    {
        CurrentHP -= amount;
        CurrentHP = Mathf.Clamp(CurrentHP, 0f, _maxHealthPoint);
        UpdateDisplayHP(true);
        if (CurrentHP == 0f)
        {
            // TODO: Lose Battle
            Debug.Log("Lose");
        }
    }
    public void IncreaseMP(int amount)
    {
        CurrentMP += amount;
        CurrentMP = Mathf.Clamp(CurrentMP, 0, _maxMagicPoint);
        UpdateDisplayMP();
    }
    public bool DecreaseMP(int amount)
    {
        if (CurrentMP < amount)
            return false;
        CurrentMP -= amount;        
        CurrentMP = Mathf.Clamp(CurrentMP, 0, _maxMagicPoint);
        UpdateDisplayMP();
        return true;
    }
    private void UpdateDisplayHP(bool needHint = false)
    {
        HealthPointSlider.value = CurrentHP;
        if(needHint && CurrentHP != 0f)
        {
            if (_coroutine != null)
            StopCoroutine(_coroutine);
            _coroutine = UpdateHP();
            StartCoroutine(_coroutine);
        }
        else 
            HPHintSlider.value = CurrentHP;         
        
    }
    private void UpdateDisplayMP()
    {
        // TODO: update MP
        for(int i = 0;i<MagicPoints.Count;i++)
        {
            MagicPoints[i].Display(i<CurrentMP);
        }
    }
    IEnumerator UpdateHP()
    {
        float speed = 0.0013f;
        
        for (float f = Mathf.Abs(HPHintSlider.value - CurrentHP); f>0;f-=speed)
        {
            Debug.Log(HPHintSlider.value);
            HPHintSlider.value = HPHintSlider.value - speed;
            yield return null;
        }
        HPHintSlider.value = CurrentHP;
    }
}
