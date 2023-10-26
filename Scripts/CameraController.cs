using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Transform farBackground, middleBackground;

    //private float lastXPos;
    private Vector2 lastPos;

    public float minHeight, maxHeight;
    // Start is called before the first frame update
    void Start()
    {
        //lastXPos = transform.position.x;
        lastPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);

        /*
            数学的钳制函数，Clamp(a, b, c)当a为[b, c]时，返回结果为a；当a大于c或小于b时，返回c或b
            float clampedY = Mathf.Clamp(transform.position.y, minHeight, maxHeight);
            transform.position = new Vector3(target.position.x, clampedY, transform.position.z);
        */

        transform.position = new Vector3(target.position.x, Mathf.Clamp(target.position.y, minHeight, maxHeight), transform.position.z);

        //float amountToMoveX = transform.position.x - lastXPos;
        Vector2 amountToMove = new Vector2(transform.position.x - lastPos.x, transform.position.y - lastPos.y);
        farBackground.position = farBackground.position + new Vector3(amountToMove.x, amountToMove.y, 0f);
        middleBackground.position += new Vector3(amountToMove.x, amountToMove.y, 0f) * .5f;

        lastPos = transform.position;
    }
}
