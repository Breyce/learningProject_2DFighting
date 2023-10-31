using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu instance;
    public string levelSelect,mainMenu;

    public GameObject pauseScreen;
    public bool isPaused;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        pauseScreen.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseUnpause();
        }
    }

    public void PauseUnpause()
    {
        if (isPaused)
        {
            isPaused = false;
            pauseScreen.SetActive(false);

            Time.timeScale = 1.0f;
        }
        else
        {
            isPaused = true;
            pauseScreen.SetActive(true);

            Time.timeScale = 0f;//游戏中时间流速为0，所有都暂停了
        }
    }

    public void LevelSelect()
    {
        //记录PlayerMark到当前关卡位置
        PlayerPrefs.SetString("CurrentLevel", SceneManager.GetActiveScene().name);

        SceneManager.LoadScene(levelSelect);
        Time.timeScale = 1.0f;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(mainMenu);
        Time.timeScale = 1.0f;
    }
}
