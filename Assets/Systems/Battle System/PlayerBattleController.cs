using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerBattleController : MonoBehaviour
{
    [SerializeField] private Weapon weapon;
    [SerializeField] private GameObject attackObject;
    private bool attacking = false;
    private float attackTimer = 0;
    private Vector2 attackStart = Vector2.zero;
    [SerializeField] private Vector2 cursorPos = Vector2.zero;
    private Vector2 cursorVelocity = Vector2.zero;
    private Camera cam;
    private LineRenderer lr;
    [SerializeField] private GameObject cursorObject;
    [SerializeField] private SpriteRenderer cursorSprite;

    private void Start()
    {
        cam = Camera.main;
        lr = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        if (attackTimer > 0)
        {
            attackTimer -= Time.deltaTime;
            cursorSprite.color = Color.Lerp(Color.gray, Color.red, attackTimer/weapon.attackSpeed);
        }
        else
        {
            cursorSprite.color = Color.white;
        }
        
        //cursorPos += cursorVelocity;
        //cursorPos = Input.mousePosition;
        if (attacking)
        {
            lr.SetPosition(1, GetCursorPos());
        }
    }

    private Vector2 GetCursorPos()
    {
        return cam.ScreenToWorldPoint(new Vector3(cursorPos.x, cursorPos.y, cam.nearClipPlane));
    }
    
    private void OnAttack(InputValue value)
    {
        bool pressed = value.Get<float>() > 0.5f;
        if (!pressed && attacking)
        {
            // Release
            lr.enabled = false;
            GameObject attack = Instantiate(attackObject, attackStart, Quaternion.identity);
            PlayerAttack attackScript = attack.GetComponent<PlayerAttack>();
            Vector2 fullTranslate = GetCursorPos() - attackStart;
            fullTranslate = fullTranslate.normalized * Mathf.Min(fullTranslate.magnitude, weapon.attackSize);
            attackScript.target = attackStart + fullTranslate;
            attacking = false;
            return;
        }
            
        if (!pressed || attackTimer > 0) return;

        // Press
        attacking = true;
        attackTimer = weapon.attackSpeed;
        attackStart = GetCursorPos();
        lr.enabled = true;
        lr.SetPosition(0, GetCursorPos());
    }
    
    private void OnAttackMove(InputValue value)
    {
        cursorVelocity = value.Get<Vector2>();
    }

    private void OnMousePos(InputValue value)
    {
        cursorPos = value.Get<Vector2>();
        cursorObject.transform.position = GetCursorPos();
    }
}
