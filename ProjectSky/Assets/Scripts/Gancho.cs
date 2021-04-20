﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gancho : MonoBehaviour
{
    [SerializeField] float hookForce = 25f;

    DisparadorGancho grapple;
    Rigidbody rb;
    LineRenderer lineRenderer;
    public void Initialize(DisparadorGancho grapple, Transform shootTransform)
    {
        transform.forward = shootTransform.forward;
        this.grapple = grapple;
        rb = GetComponent<Rigidbody>();
        lineRenderer = GetComponent<LineRenderer>();
        rb.AddForce(transform.forward * hookForce, ForceMode.Impulse);
    }

    void Update()
    {
        Vector3[] positions = new Vector3[]
        {
            transform.position, grapple.transform.position
        };

        lineRenderer.SetPositions(positions);
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((LayerMask.GetMask("Gancho") & 1 << other.gameObject.layer) > 0)
        {
            rb.useGravity = false;
            rb.isKinematic = true;

            grapple.StartPull();
        }
    }
}
