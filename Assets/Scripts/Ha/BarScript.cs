using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarScript : MonoBehaviour
{
    public float moveSpeed;
    public Transform leftPoint, rightPoint;

    private bool moveRight;
    private Rigidbody2D theRB;

    // Start is called before the first frame update
    void Start()
    {
        theRB = GetComponent<Rigidbody2D>();

        leftPoint.parent = null;
        rightPoint.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (moveRight)
        {
            theRB.velocity = new Vector2(moveSpeed, theRB.velocity.y);
            if (transform.position.x > rightPoint.position.x) moveRight = false;
        }
        else
        {
            theRB.velocity = new Vector2(-moveSpeed, theRB.velocity.y);
            if (transform.position.x < leftPoint.position.x) moveRight = true;
        }
    }
}
