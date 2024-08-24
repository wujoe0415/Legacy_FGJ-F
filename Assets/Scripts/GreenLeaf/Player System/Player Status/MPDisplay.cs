using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class MPDisplay : MonoBehaviour
{
    private Image _image;
    public Sprite Filled;
    public Sprite Blank;
    private void Awake(){
        _image = GetComponent<Image>();
    }
    public void Display(bool isFilled)
    {
        _image.sprite = isFilled ? Filled : Blank;
    }
}
