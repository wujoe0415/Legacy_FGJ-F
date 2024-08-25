using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMove : MonoBehaviour
{
    [SerializeField]private List<GameObject> gameObjectList;
    public List<Transform> SpawnPoints = new List<Transform>();
    public bool isPause = false;
    private int _currentIndex;
    private Transform _boss;

    private void Start()
    {
        _boss = transform;
        _boss.position = SpawnPoints[0].position;
        StartCoroutine(RandomSpawn());
    }
    IEnumerator RandomSpawn()
    {
        WaitForSeconds preload = new WaitForSeconds(0.8f);
        while (true)
        {
            if (!isPause)
            {
                yield return preload;
                int bossIndex = Random.Range(0, SpawnPoints.Count);
                while(bossIndex != _currentIndex)
                {
                    bossIndex = Random.Range(0, SpawnPoints.Count);
                }

                StartCoroutine(fadeIn(0.5f));
                yield return new WaitForSeconds(7);
                // TODO: bulletSet Debug
                GetComponent<bulletSet>().shotting = false;
                _currentIndex = bossIndex;
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
        SpriteRenderer sr = _boss.GetComponent<SpriteRenderer>();
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
        SpriteRenderer sr = _boss.GetComponent<SpriteRenderer>();
        while (time < duration)
        {
            time += Time.deltaTime;
            sr.color = Color.Lerp(startColor, endColor, time / duration);
            yield return null;
        }
    }
}
