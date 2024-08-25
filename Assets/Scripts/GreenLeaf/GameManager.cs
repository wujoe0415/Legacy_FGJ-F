using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public BattleFieldManager BFManager;
    public UnityEvent OnGameStart;
    public UnityEvent OnGameEnd;
    public UnityEvent OnGameWin;
    public UnityEvent OnGameOver;
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
        OnGameStart?.Invoke();
        BFManager.InitBattle();
        BFManager.StartBattle();
    }
    public void NextBattle()
    {
        StartCoroutine(LoadBattle());
    }
    public GameObject Teach;

    private IEnumerator LoadBattle()
    {
        // TODO: Called Battle UI
        OnGameEnd?.Invoke();
        while(!Input.GetKeyDown(KeyCode.X))
            yield return null;
        Teach.SetActive(true);
        yield return new WaitForSeconds(3f);
        Teach.SetActive(false);
        OnGameStart?.Invoke();

        BFManager.StartBattle();
    }
    public void GameOver()
    {
        OnGameOver?.Invoke();
    }
    public void GameSuccess()
    {
        OnGameWin?.Invoke();
    }
    private void Update()
    {
        
        
        //ED2測試鍵
        if (Input.GetKeyDown(KeyCode.O))
        {
            GameSuccess();
        }
        
        //ED3測試鍵
        if (Input.GetKeyDown(KeyCode.P))
        {
            
GameOver();
        }
        
    }
}