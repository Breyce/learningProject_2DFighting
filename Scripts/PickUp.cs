using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    //�Ƿ��Ǽ�����
    public bool isGem, isHeal;

    //�Ƿ񱻼���
    private bool isCollected = false;

    //������Ч
    public GameObject pickupEffect;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isCollected)
        {
            if (isGem)
            {
                //���ż�����Ч
                AudioManager.instance.PlaySoundEffect(6);

                LevelManager.instance.gemsCollected ++;

                isCollected = true;

                Destroy(gameObject);

                //��ԭ�ز�����Ч
                Instantiate(pickupEffect, transform.position, transform.rotation);

                UIController.instance.UpdateGemCount();
            }

            if (isHeal && PlayerHealthController.instance.currentHealth != PlayerHealthController.instance.maxHealth)
            {
                //���ż�����Ч
                AudioManager.instance.PlaySoundEffect(7);

                PlayerHealthController.instance.HealPlayer(2);

                isCollected = true;

                Destroy(gameObject);

                //��ԭ�ز�����Ч
                Instantiate(pickupEffect, transform.position, transform.rotation);
            }
        }
    }
}
