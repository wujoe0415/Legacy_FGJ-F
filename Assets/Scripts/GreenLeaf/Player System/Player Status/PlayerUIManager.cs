using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Collections;

public class PlayerUIManager : MonoBehaviour
{
    public Image ProfilePhotoDisplay;
    public Slider HealthPointSlider;
    public Slider HPHintSlider;
    public List<MPDisplay> MagicPoints = new List<MPDisplay>();
    private IEnumerator _coroutine;

    public void UpdateDisplayHP(float currentHP, bool needHint = false)
    {
        HealthPointSlider.value = currentHP;
        if(needHint && currentHP != 0f)
        {
            if (_coroutine != null)
            StopCoroutine(_coroutine);
            _coroutine = UpdateHP(currentHP);
            StartCoroutine(_coroutine);
        }
        else 
            HPHintSlider.value = currentHP;         
        
    }
    public void UpdateDisplayMP(int mp)
    {
        // TODO: update MP
        for(int i = 0;i<MagicPoints.Count;i++)
        {
            MagicPoints[i].Display(i<mp);
        }
    }
    IEnumerator UpdateHP(float currentHP)
    {
        float speed = 0.0013f;
        
        for (float f = Mathf.Abs(HPHintSlider.value - currentHP); f>0;f-=speed)
        {
            HPHintSlider.value -= speed;
            yield return null;
        }
        HPHintSlider.value = currentHP;
    }
}