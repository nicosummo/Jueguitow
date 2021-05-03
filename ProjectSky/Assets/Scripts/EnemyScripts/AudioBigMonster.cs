using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioBigMonster : MonoBehaviour
{
    public GameObject scriptMonstruo;

    private void Update()
    {
        if (scriptMonstruo.GetComponent<ScriptBigEnemy>().currentHP <= 0)
        {
            AudioManagerScript.PlaySound("BigMonsterDeath");
        }   
    }
}
