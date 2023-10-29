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
        PlayerController.instance.stopInput = true;
        CameraController.instance.stopFollow = true;
        UIController.instance.levelCompleteText.SetActive(true);

        yield return new WaitForSeconds(1.5f);

        UIController.instance.FadeToBlack();

        yield return new WaitForSeconds((1 / UIController.instance.fadeSpeed + .2f) + .25f);

        SceneManager.LoadScene(levelToLoad);
    }
}
