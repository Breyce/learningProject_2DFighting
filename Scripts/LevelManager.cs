using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    //重生时间
    public float waitToRespawn;
    //宝石数量
    public int gemsCollected;
    //加载下一关
    public string levelToLoad;
    //花费时间
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

        //死亡等待淡入淡出
        yield return new WaitForSeconds(waitToRespawn - (1 / UIController.instance.fadeSpeed));

        UIController.instance.FadeToBlack();

        yield return new WaitForSeconds(1 / UIController.instance.fadeSpeed + .2f);

        UIController.instance.FadeFromBlack();

        PlayerController.instance.gameObject.SetActive(true);

        //重生在记录点或者原点
        PlayerController.instance.transform.position = CheckpointController.instance.spawnPoint;
        //恢复血量
        PlayerHealthController.instance.currentHealth = PlayerHealthController.instance.maxHealth;
        //刷新血量条
        UIController.instance.UpdateHealthDisplay();
    }

    public void EndLevel()
    {
        StartCoroutine(EndLevelCo());
    }

    public IEnumerator EndLevelCo()
    {
        //播放结束音乐
        AudioManager.instance.PlayLevelVictory();

        PlayerController.instance.stopInput = true;
        CameraController.instance.stopFollow = true;
        UIController.instance.levelCompleteText.SetActive(true);

        yield return new WaitForSeconds(1.5f);

        UIController.instance.FadeToBlack();

        yield return new WaitForSeconds((1 / UIController.instance.fadeSpeed + .2f) + 3f);

        //解锁下一关
        PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "_unlocked", 1);
        //移动PlayerMark到当前关卡位置
        PlayerPrefs.SetString("CurrentLevel",SceneManager.GetActiveScene().name);

        //存储宝石数
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
        //存储时间
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
