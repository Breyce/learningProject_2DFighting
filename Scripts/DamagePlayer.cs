using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            //Debug.Log("Hits");
            /*
             ���ֻ�ȡ�ķ�����
            1. FindObjectOfType<PlayerHealthController>().DealDamage();
            2. ����ģʽ
             */

            PlayerHealthController.instance.DealDamage();
        }
    }
}
