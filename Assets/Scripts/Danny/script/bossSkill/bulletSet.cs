using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletSet : BossBasicSkill
{
    public GameObject Bullet;
    public override void UseSkill()
    {
        StartCoroutine(Shoot());
    }
    public IEnumerator Shoot()
    {
        int bulletNum = Random.Range(10, 20);
        while(bulletNum-- >0)
        {
            Vector3 bullet_angle = new Vector3(0, 0, Random.Range(0, 360));
            Vector3 pos = this.transform.position + new Vector3(Random.Range(-0.5f, 0.5f) < 0 ? 1 : -1, Random.Range(-0.5f, 0.5f) < 0 ? 1 : -1, 0);
            
            bullet b = Instantiate(Bullet, transform.position, new Quaternion(0, 0, 0, 0)).GetComponent<bullet>();
            b.bc.Init = Quaternion.Euler(bullet_angle);
            b.bc.position = pos;
            b.bc.Initspeed = new Vector3(0, 0.01f, 0);

            yield return null;
        }
    }
}
