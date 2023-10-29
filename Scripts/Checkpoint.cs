using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public SpriteRenderer theSR;

    public Sprite cpOn, cpOff;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //if(other.CompareTag("Player"))
        if (other.tag == "Player")
        {
            //�����еļ�¼��ȫ������ΪʧЧ
            CheckpointController.instance.DeactivateCheckpoints();

            //������ǰ��¼��
            theSR.sprite = cpOn;

            CheckpointController.instance.SetSpawnPoint(transform.position);
        }

    }

    public void ResetCheckpoint()
    {
        theSR.sprite = cpOff;
    }
}