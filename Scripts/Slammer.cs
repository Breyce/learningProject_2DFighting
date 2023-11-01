using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slammer : MonoBehaviour
{
    //slammerһ��ʼ��λ�ú������λ��
    public Transform theSlammer, slammerTarget;
    //��¼��ʼλ��
    private Vector3 startPoint;

    //���������ٶȣ���ȴʱ�䣬�ظ����ٶ�
    public float slamSpeed, waitAfterSlam, resetSpeed;
    private float waitCounter;

    //�Ƿ����º��Ƿ�����
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
        if (!slamming && !resetting)//���û������Ҳû�������ã���ζ��slammerĿǰԭ�ز�������ʱ��������û�п���
        {
            if (Vector3.Distance(slammerTarget.position, PlayerController.instance.transform.position) < 2f)
            {
                slamming = true;//���²���ʼ���ڵ��ϵȴ���ʱ�䡣
                waitCounter = waitAfterSlam;
            }
        }

        if (slamming)//�����µĹ�����
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