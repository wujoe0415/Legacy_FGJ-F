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
    public static bool allDie;

    void Start()
    {
        isLose = false;
        isLose = false;
        allDie = false;
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            teachPanel.SetActive(false);
        }
        
        
    }
    public void GameSuccess()
    {
            fade.SetTrigger("fade");
            isWin = true;
            Invoke("LoadED",2f);
    }
    public void GameOver()
    {
            fade.SetTrigger("fade");
            allDie = true;
            Invoke("LoadED",2f);
    }
    public void Fade()
    {
        fade.SetTrigger("fade");
    }
    void LoadED()
    {
        SceneManager.LoadScene("Tai_sED");
    }
}
