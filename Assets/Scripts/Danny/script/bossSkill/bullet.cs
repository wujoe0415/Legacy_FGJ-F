using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public bullet_con bc = new bullet_con();
    private float counter = 0;


    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = bc.Init;
        transform.position = bc.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(bc.Initspeed);

        if (bc.speed_up_bool)
        {
            bc.Initspeed = bc.Initspeed.normalized * (bc.Initspeed.magnitude + bc.speed_up_value);
        }
        if (bc.rotate_bool)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0, 0, bc.rotate_value));
        }

        if (bc.trace_bool)
        {
            counter++;
            if (counter > bc.trace_value && bc.trace_count > 0)
            {
                
                float AngleZ = Random.Range(0, 3.14f);
                if (EnemyManager.Instance.Target != null)
                    AngleZ = Mathf.Atan2(EnemyManager.Instance.Target.transform.position.y - this.transform.position.y, EnemyManager.Instance.Target.transform.position.x - this.transform.position.x);
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, AngleZ * Mathf.Rad2Deg - 90));
                counter = 0;
                bc.trace_count--;
            }
        }

        if (transform.position.y >= 7 || transform.position.y <= -7 || transform.position.x >= 10 || transform.position.x <= -10)
        {
            Destroy(this.gameObject);
        }
    }
    public class bullet_con
    {
        public Quaternion Init;
        public Vector3 position, Initspeed;
        public bool speed_up_bool = false, rotate_bool = false, trace_bool = false;
        public float speed_up_value = 0f, rotate_value = 0f;
        public int trace_value = 0, trace_count = 0;
    }
}