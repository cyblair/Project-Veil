using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed;
    public Vector2 moveDirection;
    private bool canMove = true;
 
    // public Animator Animator; can worry about this later

    private void Update()
    {
        Move(moveDirection);
    }

    private void OnMove(InputValue value)
    {
        moveDirection = value.Get<Vector2>();
    }

    private void Move(Vector2 moveVector)
    {
        if (canMove)
        {
            Vector2 direction = moveVector.normalized;
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
        }
    }
}
