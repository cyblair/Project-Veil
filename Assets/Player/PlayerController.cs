using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private Collider2D interactCollider;
    
    private Rigidbody2D rb;
    private Vector2 moveDirection = Vector2.zero;
    private bool canMove = true;

    public Animator animator;
    private Vector2 lastMoveDirection;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        LogInputStatus();
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            Move(moveDirection * movementSpeed);

            bool moving = moveDirection != Vector2.zero;
            if (moving)
            {
                float interactAngle = Vector2.SignedAngle(Vector2.right, moveDirection);
                int segments = 8;
                int angle = 360 / segments;
                int direction = (int)Mathf.Floor(interactAngle / angle);
                interactAngle = direction * angle;
                interactCollider.transform.localEulerAngles = new Vector3(0, 0, interactAngle);
            }

            animator.SetFloat("LastMoveX", lastMoveDirection.x);
            animator.SetFloat("LastMoveY", lastMoveDirection.y);
            animator.SetFloat("MoveX", moveDirection.x);
            animator.SetFloat("MoveY", moveDirection.y);
            animator.SetFloat("MoveMagnitude", moveDirection.magnitude);
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
    /// Moves the player by modifying the rigidbody velocity.
    /// </summary>
    /// <remarks>
    /// This does not check if the <c>canMove</c> flag is <c>true</c>.
    /// </remarks>
    /// <param name="moveVector"> A 2d Vector of the direction to move the player in</param>
    public void Move(Vector2 moveVector)
    {
        rb.velocity = moveVector;
    }

    /// <summary>
    /// A method that will only be called via broadcasts from a Player Input component. DO NOT CALL THIS METHOD. If you
    /// want to manually move the player use <see cref="Move">Move</see>.
    /// </summary>
    /// <param name="value"></param>
    private void OnMove(InputValue value)
    {
        lastMoveDirection = moveDirection;
        // Set move direction to the normalized input direction.
        // Input should already be normalized, but we are using normalized here just in case.
        moveDirection = value.Get<Vector2>().normalized;
    }

    private void OnInteract(InputValue value)
    {
        if (!value.isPressed) return;

        List<Collider2D> results = new List<Collider2D>();
        ContactFilter2D contactFilter = new ContactFilter2D
        {
            layerMask = LayerMask.GetMask("Interactable"),
            useLayerMask = true
        };
        int hits = interactCollider.OverlapCollider(contactFilter, results);

        if (hits <= 0) return;
        
        results[0].gameObject.BroadcastMessage("Interact", this.gameObject);
    }

    #region Device debugging

    private void OnDeviceLost()
    {
        LogInputStatus();
    }

    private void OnDeviceRegained()
    {
        LogInputStatus();
    }

    private void LogInputStatus()
    {
        PlayerInput input = GetComponent<PlayerInput>();
        Debug.Log($"Active: {input.isActiveAndEnabled}");
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.AppendJoin(", ", input.devices);
        Debug.Log($"Devices: [{stringBuilder}]");
    }

    #endregion
}