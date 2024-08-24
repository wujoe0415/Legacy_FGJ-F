using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class energyBall : MonoBehaviour
{
    [SerializeField] private GameObject boss,player;
    private Vector2 initPos, bossPos, playerPos;
    private float distance;
    private bool isShot = false;

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
            Vector3 v = player.transform.position - this.transform.position;
            v.z = 0;

            float angle = Vector3.SignedAngle(Vector3.up, v, Vector3.forward);
            Quaternion rotation = Quaternion.Euler(0, 0, angle);
            transform.rotation = rotation;
        }
        else
        {
            this.transform.position = this.transform.forward;
        }
    }

    private void energyBallMove()
    {
        isShot = true;
        distance = Vector2.Distance(initPos, bossPos);
    }
}
