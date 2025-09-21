using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControler : MonoBehaviour
{
    public float Speed;
    public Vector2 MoveDirection;
    public InputActionReference move;
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
        MoveDirection = move.action.ReadValue<Vector2>();
        transform.Translate(MoveDirection * Time.deltaTime * Speed);
    }

}
