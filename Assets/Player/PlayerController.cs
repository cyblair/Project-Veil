using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed;
    private Vector2 moveDirection;
    private bool canMove = true;
 
    // public Animator Animator; can worry about this later

    private void Update()
    {
        if (canMove)
        {
            Move(moveDirection);
        }
    }

    public void BlockMovement()
    {
        canMove = false;
    }

    public void UnblockMovement()
    {
        canMove = true;
    }
    
    /// <summary>
    /// Moves the player with blocking from the environment (Anything on the 'StopMovement' layer will block player
    /// movement).
    /// </summary>
    /// <remarks>
    /// This not check if the <c>canMove</c> flag is <c>true</c>.
    /// </remarks>
    /// <param name="moveVector"> A 2d Vector of the direction to move the player in</param>
    public void Move(Vector2 moveVector)
    {
        Vector2 direction = moveVector.normalized;
        float distance = movementSpeed * Time.deltaTime;
        ContactFilter2D filter = new ContactFilter2D();
        filter.SetLayerMask(LayerMask.GetMask("StopMovement"));
        filter.useTriggers = false;
        RaycastHit2D hit = Physics2D.BoxCast(
            transform.position,
            new Vector2(0.8f, 0.8f),
            0,
            direction,
            distance,
            filter.layerMask.value
        );

        if (!hit)
            transform.position += new Vector3(direction.x, direction.y, 0) * distance;
    }

    /// <summary>
    /// A method that will only be called via broadcasts from a Player Input component. DO NOT CALL THIS METHOD. If you
    /// want to manually move the player use <see cref="Move">Move</see>.
    /// </summary>
    /// <param name="value"></param>
    private void OnMove(InputValue value)
    {
        moveDirection = value.Get<Vector2>();
    }
}
