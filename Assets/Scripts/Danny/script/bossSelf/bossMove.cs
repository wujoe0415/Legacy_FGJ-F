using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMove : MonoBehaviour
{
    public List<Transform> SpawnPoints = new List<Transform>();
    public bool isPause = false;
    private int _currentIndex;
    public BossAttack _attack;

    private void OnEnable()
    {
        transform.position = SpawnPoints[0].position;
        StartCoroutine(RandomSpawn());
    }
    
    IEnumerator RandomSpawn()
    {
        WaitForSeconds preload = new WaitForSeconds(0.8f);
        WaitForSeconds moveGap = new WaitForSeconds(5.2f);
        while (true)
        {
            if (!isPause)
            {
                yield return preload;
                _attack.Attack();
                yield return moveGap;
                StartCoroutine(fadeIn(0.5f));
                int bossIndex = Random.Range(0, SpawnPoints.Count);
                while (bossIndex == _currentIndex)
                    bossIndex = Random.Range(0, SpawnPoints.Count);
                _currentIndex = bossIndex;
                transform.position = SpawnPoints[_currentIndex].position;
                StartCoroutine(fadeOut(0.5f));
            }
        }
    }
    private void OnDisable()
    {
        StopAllCoroutines();
    }

    IEnumerator fadeOut(float duration)
    {
        yield return new WaitForSeconds(6.5f);
        Color startColor = new Color(1, 1, 1, 1);
        Color endColor = new Color(1, 1, 1, 0);
        float time = 0;
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        while (time < duration)
        {
            time += Time.deltaTime;
            sr.color = Color.Lerp(startColor, endColor, time / duration);
            yield return null;
        }
    }

    IEnumerator fadeIn(float duration)
    {
        Color startColor = new Color(1, 1, 1, 0);
        Color endColor = new Color(1, 1, 1, 1);
        float time = 0;
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        while (time < duration)
        {
            time += Time.deltaTime;
            sr.color = Color.Lerp(startColor, endColor, time / duration);
            yield return null;
        }
    }
}
