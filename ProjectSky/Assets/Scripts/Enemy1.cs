using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    public int maxHP = 20;
    int currentHP;

   
    private void Start()
    {
        currentHP = maxHP;

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
        Debug.Log("Moriste!");
    }
}
