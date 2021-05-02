using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSensorr : MonoBehaviour
{
    public Animator animator;
    public string boolParameterName = "isGrounded";
    private int contactCount;
    private void OnTriggerEnter(Collider other)
    {
        contactCount++;
        if(contactCount > 0)
        {
            animator.SetBool(boolParameterName, true);
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        contactCount--; 
        if (contactCount < 1)
        {
            animator.SetBool(boolParameterName, false);
        }
    }
}
