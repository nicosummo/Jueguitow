using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MovimientoPJ : MonoBehaviour
{
    public float            _velocidad                  = 6f;
    public float            _rotationSpeed;
    float                   _turnSmoothVelocity;
    public float            _fuerzaSalto                = 7f;
    bool                    isGrounded;

    public Rigidbody        rb;

    public LayerMask        groundLayers; //Cambiar si se cambian las layers del piso

    public CapsuleCollider  col;

    public Transform        cam;
    Vector3                 moveDir;
    public GameObject       camAndControlsSwitch;

    public Animator         animator;
    public string           movementSpeedParameterName  = "MovementSpeed";

    public WarriorAttacks   warriorAttacks;

    
   
    private void Start()
    {
        rb = GetComponent<Rigidbody>(); 
        col = GetComponent<CapsuleCollider>();
        
       
        
    }

    void Update()
    {
        if (camAndControlsSwitch.GetComponent<CamAndControlsSwitch>().war3d)
        {
            WarriorMovement();
            Jump();
            cam = Camera.main.transform;

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                warriorAttacks.Attack();
            }
            else if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                warriorAttacks.HeavyAttack();
            }
        }
        
        
        //WarriorMovement();
        //Jump();
    }

    void WarriorMovement()
    {
        //Movimiento
        float _horizontal = Input.GetAxisRaw("Horizontal");
        float _vertical = Input.GetAxisRaw("Vertical");
        Vector3 playerMovement = new Vector3(_horizontal, 0f, _vertical).normalized;

        animator.SetFloat(movementSpeedParameterName, playerMovement.magnitude);

        
        //transform.Translate(moveDir.normalized * _velocidad * Time.deltaTime, Space.World);

        //Rotacion
        if (playerMovement != Vector3.zero)
        {
            //Quaternion toRotation = Quaternion.LookRotation(playerMovement, Vector3.up);

            //transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, _rotationSpeed * Time.deltaTime);

            float _targetAngle = Mathf.Atan2(playerMovement.x, playerMovement.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float _angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, _targetAngle, ref _turnSmoothVelocity, _rotationSpeed);
            transform.rotation = Quaternion.Euler(0f, _angle, 0f);
            moveDir = Quaternion.Euler(0f, _targetAngle, 0f) * Vector3.forward;
            transform.Translate(moveDir.normalized * _velocidad * Time.deltaTime, Space.World);
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
            
        }
    }

    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
            
        }
    }

    
}
