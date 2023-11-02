using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTankController : MonoBehaviour
{
    public enum bossState { shooting, hurt, moving, ended};
    public bossState currentState;

    public Transform theBoss;
    public Animator anim;

    [Header("Movement")]
    public float moveSpeed;
    public Transform leftPoint, rightPoint;
    private bool moveRight;
    public GameObject mine;
    public Transform minePoint;
    public float timeBetweenMine;
    private float mineCounter;

    [Header("Shooting")]
    public GameObject bullets;
    public Transform firePoint;
    public float timeBetweenShots;
    private float shootCounter;

    [Header("Hurt")]
    public float hurtTime;
    private float hurtCounter;
    public GameObject hitBox;

    [Header("Health")]
    public int health = 5;
    public GameObject explosion, winPlatform;
    private bool isDefeated;
    public float shotSpeedUp, mineSpeedUp;

    // Start is called before the first frame update
    void Start()
    {
        currentState = bossState.shooting;
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case bossState.shooting:
                shootCounter -= Time.deltaTime;
                if(shootCounter < 0)
                {
                    shootCounter = timeBetweenShots;

                    var newBullet = Instantiate(bullets,firePoint.position,firePoint.rotation);

                    //继承父物体的Scale
                    newBullet.transform.localScale = theBoss.localScale;
                }
                break;

            case bossState.hurt:
                if (hurtCounter > 0)
                {
                    hurtCounter -= Time.deltaTime;
                    if (hurtCounter <= 0)
                    {
                        currentState = bossState.moving;
                        mineCounter = 0;

                        if (isDefeated)
                        {
                            theBoss.gameObject.SetActive(false);
                            Instantiate(explosion, theBoss.position, theBoss.rotation);

                            //显示平台
                            winPlatform.SetActive(true);
                            //停止Boss战音乐
                            AudioManager.instance.StopBossMusic();

                            currentState = bossState.ended;
                        }
                    }
                }
                break;

            case bossState.moving:
                if (moveRight)
                {
                    theBoss.position += new Vector3(moveSpeed * Time.deltaTime, 0f, 0f);

                    if(theBoss.position.x > rightPoint.position.x)
                    {
                        theBoss.localScale = new Vector3(1f, 1f, 1f);

                        moveRight = false;

                        EndMoving();
                    }
                }
                else
                {
                    theBoss.position += new Vector3(-moveSpeed * Time.deltaTime, 0f, 0f);

                    if (theBoss.position.x < leftPoint.position.x)
                    {
                        theBoss.localScale = new Vector3(-1f, 1f, 1f);

                        moveRight = true;

                        EndMoving();
                    }
                }

                mineCounter -= Time.deltaTime;

                if (mineCounter <= 0)
                {
                    mineCounter = timeBetweenMine;

                    Instantiate(mine, minePoint.position, minePoint.rotation);
                }
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
        anim.SetTrigger("Hit");
        //播放打击音效
        AudioManager.instance.PlaySoundEffect(0);

        BossTankMine[] mines = FindObjectsOfType<BossTankMine>();

        if (mines.Length > 0)
        {
            foreach(BossTankMine foundMine in mines)
            {
                foundMine.Explode();
            }
        }

        //掉血
        health--;

        if(health <= 0)
        {
            isDefeated = true;
        }
        else
        {
            timeBetweenShots /= shotSpeedUp;
            timeBetweenMine /= mineSpeedUp;
        }
    }

    private void EndMoving()
    {
        currentState = bossState.shooting;

        shootCounter = 0f;

        anim.SetTrigger("StopMoving");

        hitBox.SetActive(true);
    }
}
