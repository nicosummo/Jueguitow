using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    public int maxHP = 20;
    public int currentHP;


    private void Start()
    {
        currentHP = maxHP;

    }


    public void TakingDamage(int damage)
    {
        currentHP -= damage;



        if (currentHP <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Moriste!");
    }
}
