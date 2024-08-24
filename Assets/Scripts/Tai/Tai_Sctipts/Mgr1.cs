using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Mgr1 : MonoBehaviour
{
    public Button startBt;
    
    public Button quitBt;

    public Animator fade;

    void Start()
    {
        quitBt.onClick.AddListener(QuitGame);
        
        startBt.onClick.AddListener(GoStory);
    }

   
    void QuitGame()
    {
        Application.Quit();
    }

    void GoStory()
    {
        fade.SetTrigger("fade");
        Invoke("LoadStory",1f);
    }
    
    void LoadStory()
    {
        SceneManager.LoadScene("Tai_s2");
    }
}
