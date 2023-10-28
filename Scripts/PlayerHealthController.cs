using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController instance;

    public int currentHealth, maxHealth;

    public float invincibleLength = 1;
    private float invincibleCounter;

    //�޵�ʱ�仯��ɫ
    private SpriteRenderer theSR;

    //����������Ч
    public GameObject deathEffect;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;

        theSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(invincibleCounter > 0)
        {
            invincibleCounter -= Time.deltaTime;

            //�޵�ʱ�����֮��ָ�
            if(invincibleCounter <= 0)
            {
                theSR.color = new Color(theSR.color.r, theSR.color.g, theSR.color.b, 1f);
            }
        }
    }

    public void DealDamage() 
    {
        if(invincibleCounter <= 0)
        {
            currentHealth--;

            if (currentHealth <= 0)
            {
                currentHealth = 0;

                //������������
                Instantiate(deathEffect, transform.position, transform.rotation);

                //gameObject.SetActive(false);

                //��ִ��Ȩ����LevelManager
                LevelManager.instance.RespawnPlayer();
            }
            else
            {
                invincibleCounter = invincibleLength;

                //�޵�ʱ�ı���ɫ:Unity�ı���ɫ��Ĭ��ȡֵΪ0-1������0-255��
                theSR.color = new Color(theSR.color.r, theSR.color.g, theSR.color.b, .5f);

                //����ʱ����
                PlayerController.instance.KnockBack();
            }

            UIController.instance.UpdateHealthDisplay();
        }
    }

    public void HealPlayer(int amount)
    {
        currentHealth += amount;

        if(currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }

        UIController.instance.UpdateHealthDisplay();
    }
}
