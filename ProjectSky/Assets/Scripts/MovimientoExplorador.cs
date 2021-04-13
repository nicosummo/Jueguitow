using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoExplorador : MonoBehaviour
{
    public float            _velocidad = 6f;
    public float            _rotationSpeed;
    public float            _fuerzaSalto = 7f;

    public int              defaultJumpAllowed = 1;
    int                     jumpAllowed;

    bool                    isGrounded;

    public Rigidbody        rb;

    

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        
        jumpAllowed = defaultJumpAllowed;
    }

    void FixedUpdate()
    {
        ExplorerMovement();
        Jump();
    }

    void ExplorerMovement()
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

    void Jump() //doble salto
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                rb.AddForce(Vector3.up * _fuerzaSalto, ForceMode.Impulse);
                isGrounded = false;
            }
            else if (!isGrounded && jumpAllowed > 0)
            {
                rb.AddForce(Vector3.up * _fuerzaSalto, ForceMode.Impulse);
                jumpAllowed--;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
            jumpAllowed = defaultJumpAllowed;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }
}
