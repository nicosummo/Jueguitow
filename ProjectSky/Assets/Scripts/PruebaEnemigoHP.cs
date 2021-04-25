using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PruebaEnemigoHP : MonoBehaviour
{
    HPGuerrero guerreroVida;

    public int cantidad;
    public float damageTime;
    float currentDamageTime;
    

    private void Start()
    {

        
        guerreroVida = GameObject.FindWithTag("CosasGuerrero").GetComponent<HPGuerrero>();
        
    }

    private void OnTriggerStay (Collider other)
    {
        if (other.tag == "CosasGuerrero")
        {
            currentDamageTime += Time.deltaTime;
            if (currentDamageTime > damageTime)
            {
                guerreroVida.vida += cantidad;
                currentDamageTime = 0.0f;
            }
        }
    }
    

}
