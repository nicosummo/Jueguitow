using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ScriptAraña : MonoBehaviour
{
    public NavMeshAgent     navAgent;

    public Transform        player;

    public LayerMask        whatIsGround, whatIsPlayer;

    public GameObject       SwitchScript;

    public Animator         anim;



    public int maxHP = 4;
    int currentHP;

    //Patrullaje
    public Vector3 walkPoint;
    bool walkPointSet;
    public float _walkPointRange;

    //Attack
    public float _timeBetweenAttacks;
    bool alreadyAttacked;

    public Transform attackPoint;
    public float _attackHitRange = 0.5f;
    public LayerMask PlayerLayers;
    public int attackDamage;

    //States
    public float _sightRange, _attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake()
    {
        player = GameObject.Find("Explorador").transform;
        navAgent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        currentHP = maxHP;
    }

    private void Update()
    {
        if (SwitchScript.GetComponent<CamAndControlsSwitch>().explorador)
        {
            player = GameObject.Find("Explorador").transform;
        }
        else if (!SwitchScript.GetComponent<CamAndControlsSwitch>().explorador)
        {
            player = GameObject.Find("Ekard").transform;
        }

        playerInSightRange = Physics.CheckSphere(transform.position, _sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, _attackRange, whatIsPlayer);

        //if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInSightRange && playerInAttackRange) AttackPlayer();
    }

    

    private void ChasePlayer()
    {
        navAgent.SetDestination(player.position);
        anim.SetBool("IsWalking", true);
    }

    private void AttackPlayer()
    {
        navAgent.SetDestination(transform.position);

        transform.LookAt(player);

        if (!alreadyAttacked && currentHP > 0)
        {
            anim.SetTrigger("Attack");

            Collider[] hitPlayer = Physics.OverlapSphere(attackPoint.position, _attackRange, PlayerLayers);

            foreach (Collider Personaje in hitPlayer)
            {
                Personaje.GetComponent<TakeDamage>().TakingDamage(attackDamage);
            }

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), _timeBetweenAttacks);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, _attackHitRange);
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;



        if (currentHP <= 0)
        {

            Die();
        }
    }

    void Die()
    {
        navAgent.speed = 0f;
        anim.SetTrigger("Death");
        Destroy(gameObject, 5f);
        Debug.Log("Murio!");
    }
}
