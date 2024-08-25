using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class energyBall : MonoBehaviour
{
    [SerializeField] private GameObject boss,player;
    private Vector2 initPos, bossPos, playerPos;
    private bool isShot = false;
    private Vector3 dir = Vector3.zero;

    private void Start()
    {
        bossPos = boss.transform.position;
        
        if (bossPos.x <= 0)
        {
            this.gameObject.transform.position = new Vector2(-7f, 3.5f);
        }
        else
        {
            this.gameObject.transform.position = new Vector2(7f, 3.5f);
        }

        initPos = this.gameObject.transform.position;

        Invoke("energyBallMove", 3f);
    }

    private void Update()
    {
        if (!isShot)
        {
            playerPos = player.transform.position;
        }
        else
        {
            transform.position = Vector2.Lerp(transform.position, transform.position + dir * 1.5f, 1.5f * Time.deltaTime);
            //if (playerPos.x > initPos.x)
            //{
                
            //    //if (playerPos.y > initPos.y)
            //    //{
            //    //    this.transform.position = Vector2.Lerp(this.transform.position, , 2 * (playerPos.y + Mathf.Abs(playerPos.y - this.transform.position.y))), 1f * Time.deltaTime);
            //    //}
            //    //else
            //    //{
            //    //    this.transform.position = Vector2.Lerp(this.transform.position, new Vector2(2 * (playerPos.x + Mathf.Abs(playerPos.x - this.transform.position.x)), 2 * (playerPos.y - Mathf.Abs(playerPos.y - this.transform.position.y))), 1f * Time.deltaTime);
            //    //}
            //}
            //else if (playerPos.x < initPos.x)
            //{
            //    if (playerPos.y > initPos.y)
            //    {
            //        this.transform.position = Vector2.Lerp(this.transform.position, new Vector2(2 * (playerPos.x - Mathf.Abs(playerPos.x - this.transform.position.x)), 2 * (playerPos.y - Mathf.Abs(playerPos.y - this.transform.position.y))), 1f * Time.deltaTime);
            //    }
            //    else
            //    {
            //        this.transform.position = Vector2.Lerp(this.transform.position, new Vector2(2 * (playerPos.x - Mathf.Abs(playerPos.x - this.transform.position.x)), 2 * (playerPos.y + Mathf.Abs(playerPos.y - this.transform.position.y))), 1f * Time.deltaTime);
            //    }
            //}
        }
    }

    private void energyBallMove()
    {
        isShot = true;
        dir = new Vector3(playerPos.x - transform.position.x, playerPos.y - transform.position.y, 0f);
    }
}
