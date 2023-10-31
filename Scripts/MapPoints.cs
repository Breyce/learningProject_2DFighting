using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPoints : MonoBehaviour
{
    public MapPoints up, right, down, left;
    public bool isLevel;

    public string levelToLoad, levelToCheck, levelName;

    public bool isLocked;

    public int gemsCollected, totalGems;
    public float bestTime, targetTime;

    //展示小图标
    public GameObject badgeClock, badgeGem;
    // Start is called before the first frame update
    void Start()
    {
        if (isLevel && levelToLoad != null)
        {
            //展示关卡信息
            if(PlayerPrefs.HasKey(levelToLoad + "_gems"))
            {
                gemsCollected = PlayerPrefs.GetInt(levelToLoad + "_gems");
            }

            if (PlayerPrefs.HasKey(levelToLoad + "_time"))
            {
                bestTime = PlayerPrefs.GetFloat(levelToLoad + "_time");
            }

            //展示小图标
            if (gemsCollected >= totalGems)
            {
                badgeGem.SetActive(true);
            }

            if (bestTime <= targetTime && bestTime != 0f)
            {
                badgeClock.SetActive(true);
            }


            isLocked = true;

            if(levelToCheck != null)
            {
                if(PlayerPrefs.HasKey(levelToCheck + "_unlocked"))
                {
                    if(PlayerPrefs.GetInt(levelToCheck + "_unlocked") == 1)
                    {
                        isLocked = false;
                    }
                }
            }
            
            if(levelToLoad == levelToCheck)
            {
                isLocked = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
