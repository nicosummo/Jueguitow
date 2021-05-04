using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorAttacks : MonoBehaviour
{
    public Animator animator;

    public Transform attackPoint;
    public float _attackRange = 0.5f;
    public LayerMask EnemyLayers;

    public int attackDamage = 2;
    public int heavyAttackDamage = 4;
    public int chargeAttackDamage = 10;

    public float _timer;
    public float _startTimer = 3f;

    float       _fireTimer;
    float       _startFireTimer = 3f;
    public Transform firePoint;
    public GameObject fireAttackPrefab;

    public AudioSource audioSource;
    public AudioClip swordAudio;

    

    private void Start()
    {
        _timer = _startTimer;
        swordAudio = Resources.Load<AudioClip>("Sword");
    }

    public void Attack()
    {
        animator.SetTrigger("warAttack");

        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, _attackRange, EnemyLayers);

        audioSource.PlayOneShot(swordAudio);

        foreach (Collider enemy in hitEnemies)
        {
            enemy.GetComponent<ScriptAraña>().TakeDamage(attackDamage);
            
           
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, _attackRange);
    }

    public void HeavyAttack()
    {
        animator.SetTrigger("warHeavyAttack");

        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, _attackRange, EnemyLayers);

        audioSource.PlayOneShot(swordAudio);

        foreach(Collider enemy in hitEnemies)
        {
            enemy.GetComponent<ScriptAraña>().TakeDamage(heavyAttackDamage);
            

        }

    }

    public void ChargeAttack()
    {
        if (_timer <= 0)
        {
            _timer = _startTimer;
            animator.SetTrigger("ChargeAttacking");
            

            Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, _attackRange, EnemyLayers);

            audioSource.PlayOneShot(swordAudio);

            foreach (Collider enemy in hitEnemies)
            {
                enemy.GetComponent<EnemyHP>().TakeDamage(chargeAttackDamage);
                
            }
        }
    }

    

    public void ChargingFailed()
    {
        _timer = _startTimer;
        animator.SetTrigger("ChargingFailed");
    }

    public void Timer()
    {
        _timer -= Time.deltaTime;
        animator.SetTrigger("Charging");
        

    }

    public void FireAttack()
    {
        if (_fireTimer <= 0)
        {
            Instantiate(fireAttackPrefab, firePoint.transform.position, firePoint.transform.rotation);
            _fireTimer = _startFireTimer;
        }
    }

    public void FireTimer()
    {
        _fireTimer -= Time.deltaTime;
    }
}
