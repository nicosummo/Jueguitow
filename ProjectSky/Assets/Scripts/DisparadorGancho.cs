using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparadorGancho : MonoBehaviour
{
    [SerializeField] float pullSpeed = 0.5f;
    [SerializeField] float stopDistance = 4f;
    [SerializeField] GameObject hookPrefab;
    [SerializeField] Transform shootTransform;

    Gancho gancho;
    bool pulling;
    Rigidbody rb;

    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        pulling = false;
        
    }

    
    void Update()
    {
        if(gancho == null && Input.GetMouseButtonDown(0))
        {
            StopAllCoroutines();
            pulling = false;
            gancho = Instantiate(hookPrefab, shootTransform.position, Quaternion.identity).GetComponent<Gancho>();
            gancho.Initialize(this, shootTransform);

            StartCoroutine(DestroyHookAfterLifetime());
        }
        else if (gancho != null && Input.GetMouseButtonDown(1))
        {
            DestroyHook();
        }

        if (!pulling || gancho == null) return;

        if(Vector3.Distance(transform.position, gancho.transform.position) <= stopDistance)
        {
            DestroyHook();
        }
        else
        {
            rb.AddForce((gancho.transform.position - transform.position).normalized * pullSpeed, ForceMode.VelocityChange);
        }
    }

    public void StartPull()
    {
        pulling = true;
    }

    private void DestroyHook()
    {
        if (gancho == null) return;

        pulling = false;
        Destroy(gancho.gameObject);
        gancho = null;
    }

    private IEnumerator DestroyHookAfterLifetime()
    {
        yield return new WaitForSeconds(8f);

        DestroyHook();
    }
}
