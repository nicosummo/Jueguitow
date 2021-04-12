using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MovimientoPJ : MonoBehaviour
{
    public float _velocidad = 6f;
    public float _rotationSpeed;
    public float _fuerzaSalto = 7f;

    public Rigidbody rb;

    public LayerMask groundLayers; //Cambiar si se cambian las layers del piso

    public CapsuleCollider col;

    private void Start()
    {
        rb = GetComponent<Rigidbody>(); 
        col = GetComponent<CapsuleCollider>();
    }

    void Update()
    {
        WarriorMovement();
        Jump();
    }

    void WarriorMovement()
    {
        //Movimiento
        float _horizontal = Input.GetAxisRaw("Horizontal");
        float _vertical = Input.GetAxisRaw("Vertical");
        Vector3 playerMovement = new Vector3(_horizontal, 0f, _vertical);
        transform.Translate(playerMovement * _velocidad * Time.deltaTime, Space.World);

        //Rotacion
        if (playerMovement != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(playerMovement, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, _rotationSpeed * Time.deltaTime);
        }
    }

    void Jump()
    {
        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * _fuerzaSalto, ForceMode.Impulse);
        }
    }

    private bool IsGrounded()
    {
        return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x, col.bounds.min.y, col.bounds.center.z), col.radius * .9f, groundLayers);
    }
}
