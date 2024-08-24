using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mgr2 : MonoBehaviour
{
    public Animator fade;

  

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            fade.SetTrigger("fade");
            Invoke("LoadGame",3f);
        }
    }


    void LoadGame()
    {
        SceneManager.LoadScene("Tai_s3");
    }
}