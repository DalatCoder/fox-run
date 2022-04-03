using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LSPlayer : MonoBehaviour
{
    public MapPoint currentPoint;
    public float moveSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Move the player
        transform.position = Vector3.MoveTowards(transform.position, currentPoint.transform.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, currentPoint.transform.position) < 0.1f)
        {
            // Player go to right
            if (Input.GetAxisRaw("Horizontal") > 0.5f)
            {
                if (currentPoint.right) SetNextPoint(currentPoint.right);
            }
            // Player go to left
            if (Input.GetAxisRaw("Horizontal") < -0.5f)
            {
                if (currentPoint.left) SetNextPoint(currentPoint.left);
            }

            // Player go up
            if (Input.GetAxisRaw("Vertical") > 0.5f)
            {
                if (currentPoint.up) SetNextPoint(currentPoint.up);
            }
            // Player go down
            if (Input.GetAxisRaw("Vertical") < -0.5f)
            {
                if (currentPoint.down) SetNextPoint(currentPoint.down);
            }
        }
    }

    public void SetNextPoint(MapPoint nextPoint)
    {
        currentPoint = nextPoint;
    }
}
