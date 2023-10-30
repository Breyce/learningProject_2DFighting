using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectPlayer : MonoBehaviour
{
    public MapPoints currentPoint;

    public float moveSpeed = 10f;

    private bool levelLoading;

    public LevelSelectManager theManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position,currentPoint.transform.position,moveSpeed * Time.deltaTime);

        //��ֹ��ɫ�߶Խ���
        if (Vector3.Distance(transform.position, currentPoint.transform.position) < .1f && !levelLoading)
        {
            //GetAxisRaw �� GetAxis ������GetAxis��ֵ��0��������1��GetAxisRawֻ�᷵��0��1
            if (Input.GetAxisRaw("Horizontal") > .5f)//Ϊ��
            {
                if (currentPoint.right != null)
                {
                    SetNextPoint(currentPoint.right);
                }
            }

            if (Input.GetAxisRaw("Horizontal") < -.5f)//Ϊ��
            {
                if (currentPoint.left != null)
                {
                    SetNextPoint(currentPoint.left);
                }
            }

            if (Input.GetAxisRaw("Vertical") > .5f)//Ϊ��
            {
                if (currentPoint.up != null)
                {
                    SetNextPoint(currentPoint.up);
                }
            }

            if (Input.GetAxisRaw("Vertical") < -.5f)//Ϊ��
            {
                if (currentPoint.down != null)
                {
                    SetNextPoint(currentPoint.down);
                }
            }

            if (currentPoint.isLevel && currentPoint.levelToLoad != "" && !currentPoint.isLocked)
            {
                LevelSelectUIController.instance.ShowInfo(currentPoint);

                if (Input.GetButtonDown("Jump"))
                {
                    levelLoading = true;
                    theManager.LoadLevel();
                }
            }
        }
    }

    public void SetNextPoint(MapPoints nextPoint)
    {
        currentPoint = nextPoint;
        LevelSelectUIController.instance.HideInfo();
    }
}
