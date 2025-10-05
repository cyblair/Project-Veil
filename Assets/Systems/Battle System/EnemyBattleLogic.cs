using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBattleLogic : MonoBehaviour
{
    [SerializeField] private Enemy enemy;
    private float pathProgress;
    private float battleTime;

    // Update is called once per frame
    void FixedUpdate()
    {
        // Follow enemy.path
        pathProgress += Time.deltaTime / enemy.moveTime;
        if (pathProgress > 1) pathProgress -= 1;
        transform.position = enemy.path.GetPoint(pathProgress);
        
        // Attack timer
        battleTime += Time.deltaTime;
        float enemyAttackTime = enemy.attackSpeed;
        if (battleTime > enemyAttackTime)
        {
            battleTime -= enemyAttackTime;
            Attack();
        }
    }

    void Attack()
    {
        // Play the attack animation
        // Create the attack object (enemy.attack)
    }
}
