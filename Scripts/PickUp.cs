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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isCollected)
        {
            if (isGem)
            {
                //播放捡起音效
                AudioManager.instance.PlaySoundEffect(6);

                LevelManager.instance.gemsCollected ++;

                isCollected = true;

                Destroy(gameObject);

                //在原地播放特效
                Instantiate(pickupEffect, transform.position, transform.rotation);

                UIController.instance.UpdateGemCount();
            }

            if (isHeal && PlayerHealthController.instance.currentHealth != PlayerHealthController.instance.maxHealth)
            {
                //播放捡起音效
                AudioManager.instance.PlaySoundEffect(7);

                PlayerHealthController.instance.HealPlayer(2);

                isCollected = true;

                Destroy(gameObject);

                //在原地播放特效
                Instantiate(pickupEffect, transform.position, transform.rotation);
            }
        }
    }
}
