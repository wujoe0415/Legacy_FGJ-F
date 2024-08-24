using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mgr3 : MonoBehaviour
{
    public GameObject teachPanel;
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            teachPanel.SetActive(false);
        }
    }
}
