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
    // Start is called before the first frame update
    void Start()
    {
        if (isLevel && levelToLoad != null)
        {
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
