using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public float moveSpeed;
    public Rigidbody2D theRB;
    public float jumpForce;

    private bool isGrounded;
    public Transform groundCheckPoint;
    public LayerMask whatIsGround;

    private bool canDoubleJump;

    private Animator anim;
    private SpriteRenderer theSR;

    //受伤击退效果
    public float knockBackLength, knockBackForce;
    private float knockBackCounter;

    //击杀怪物后的反弹效果
    public float bounceForce;

    //游戏结束
    public bool stopInput;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        anim = GetComponent<Animator>();
        theSR = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (!PauseMenu.instance.isPaused && !stopInput)
        {
            if (knockBackCounter <= 0)
            {
                theRB.velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), theRB.velocity.y);

                isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, .2f, whatIsGround);
                if (Input.GetButtonDown("Jump"))
                {
                    if (isGrounded)
                    {
                        //播放跳跃音效
                        AudioManager.instance.PlaySoundEffect(9);

                        canDoubleJump = true;
                        theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
                    }
                    else
                    {
                        if (canDoubleJump)
                        {
                            //播放跳跃音效
                            AudioManager.instance.PlaySoundEffect(9);

                            canDoubleJump = false;
                            theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
                        }
                    }
                }

                if (theRB.velocity.x < 0)
                {
                    theSR.flipX = true;
                }
                else if (theRB.velocity.x > 0)
                {
                    theSR.flipX = false;
                }

            }
            else
            {
                knockBackCounter -= Time.deltaTime;
                if (!theSR.flipX)
                {
                    theRB.velocity = new Vector2(-knockBackForce, theRB.velocity.y);
                }
                else
                {
                    theRB.velocity = new Vector2(knockBackForce, theRB.velocity.y);
                }
            }
        }

        anim.SetBool("isGrounded", isGrounded);
        anim.SetFloat("moveSpeed", Mathf.Abs(theRB.velocity.x));
    }

    //受伤击退
    public void KnockBack()
    {
        knockBackCounter = knockBackLength;
        theRB.velocity = new Vector2(0f,knockBackForce);

        //切换受伤动画
        anim.SetTrigger("hurt");

        //播放击退音效
        AudioManager.instance.PlaySoundEffect(8);
    }

    //击杀怪物后反弹
    public void Bounce()
    {
        theRB.velocity = new Vector2(theRB.velocity.x, bounceForce);

        //播放跳跃音效
        AudioManager.instance.PlaySoundEffect(9);
    }

    //在平台上面走
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Platform")
        {
            transform.parent = other.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Platform")
        {
            transform.parent = null;
        }
    }
}
