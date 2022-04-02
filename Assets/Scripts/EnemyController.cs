using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed;
    public Transform leftPoint, rightPoint;

    private bool moveRight;
    private Rigidbody2D theRB;

    public SpriteRenderer theSR;

    public float moveTime, waitTime;
    private float moveCount, waitCount;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        theRB = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        leftPoint.parent = null;
        rightPoint.parent = null;

        moveCount = moveTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (moveCount > 0)
        {
            Move();
            moveCount -= Time.deltaTime;

            if (moveCount <= 0) waitCount = Random.Range(waitTime * 0.5f, waitTime * 1.5f);
        }
        else if (waitTime > 0)
        {
            Pause();
            waitCount -= Time.deltaTime;

            if (waitCount <= 0) moveCount = Random.Range(moveTime * 0.5f, moveTime * 1.5f);
        }
    }

    private void Move()
    {
        if (moveRight)
        {
            theRB.velocity = new Vector2(moveSpeed, theRB.velocity.y);
            theSR.flipX = true;

            if (transform.position.x > rightPoint.position.x) moveRight = false;
        }
        else
        {
            theRB.velocity = new Vector2(-moveSpeed, theRB.velocity.y);
            theSR.flipX = false;

            if (transform.position.x < leftPoint.position.x) moveRight = true;
        }

        animator.SetBool("isMoving", true);
    }

    private void Pause()
    {
        theRB.velocity = new Vector2(0f, theRB.velocity.y);
        animator.SetBool("isMoving", false);
    }
}
