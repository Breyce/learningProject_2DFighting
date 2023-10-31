using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectManager : MonoBehaviour
{
    public LevelSelectPlayer thePlayer;

    private MapPoints[] allPoints;
    // Start is called before the first frame update
    void Start()
    {
        allPoints = FindObjectsOfType<MapPoints>();

        if (PlayerPrefs.HasKey("CurrentLevel"))
        {
            foreach(MapPoints point in allPoints)
            {
                if(point.levelToLoad == PlayerPrefs.GetString("CurrentLevel"))
                {
                    thePlayer.transform.position = point.transform.position;
                    thePlayer.currentPoint = point;
                }
            }
        }

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
        //≤•∑≈“Ù–ß
        AudioManager.instance.PlaySoundEffect(4);

        LevelSelectUIController.instance.FadeToBlack();

        yield return new WaitForSeconds((1f/ LevelSelectUIController.instance.fadeSpeed) + .25f);

        SceneManager.LoadScene(thePlayer.currentPoint.levelToLoad);
    }
}
