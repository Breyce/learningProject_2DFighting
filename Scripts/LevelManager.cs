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
    //����ʱ��
    public float timeInLevel;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        timeInLevel = 0f;
    }

    void Update()
    {
        timeInLevel += Time.deltaTime;
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
        //���Ž�������
        AudioManager.instance.PlayLevelVictory();

        PlayerController.instance.stopInput = true;
        CameraController.instance.stopFollow = true;
        UIController.instance.levelCompleteText.SetActive(true);

        yield return new WaitForSeconds(1.5f);

        UIController.instance.FadeToBlack();

        yield return new WaitForSeconds((1 / UIController.instance.fadeSpeed + .2f) + 3f);

        //������һ��
        PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "_unlocked", 1);
        //�ƶ�PlayerMark����ǰ�ؿ�λ��
        PlayerPrefs.SetString("CurrentLevel",SceneManager.GetActiveScene().name);

        //�洢��ʯ��
        if (PlayerPrefs.HasKey(SceneManager.GetActiveScene().name + "_gems"))
        {
            if(gemsCollected > PlayerPrefs.GetInt(SceneManager.GetActiveScene().name + "_gems"))
            {
                PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "_gems", gemsCollected);
            }
        }
        else
        {
            PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "_gems", gemsCollected);
        }
        //�洢ʱ��
        if(PlayerPrefs.HasKey(SceneManager.GetActiveScene().name + "_time"))
        {
            if(timeInLevel < PlayerPrefs.GetFloat(SceneManager.GetActiveScene().name + "_time"))
            {
                PlayerPrefs.SetFloat(SceneManager.GetActiveScene().name + "_time", timeInLevel);
            }
        }
        else
        {
            PlayerPrefs.SetFloat(SceneManager.GetActiveScene().name + "_time", timeInLevel);
        }

        SceneManager.LoadScene(levelToLoad);
    }
}
