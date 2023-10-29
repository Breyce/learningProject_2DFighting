using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    //����ʱ��
    public float waitToRespawn;
    //��ʯ����
    public int gemsCollected;

    private void Awake()
    {
        instance = this;
    }

    public void RespawnPlayer()
    {
        StartCoroutine(RespawnCo());
    }

    private IEnumerator RespawnCo()
    {
        PlayerController.instance.gameObject.SetActive(false);

        yield return new WaitForSeconds(waitToRespawn);

        PlayerController.instance.gameObject.SetActive(true);

        //�����ڼ�¼�����ԭ��
        PlayerController.instance.transform.position = CheckpointController.instance.spawnPoint;
        //�ָ�Ѫ��
        PlayerHealthController.instance.currentHealth = PlayerHealthController.instance.maxHealth;
        //ˢ��Ѫ����
        UIController.instance.UpdateHealthDisplay();
    }
}