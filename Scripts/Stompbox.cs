using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stompbox : MonoBehaviour
{
    public GameObject deathEffects;

    //掉落物
    public GameObject collectible1;
    public GameObject collectible2;
    [Range(0,100)] public float chanceToDrop;//[Range(0,100)]限制了chanceToDrop的数值必须介于0-100

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemies")
        {
            Debug.Log("hit");
            //播放击杀音效
            AudioManager.instance.PlaySoundEffect(3);

            //将父物体设置为不激活
            other.transform.parent.gameObject.SetActive(false);
            //加载死亡特效
            Instantiate(deathEffects, other.transform.position, other.transform.rotation);

            PlayerController.instance.Bounce();

            //掉落物
            float dropSelect = Random.Range(0, 100f);
            if (dropSelect <= chanceToDrop)
            {
                if(PlayerHealthController.instance.currentHealth != PlayerHealthController.instance.maxHealth)
                {
                    Instantiate(collectible1, other.transform.position, other.transform.rotation);
                }
                else
                {
                    Instantiate(collectible2, other.transform.position, other.transform.rotation);
                }
            }

        }
    }
}
