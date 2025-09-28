using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public bool canMove = true;
    public bool isMoving = false;
    public float movementSpeed;
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            moveMe(new Vector2(-1, 0));
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveMe(new Vector2(1, 0));
        }
        if (Input.GetKey(KeyCode.W))
        {
            moveMe(new Vector2(0, 1));
        }
        else if (Input.GetKey(KeyCode.S))
        {
            moveMe(new Vector2(0, -1));
        }

    }

 

    private void moveMe(Vector2 moveVect)
    {
        if (canMove)
        {
            Vector2 direction = moveVect.normalized;
            float distance = movementSpeed * Time.deltaTime;
            ContactFilter2D filter = new ContactFilter2D();
            filter.SetLayerMask(LayerMask.GetMask("StopMovement"));
            filter.useTriggers = false;
            RaycastHit2D[] results = new RaycastHit2D[1];
            int hitCount = Physics2D.BoxCast(
                transform.position,
                new Vector2(0.8f, 0.8f),
                0,
                direction,
                filter,
                results,
                distance
            );

            if (hitCount == 0)
            {
                transform.position += new Vector3(direction.x, direction.y, 0) * distance;
            }

            isMoving = direction.magnitude > 0.1f;
        }
    }
}
