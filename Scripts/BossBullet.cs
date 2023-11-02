using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    public float moveSpeed;

    void Start()
    {
        //播放发射音效
        AudioManager.instance.PlaySoundEffect(2);
    }

    void Update()
    {
        transform.position += new Vector3(-moveSpeed * transform.localScale.x * Time.deltaTime, 0f, 0f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            PlayerHealthController.instance.DealDamage();
        }

        //播放碰撞音效
        AudioManager.instance.PlaySoundEffect(1);

        Destroy(gameObject);
    }
}
