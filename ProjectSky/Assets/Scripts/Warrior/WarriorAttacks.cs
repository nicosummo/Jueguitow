using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorAttacks : MonoBehaviour
{
    public Animator animator;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask EnemyLayers;

    public int attackDamage = 2;

    public int heavyAttackDamage = 4;

    private void Update()
    {
        HeavyAttack();


    }


    public void Attack()
    {
        animator.SetTrigger("warAttack");

        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, EnemyLayers);

        foreach(Collider enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy1>().TakeDamage(attackDamage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    public void HeavyAttack()
    {
        animator.SetTrigger("warHeavyAttack");

        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, EnemyLayers);

        foreach(Collider enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy1>().TakeDamage(heavyAttackDamage);
        }

    }
}
