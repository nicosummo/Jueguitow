using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{

    public int curHP;
    public int maxHP;
    
    void Start()
    {
        curHP = maxHP;
    }

    public void TakeDamage(int damage)
    {
        //currentHP -= damage;

        curHP -= damage;

        if (curHP <= 0)
        {

            
        }
    }

}
