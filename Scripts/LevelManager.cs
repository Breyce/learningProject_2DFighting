using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    //����ʱ��
    public float waitToRespawn;
    //��ʯ����
    public int gemsCollected;
    //������һ��
    public string levelToLoad;

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

        //�����ȴ����뵭��
        yield return new WaitForSeconds(waitToRespawn - (1 / UIController.instance.fadeSpeed));

        UIController.instance.FadeToBlack();

        yield return new WaitForSeconds(1 / UIController.instance.fadeSpeed + .2f);

        UIController.instance.FadeFromBlack();

        PlayerController.instance.gameObject.SetActive(true);

        //�����ڼ�¼�����ԭ��
        PlayerController.instance.transform.position = CheckpointController.instance.spawnPoint;
        //�ָ�Ѫ��
        PlayerHealthController.instance.currentHealth = PlayerHealthController.instance.maxHealth;
        //ˢ��Ѫ����
        UIController.instance.UpdateHealthDisplay();
    }

    public void EndLevel()
    {
        StartCoroutine(EndLevelCo());
    }

    public IEnumerator EndLevelCo()
    {
        PlayerController.instance.stopInput = true;
        CameraController.instance.stopFollow = true;
        UIController.instance.levelCompleteText.SetActive(true);

        yield return new WaitForSeconds(1.5f);

        UIController.instance.FadeToBlack();

        yield return new WaitForSeconds((1 / UIController.instance.fadeSpeed + .2f) + .25f);

        SceneManager.LoadScene(levelToLoad);
    }
}
