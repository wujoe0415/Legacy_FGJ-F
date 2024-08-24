using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mgr3 : MonoBehaviour
{
    public GameObject teachPanel;

    public Animator fade;

    public static bool isWin;
    void Start()
    {
        isWin = false;
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            teachPanel.SetActive(false);
        }
        
        //ED1測試鍵
        if (Input.GetKeyDown(KeyCode.Q))
        {
            fade.SetTrigger("fade");
            isWin = true;
            Invoke("LoadED",2f);
        }
    }

    void LoadED()
    {
        SceneManager.LoadScene("Tai_sED");
    }
}
