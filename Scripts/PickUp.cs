using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    //是否是捡起物
    public bool isGem, isHeal;

    //是否被捡起
    private bool isCollected = false;

    //捡起特效
    public GameObject pickupEffect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isCollected)
        {
            if (isGem)
            {
                LevelManager.instance.gemsCollected ++;

                isCollected = true;

                Destroy(gameObject);

                //在原地播放特效
                Instantiate(pickupEffect, transform.position, transform.rotation);

                UIController.instance.UpdateGemCount();
            }

            if (isHeal && PlayerHealthController.instance.currentHealth != PlayerHealthController.instance.maxHealth)
            {
                PlayerHealthController.instance.HealPlayer(2);

                isCollected = true;

                Destroy(gameObject);

                //在原地播放特效
                Instantiate(pickupEffect, transform.position, transform.rotation);
            }
        }
    }
}
