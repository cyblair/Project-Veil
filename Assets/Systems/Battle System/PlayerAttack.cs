using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Vector2 target;
    public float speed;

    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, Time.deltaTime * speed);
    }
}
