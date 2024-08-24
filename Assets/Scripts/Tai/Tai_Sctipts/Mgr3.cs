using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mgr3 : MonoBehaviour
{
    public GameObject teachPanel;

    public Animator fade;
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            teachPanel.SetActive(false);
        }
        
        //ED測試鍵
        if (Input.GetKeyDown(KeyCode.Q))
        {
            fade.SetTrigger("fade");
            Invoke("LoadED",2f);
        }
    }

    void LoadED()
    {
        SceneManager.LoadScene("Tai_sED");
    }
}
