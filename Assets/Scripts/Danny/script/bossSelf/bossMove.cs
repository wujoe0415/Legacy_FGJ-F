using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossMove : MonoBehaviour
{
    [SerializeField]private List<GameObject> gameObjectList;
    private int nowIndex;
    private GameObject go;

    private void Start()
    {
        go = gameObjectList[0];
        InvokeRepeating("move", 0, 7);
    }


    IEnumerator movePos(GameObject go)
    {
        StartCoroutine(fadeIn(0.5f));
        go.SetActive(true);
        yield return new WaitForSeconds(7);
        go.GetComponent<bulletSet>().shotting = false;
        go.SetActive(false);
    }

    private void move()
    {
        int bossIndex = Random.Range(1, gameObjectList.Count);
        if (nowIndex != bossIndex)
        {
            go = gameObjectList[bossIndex];
            StartCoroutine("movePos", go);
        }
        else
        {
            while(nowIndex == bossIndex)
            {
                bossIndex = Random.Range(1, gameObjectList.Count);
            }
            go = gameObjectList[bossIndex];
            StartCoroutine("movePos", go);
        }
        nowIndex = bossIndex;
        go = gameObjectList[bossIndex];
        StartCoroutine(fadeOut(0.5f));
    }

    IEnumerator fadeOut(float duration)
    {
        yield return new WaitForSeconds(6.5f);
        Color startColor = new Color(1, 1, 1, 1);
        Color endColor = new Color(1, 1, 1, 0);
        float time = 0;
        while (time < duration)
        {
            time += Time.deltaTime;
            go.GetComponent<SpriteRenderer>().color = Color.Lerp(startColor, endColor, time / duration);
            yield return null;
        }
    }

    IEnumerator fadeIn(float duration)
    {
        Color startColor = new Color(1, 1, 1, 0);
        Color endColor = new Color(1, 1, 1, 1);
        float time = 0;
        while (time < duration)
        {
            time += Time.deltaTime;
            go.GetComponent<SpriteRenderer>().color = Color.Lerp(startColor, endColor, time / duration);
            yield return null;
        }
    }
}
