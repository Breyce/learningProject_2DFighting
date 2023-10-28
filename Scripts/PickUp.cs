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

                //��ԭ�ز�����Ч
                Instantiate(pickupEffect, transform.position, transform.rotation);

                UIController.instance.UpdateGemCount();
            }

            if (isHeal && PlayerHealthController.instance.currentHealth != PlayerHealthController.instance.maxHealth)
            {
                PlayerHealthController.instance.HealPlayer(2);

                isCollected = true;

                Destroy(gameObject);

                //��ԭ�ز�����Ч
                Instantiate(pickupEffect, transform.position, transform.rotation);
            }
        }
    }
}
