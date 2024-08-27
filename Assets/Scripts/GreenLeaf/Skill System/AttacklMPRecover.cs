using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttacklMPRecover : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            PlayerStatus.Instance.IncreaseMP(1);
        }
    }
}
