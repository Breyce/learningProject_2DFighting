using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slammer : MonoBehaviour
{
    //slammer一开始的位置和砸向的位置
    public Transform theSlammer, slammerTarget;
    //记录初始位置
    private Vector3 startPoint;

    //砸下来的速度，冷却时间，回复的速度
    public float slamSpeed, waitAfterSlam, resetSpeed;
    private float waitCounter;

    //是否砸下和是否重置
    private bool slamming, resetting;

    // Start is called before the first frame update
    void Start()
    {
        startPoint = theSlammer.position;
        slammerTarget.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (!slamming && !resetting)//如果没有砸下也没有在重置，意味着slammer目前原地不动，此时检查玩家有没有靠近
        {
            if (Vector3.Distance(slammerTarget.position, PlayerController.instance.transform.position) < 2f)
            {
                slamming = true;//砸下并初始化在地上等待的时间。
                waitCounter = waitAfterSlam;
            }
        }

        if (slamming)//在砸下的过程中
        {
            theSlammer.position = Vector3.MoveTowards(theSlammer.position, slammerTarget.position, slamSpeed * Time.deltaTime);

            if (theSlammer.position == slammerTarget.position)
            {
                waitCounter -= Time.deltaTime;
                if (waitCounter <= 0)
                {
                    slamming = false;
                    resetting = true;
                }

            }
        }

        if (resetting)
        {
            theSlammer.position = Vector3.MoveTowards(theSlammer.position, startPoint, resetSpeed * Time.deltaTime);

            if (theSlammer.position == startPoint)
            {
                resetting = false;
            }
        }
    }
}