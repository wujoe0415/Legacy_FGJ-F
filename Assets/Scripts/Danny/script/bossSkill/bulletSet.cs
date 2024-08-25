using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletSet : MonoBehaviour
{
    private GameObject b;
    public GameObject bullet;
    private int counter = 0;
    public bool shotting = false;

    void Update()
    {
        if (shotting)
        {
            counter++;
            Vector3 bullet_angle = new Vector3(0, 0, Random.Range(0, 360));
            Vector3 pos = this.transform.position + new Vector3(Random.Range(-0.5f, 0.5f) < 0 ? 1 : -1, Random.Range(-0.5f, 0.5f) < 0 ? 1 : -1, 0);
            if (counter % 200 == 0)
            {
                b = Instantiate(bullet, transform.position, new Quaternion(0, 0, 0, 0));
                b.GetComponent<bullet>().bc.Init = Quaternion.Euler(bullet_angle);
                b.GetComponent<bullet>().bc.position = pos;
                b.GetComponent<bullet>().bc.Initspeed = new Vector3(0, 0.01f, 0);
                set_speed();
                set_trace();
            }
        }
    }

    void set_speed()
    {
        //¥[³t
        b.GetComponent<bullet>().bc.speed_up_bool = true;
        b.GetComponent<bullet>().bc.speed_up_value = 0.0000005f;
    }

    void set_trace()
    {
        //°lÂÜ
        b.GetComponent<bullet>().bc.trace_bool = true;
        b.GetComponent<bullet>().bc.trace_value = 0;
        b.GetComponent<bullet>().bc.trace_count = 1;
    }
}
