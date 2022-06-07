using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rat : MonoBehaviour
{
    public Rigidbody2D rigidbody2;
    public Transform leftPoint;
    public Transform rightPoint;
    public float moveSpeed;
    private bool isMovingLeft;
    public SpriteRenderer spriteRenderer;


    // Start is called before the first frame update
    void Start()
    {
        leftPoint.parent = null;
        rightPoint.parent = null;
        isMovingLeft = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerHealthController.instance.DealDamage();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isMovingLeft)
        {
            rigidbody2.velocity = new Vector2(-moveSpeed, rigidbody2.velocity.y);

            if (transform.position.x <= leftPoint.position.x)
            {
                isMovingLeft = false;
                spriteRenderer.flipX = true;
            }
        }
        else
        {
            rigidbody2.velocity = new Vector2(+moveSpeed, rigidbody2.velocity.y);

            if (transform.position.x >= rightPoint.position.x)
            {
                isMovingLeft = true;
                spriteRenderer.flipX = false;
            }
        }

    }
}
