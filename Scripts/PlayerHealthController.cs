using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController instance;

    public int currentHealth, maxHealth;

    public float invincibleLength = 1;
    private float invincibleCounter;

    //无敌时变化颜色
    private SpriteRenderer theSR;

    //增加死亡特效
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

            //无敌时间过了之后恢复
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

                //播放死亡动画
                Instantiate(deathEffect, transform.position, transform.rotation);

                //gameObject.SetActive(false);

                //将执行权交给LevelManager
                LevelManager.instance.RespawnPlayer();
            }
            else
            {
                invincibleCounter = invincibleLength;

                //无敌时改变颜色:Unity改变颜色的默认取值为0-1，而非0-255；
                theSR.color = new Color(theSR.color.r, theSR.color.g, theSR.color.b, .5f);

                //受伤时击退
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
