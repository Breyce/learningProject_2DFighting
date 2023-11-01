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

    //���˻���Ч��
    public float knockBackLength, knockBackForce;
    private float knockBackCounter;

    //��ɱ�����ķ���Ч��
    public float bounceForce;

    //��Ϸ����
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
                        //������Ծ��Ч
                        AudioManager.instance.PlaySoundEffect(9);

                        canDoubleJump = true;
                        theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
                    }
                    else
                    {
                        if (canDoubleJump)
                        {
                            //������Ծ��Ч
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

    //���˻���
    public void KnockBack()
    {
        knockBackCounter = knockBackLength;
        theRB.velocity = new Vector2(0f,knockBackForce);

        //�л����˶���
        anim.SetTrigger("hurt");

        //���Ż�����Ч
        AudioManager.instance.PlaySoundEffect(8);
    }

    //��ɱ����󷴵�
    public void Bounce()
    {
        theRB.velocity = new Vector2(theRB.velocity.x, bounceForce);

        //������Ծ��Ч
        AudioManager.instance.PlaySoundEffect(9);
    }

    //��ƽ̨������
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
