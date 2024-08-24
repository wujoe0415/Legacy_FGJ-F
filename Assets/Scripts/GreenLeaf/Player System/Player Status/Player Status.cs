using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    private static PlayerStatus Instance;

    [SerializeField]
    private Slider HealthPointSlider;
    public float CurrentHP;
    [Range(5f, 20f)]
    private float _maxHealthPoint = 10f;
    private void Awake()
    {
        if (Instance != null && Instance!=this)
            Destroy(this);
        else
            Instance = this;
    }

    public void RecoverHealth(float amount)
    {
        CurrentHP += amount;
        CurrentHP = Mathf.Clamp(CurrentHP, 0f, _maxHealthPoint);
        HealthPointSlider.value = CurrentHP;
    }
    public void DamageHealth(float amount)
    {
        CurrentHP -= amount;
        CurrentHP = Mathf.Clamp(CurrentHP, 0f, _maxHealthPoint);
        if (CurrentHP == 0f)
        {
            // TODO: Lose Battle
            Debug.Log("Lose");
        }
        HealthPointSlider.value = CurrentHP;
    }


}
