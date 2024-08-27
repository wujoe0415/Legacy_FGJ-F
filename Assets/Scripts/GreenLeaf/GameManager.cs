using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public BattleFieldManager BFManager;
    public UnityEvent OnGameStart;
    public UnityEvent OnGameEnd;
    public UnityEvent OnGameWin;
    public UnityEvent OnGameOver;
    public static GameManager Instance;

    private int round = 0;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
        round = 0;
    }
    public Sprite[] TeachUIs;
    private void Start()
    {
        StartCoroutine(InitBattle());
    }
    public void NextBattle()
    {
        StartCoroutine(LoadBattle());
    }
    public Image TeachUI;
    public GameObject LoadUI;
    private IEnumerator InitBattle()
    {
        TeachUI.sprite = TeachUIs[round];
        TeachUI.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        TeachUI.gameObject.SetActive(false);

        OnGameStart?.Invoke();
        BFManager.InitBattle();
        BFManager.StartBattle();
    }
    private IEnumerator LoadBattle()
    {
        round++;
        OnGameEnd?.Invoke();
        LoadUI.SetActive(true);
        while (!Input.GetKeyDown(KeyCode.X))
            yield return null;
        LoadUI.SetActive(false);
        TeachUI.sprite = TeachUIs[round];
        TeachUI.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        TeachUI.gameObject.SetActive(false);
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
}