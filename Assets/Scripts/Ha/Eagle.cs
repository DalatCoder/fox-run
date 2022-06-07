using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eagle : MonoBehaviour
{
    public Rigidbody2D rdBody2;
    public Transform leftPoint;
    public Transform rightPoint;
    public float moveSpeed;
    private bool isMovingLeft;
    public SpriteRenderer spRenderer;



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
            rdBody2.velocity = new Vector2(-moveSpeed, rdBody2.velocity.y);

            if (transform.position.x <= leftPoint.position.x)
            {
                isMovingLeft = false;
                spRenderer.flipX = true;
            }
        }
        else
        {
            rdBody2.velocity = new Vector2(+moveSpeed, rdBody2.velocity.y);

            if (transform.position.x >= rightPoint.position.x)
            {
                isMovingLeft = true;
                spRenderer.flipX = false;
            }
        }
    }
}
