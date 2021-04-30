using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapple : MonoBehaviour
{
    [SerializeField] float pullSpeed = 0.5f;
    [SerializeField] float stopDistance = 4f;
    [SerializeField] GameObject hookPrefab;
    [SerializeField] Transform shootTransform;

    Hook hook;
    bool pulling;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        pulling = false;
    }

    
    void Update()
    {
        if(hook == null && Input.GetMouseButtonDown(0))
        {
            StopAllCoroutines();
            pulling = false;
            hook = Instantiate(hookPrefab, shootTransform.position, Quaternion.identity).GetComponent<Hook>();
            hook.Initialize(this, shootTransform);
            StartCoroutine(DestroyHookAfterLifeTime());
        }
        else if(hook != null && Input.GetMouseButtonDown(1))
        {
            DestroyHook();
        }

        if (!pulling || hook == null) return;

        if(Vector3.Distance(transform.position, hook.transform.position)<= stopDistance)
        {
            DestroyHook();
        }
        else
        {
            rb.AddForce((hook.transform.position - transform.position).normalized * pullSpeed, ForceMode.VelocityChange);
        }
    }

    public void StartPull()
    {
        pulling = true;
    }

    private void DestroyHook()
    {
        if (hook == null) return;

        pulling = false;
        Destroy(hook.gameObject);
        hook = null;
    }

    private IEnumerator DestroyHookAfterLifeTime()
    {
        yield return new WaitForSeconds(8f);

        DestroyHook();
    }
}
