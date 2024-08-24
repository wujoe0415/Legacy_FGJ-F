using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mgr4 : MonoBehaviour
{
    public GameObject others, ed1, ed2;

    public Animator fade;

    void Start()
    {
        others.SetActive(false);
        ed1.SetActive(false);
        ed2.SetActive(false);
    }

    void Update()
    {
        //勇者戰敗且還有候補
        if (Mgr3.isLose == true)
        {
            others.SetActive(true);
            if (Input.GetKeyDown(KeyCode.X))
            {
                fade.SetTrigger("fade");
                Invoke("BackToBoss",2f);
            }
        }
        
        //勇者贏了
        if (Mgr3.isWin == true)
        {
            ed1.SetActive(true);
            Invoke("BackToTitle",10f);
            
        }
    }

    void BackToBoss()
    {
        SceneManager.LoadScene("Tai_s3");
    }

    void BackToTitle()
    {
        SceneManager.LoadScene("Tai_s1");
    }
}