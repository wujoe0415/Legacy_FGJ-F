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
    private void Awake(){
        currentPlayerIndex = 0;
        GameObject player = Instantiate(Players[currentPlayerIndex], PlayerSpawnPoint.position, Quaternion.identity, this.transform);
        GameObject enemy = Instantiate(Enemy, EnemySpawnPoint.position, Quaternion.identity, this.transform);
        // TODO: Init Battle
    }

    public void SwitchPlayer(GameObject Player)
    {
        if (currentPlayerIndex < Players.Count - 1)
            currentPlayerIndex++;
        else
        {
            GameManager.Instance.OnGameLose.Invoke();
            Debug.Log("Lose");
            return;
        }
        SkillSystem skillSystem = Player.GetComponent<SkillSystem>();
        GameObject nextPlayer = Instantiate(Players[currentPlayerIndex], PlayerSpawnPoint.position, Quaternion.identity, this.transform);
        SkillSystem nextSS = nextPlayer.GetComponent<SkillSystem>();
        for (int i = 0; i < currentPlayerIndex; i++)
        {
            nextSS.AppendSkill(Skills[i]);
        }
        Destroy(Player);
        EnemyManager em = Enemy.GetComponent<EnemyManager>();
        em.SetTarget(nextPlayer);
        em.ResetEnemy();
    }

}
