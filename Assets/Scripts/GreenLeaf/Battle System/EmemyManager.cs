using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject Target;
    public float HealthPoint = 100f;
    public float AttackPoint = 10f;

    public void TakeDamage(float damage)
    {
        HealthPoint -= damage;
        if (HealthPoint <= 0)
        {
            Destroy(gameObject);
            GameManager.Instance.OnGameWin.Invoke();
            Debug.Log("Enemy Die");
        }
    }
    public void SetTarget(GameObject target)
    {
        Target = target;
    }
    public void Attack()
    {
        // TODO: Attack Target
        Debug.Log($"Enemy Attack {Target.name}");
    }
    public void ResetEnemy()
    {
        HealthPoint = 100f;
    }
}