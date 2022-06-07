using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    public float moveSpeed;

    public Transform leftPoint;
    public Transform rightPoint;

    private bool isMovingLeft;

    // Start is called before the first frame update
    void Start()
    {
        leftPoint.parent = null;
        rightPoint.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMovingLeft)
        {
            rigidBody.velocity = new Vector2(-moveSpeed, rigidBody.velocity.y);

            if (rigidBody.position.x <= leftPoint.position.x) isMovingLeft = false;
        }
        else
        {
            rigidBody.velocity = new Vector2(moveSpeed, rigidBody.velocity.y);

            if (rigidBody.position.x >= rightPoint.position.x) isMovingLeft = true;
        }
    }
}
