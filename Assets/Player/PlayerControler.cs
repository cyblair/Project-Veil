using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControler : MonoBehaviour
{
    public float movementSpeed;
    public Vector2 moveDirection;
    public InputActionReference move;
    private bool canMove = true;
 
    // public Animator Animator; can worry about this later

    private void OnEnable()
    {
        if (move != null && move.action != null)
        {
            move.action.Enable();
        }
    }
    private void OnDisable()
    {
        if (move != null && move.action != null)
        {
            move.action.Disable();
        }
    }

    private void Update()
    {

        //Animator.SetFloat("Speed", Mathf.Abs(MoveDirection));
        moveDirection = move.action.ReadValue<Vector2>();
        moveMe(moveDirection);
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
        }
    }


}
