using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossMove : MonoBehaviour
{
    [SerializeField]private List<GameObject> gameObjectList;
    private int nowIndex;

    private void Start()
    {
        GameObject go = gameObjectList[0];
        InvokeRepeating("move", 0, 5);
    }


    IEnumerator movePos(GameObject go)
    {
        go.SetActive(true);
        yield return new WaitForSeconds(5);
        go.GetComponent<bulletSet>().shotting = false;
        go.SetActive(false);
    }

    private void move()
    {
        int bossIndex = Random.Range(1, gameObjectList.Count);
        if(nowIndex != bossIndex)
        {
            GameObject go = gameObjectList[bossIndex];
            StartCoroutine("movePos", go);
        }
        else
        {
            while(nowIndex == bossIndex)
            {
                bossIndex = Random.Range(1, gameObjectList.Count);
            }
            GameObject go = gameObjectList[bossIndex];
            StartCoroutine("movePos", go);
        }
        nowIndex = bossIndex;
    }
}
