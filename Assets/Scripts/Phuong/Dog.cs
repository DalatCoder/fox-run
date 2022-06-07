using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
    public float moveSpeed;
    public Transform leftPoint;
    public Transform rightPoint;
    public Rigidbody2D rigidbodytest;
    public SpriteRenderer spriteRenderer;

    private bool imovingleft;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealthController.instance.DealDamage();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        leftPoint.parent = null;
        rightPoint.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (imovingleft)
        {
            rigidbodytest.velocity = new Vector2(-moveSpeed, rigidbodytest.velocity.y);
            if (transform.position.x <= leftPoint.position.x)
            {
                imovingleft = false;
                spriteRenderer.flipX = false;
            }
        }
        else
        {
            rigidbodytest.velocity = new Vector2(+moveSpeed, rigidbodytest.velocity.y);
            if (transform.position.x >= rightPoint.position.x)
            {
                imovingleft = true;
                spriteRenderer.flipX = true;
            }
        }
    }
}
