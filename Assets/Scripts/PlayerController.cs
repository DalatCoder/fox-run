using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public float moveSpeed;
    public float jumpForce;
    public Rigidbody2D theBD;

    private bool isGrounded;
    public Transform groundCheckPoint;
    public LayerMask whatIsGround;

    private bool canDoubleJump;

    private Animator animator;
    private SpriteRenderer theSR;

    public float knockBackLength, knockBackForce;
    private float knockBackCounter;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        theSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (knockBackCounter <= 0)
        {
            theBD.velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), theBD.velocity.y);

            isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, .2f, whatIsGround);

            if (isGrounded) canDoubleJump = true;

            if (Input.GetButtonDown("Jump"))
            {
                if (isGrounded)
                {
                    theBD.velocity = new Vector2(theBD.velocity.x, jumpForce);
                }
                else
                {
                    if (canDoubleJump)
                    {
                        theBD.velocity = new Vector2(theBD.velocity.x, jumpForce);
                        canDoubleJump = false;
                    }
                }
            }

            if (theBD.velocity.x < 0) theSR.flipX = true;
            else if (theBD.velocity.x > 0) theSR.flipX = false;
        }
        else
        {
            knockBackCounter -= Time.deltaTime;

            if (!theSR.flipX)
            {
                theBD.velocity = new Vector2(-knockBackForce, theBD.velocity.y);
            }
            else
            {
                theBD.velocity = new Vector2(knockBackForce, theBD.velocity.y);
            }
        }

        animator.SetFloat("moveSpeed", Mathf.Abs(theBD.velocity.x));
        animator.SetBool("isGrounded", isGrounded);
    }

    public void KnockBack()
    {
        knockBackCounter = knockBackLength;
        theBD.velocity = new Vector2(0f, knockBackForce);

        animator.SetTrigger("hurt");
    }
}
