using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class EnemyBattleLogic : MonoBehaviour
{
    [SerializeField] private Enemy enemy;
    [SerializeField] private Image healthbar;
    private float pathProgress;
    private float battleTime;
    private Animator animator;

    private float maxHealth;
    private bool dead = false;
    
    private void Start()
    {
        animator = GetComponent<Animator>();
        maxHealth = enemy.health;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Follow enemy.path
        pathProgress += Time.deltaTime / enemy.moveTime;
        if (pathProgress > 1) pathProgress -= 1;
        transform.position = enemy.path.GetPoint(pathProgress);
        
        if (dead) return;
        
        // Attack timer
        battleTime += Time.deltaTime;
        float enemyAttackTime = enemy.attackSpeed;
        if (battleTime > enemyAttackTime)
        {
            battleTime -= enemyAttackTime;
            Attack();
        }

        healthbar.fillAmount = enemy.health / maxHealth;
        
        if (enemy.health <= 0)
        {
            animator.SetTrigger("death");
            dead = true;
        }
    }

    void Attack()
    {
        animator.SetTrigger("attack");
        Vector2 offset = Random.insideUnitCircle.normalized * Random.Range(1f, 5f);
        Vector3 pos = new Vector3(transform.position.x + offset.x, transform.position.y + offset.y, transform.position.z - 1);
        Instantiate(enemy.attackPrefab, pos, Quaternion.identity);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerAttack") && !animator.GetCurrentAnimatorStateInfo(0).IsName("damage"))
        {
            PlayerAttack attack = other.gameObject.GetComponent<PlayerAttack>();
            enemy.health -= attack.damage;
            attack.target = attack.transform.position;
            
            animator.SetTrigger(enemy.health > 0 ? "damaged" : "death");
        }
    }

    public void AnimationEnd()
    {
        SceneManager.LoadScene("New Super Dialogue System (1)");
    }
}
