using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public Rigidbody2D theBD;

    private bool isGrounded;
    public Transform groundCheckPoint;
    public LayerMask whatIsGround;

    private bool canDoubleJump;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
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

        animator.SetFloat("moveSpeed", Mathf.Abs(theBD.velocity.x));
        animator.SetBool("isGrounded", isGrounded);
    }
}
