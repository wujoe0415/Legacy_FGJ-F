using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mgr3 : MonoBehaviour
{
    public GameObject teachPanel;

    public Animator fade;

    //測試結局
    public static bool isLose;
    public static bool isWin;
    void Start()
    {
        isLose = false;
        isLose = false;
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            teachPanel.SetActive(false);
        }
        
        //ED1測試鍵
        if (Input.GetKeyDown(KeyCode.I))
        {
            fade.SetTrigger("fade");
            isLose = true;
            Invoke("LoadED",2f);
        }
        
        //ED2測試鍵
        if (Input.GetKeyDown(KeyCode.O))
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
