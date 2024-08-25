using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public BattleFieldManager BFManager;
    public UnityEvent OnGameStart;
    public UnityEvent OnGameWin;
    public UnityEvent OnGameLose;
    public static GameManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        OnGameStart.Invoke();
        BFManager.InitBattle();
        BFManager.StartBattle();
    }
    public void NextBattle()
    {
        StartCoroutine(LoadBattle());
    }
    private IEnumerator LoadBattle()
    {
        // TODO: Called Battle UI
        yield return new WaitForSeconds(3f);
        BFManager.StartBattle();
    }
}