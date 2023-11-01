using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTankController : MonoBehaviour
{
    public enum bossState { shooting, hurt, moving };
    public bossState currentState;

    public Transform theBoss;
    public Animator anim;

    [Header("Movement")]
    public float moveSpeed;
    public Transform leftPoint, rightPoint;

    private bool moveRight;

    [Header("Shooting")]
    public GameObject bullets;
    public Transform firePoint;
    public float timeBetweenShots;
    private int bulletCounter;

    [Header("Hurt")]
    public float hurtTime;
    private float hurtCounter;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        currentState = bossState.shooting;
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case bossState.shooting:
                break;

            case bossState.hurt:
                if (hurtCounter > 0)
                {
                    hurtCounter -= Time.deltaTime;
                    if (hurtCounter <= 0)
                    {
                        currentState = bossState.moving;
                    }
                }
                break;

            case bossState.moving:
                break;
        }
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeHit();
        }
#endif
    }

    public void TakeHit()
    {
        currentState = bossState.hurt;
        hurtCounter = hurtTime;
    }
}
