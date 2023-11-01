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
             几种获取的方法：
            1. FindObjectOfType<PlayerHealthController>().DealDamage();
            2. 单例模式
             */

            PlayerHealthController.instance.DealDamage();
        }
    }
}
