using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class energyBall : MonoBehaviour
{
    private Vector2 initPos, playerPos;
    private bool isShot = false;
    private Vector3 dir = Vector3.zero;

    private void Start()
    {
        initPos = this.gameObject.transform.position;
        Invoke("energyBallMove", 3f);
    }

    private void Update()
    {
        if (!isShot)
        {
            playerPos = Vector2.zero;
            if (EnemyManager.Instance.Target != null)
                playerPos = EnemyManager.Instance.Target.transform.position;
        }
        else
        {
            transform.position = Vector2.Lerp(transform.position, transform.position + dir * 1.5f, 1.5f * Time.deltaTime);
            if(this.gameObject.transform.position.y <= -5f)
            {
                Destroy(this.gameObject);
            }
        }
    }

    private void energyBallMove()
    {
        isShot = true;
        dir = new Vector3(playerPos.x - transform.position.x, playerPos.y - transform.position.y, 0f);
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + 90));
    }
}
