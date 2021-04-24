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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Attack();
        }
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
}
