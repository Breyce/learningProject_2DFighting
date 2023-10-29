using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stompbox : MonoBehaviour
{
    public GameObject deathEffects;

    //������
    public GameObject collectible1;
    public GameObject collectible2;
    [Range(0,100)] public float chanceToDrop;//[Range(0,100)]������chanceToDrop����ֵ�������0-100

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemies")
        {
            Debug.Log("hit");
            //���Ż�ɱ��Ч
            AudioManager.instance.PlaySoundEffect(3);

            //������������Ϊ������
            other.transform.parent.gameObject.SetActive(false);
            //����������Ч
            Instantiate(deathEffects, other.transform.position, other.transform.rotation);

            PlayerController.instance.Bounce();

            //������
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
