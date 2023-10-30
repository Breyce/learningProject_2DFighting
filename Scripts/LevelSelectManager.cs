using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectManager : MonoBehaviour
{
    public LevelSelectPlayer thePlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadLevel()
    {
        StartCoroutine(LoadLevelCo());
    }

    public IEnumerator LoadLevelCo()
    {
        LevelSelectUIController.instance.FadeToBlack();

        yield return new WaitForSeconds((1f/ LevelSelectUIController.instance.fadeSpeed) + .25f);

        SceneManager.LoadScene(thePlayer.currentPoint.levelToLoad);
    }
}
