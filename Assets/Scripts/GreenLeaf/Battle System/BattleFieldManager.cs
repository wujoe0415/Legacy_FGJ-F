using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BattleFieldManager : MonoBehaviour
{
    public List<GameObject> Players = new List<GameObject>();
    public Transform PlayerSpawnPoint;
    private int currentPlayerIndex = 0;
    public GameObject Enemy;
    public Transform EnemySpawnPoint;
    public List<BasicSkill> Skills = new List<BasicSkill>();

    public void InitBattle()
    {
        currentPlayerIndex = 0;
        Enemy.transform.position = new Vector3(0, 0, 0);
        //GameObject enemy = Instantiate(Enemy, EnemySpawnPoint.position, Quaternion.identity, this.transform);
    }
    public void StartBattle()
    {
        GameObject nextPlayer = Instantiate(Players[currentPlayerIndex], PlayerSpawnPoint.position, Quaternion.identity, this.transform);
        nextPlayer.name = "player";
        GameObject SkillSystem = new GameObject("SkillSystem");
        SkillSystem.transform.parent = nextPlayer.transform;
        SkillSystem.transform.localPosition = Vector3.zero;

        SkillSystem nextSS = nextPlayer.AddComponent<SkillSystem>();
        for (int i = 0; i < currentPlayerIndex+1; i++)
        {
            BasicSkill s = Instantiate(Skills[i], SkillSystem.transform).GetComponent<BasicSkill>();
            nextSS.AppendSkill(s);
        }
        // for (int i = 0; i < Skills.Count; i++)
        // {
        //     BasicSkill s = Instantiate(Skills[i], SkillSystem.transform).GetComponent<BasicSkill>();
        //     nextSS.AppendSkill(s);
        // }
        // EnemyManager em = Enemy.GetComponent<EnemyManager>();
        // em.SetTarget(nextPlayer);
        // em.ResetEnemy();
    }

    public void SwitchPlayer(GameObject Player)
    {
        Debug.Log(currentPlayerIndex);
        if (currentPlayerIndex < Players.Count - 1)
            currentPlayerIndex++;
        else
        {
            GameManager.Instance.OnGameOver.Invoke();
            Debug.Log("Lose");
            return;
        }
        GameManager.Instance.NextBattle();
    }

}
