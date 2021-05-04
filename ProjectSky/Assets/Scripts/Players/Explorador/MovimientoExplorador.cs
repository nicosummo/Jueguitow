using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MovimientoExplorador : MonoBehaviour
{
    public float            _velocidad = 6f;
    public float            _rotationSpeed;
    float                   _turnSmoothVelocity;
    public float            _fuerzaSalto = 7f;

    //animaciones
    public Animator         animatorExp;
    public string           movementSpeedParameterName = "MovementSpeedExp";

    public int              defaultJumpAllowed = 1;
    int                     jumpAllowed;

    bool                    isGrounded;

    private Lantern lantern;

    public Rigidbody        rb;

    public Transform        cam;

    Vector3                 moveDir;
    public GameObject       camAndControlsSwitch;

    public GameObject HUDExplorador;
    

    

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        //Cursor.lockState = CursorLockMode.Locked;
        
        jumpAllowed = defaultJumpAllowed;

        lantern = gameObject.GetComponent<Lantern>();
        
    }

    void FixedUpdate()
    {
        if (camAndControlsSwitch.GetComponent<CamAndControlsSwitch>().Exp3d && camAndControlsSwitch.GetComponent<CamAndControlsSwitch>().es3d)
        {
            ExplorerMovement();
            Jump();
            lantern.Flashlight();
        }
        
    }

    void ExplorerMovement()
    {
        //Movimiento
        float _horizontal = Input.GetAxisRaw("Horizontal");
        float _vertical = Input.GetAxisRaw("Vertical");
        Vector3 playerMovement = new Vector3(_horizontal, 0f, _vertical).normalized;
        //transform.Translate(moveDir * _velocidad * Time.deltaTime, Space.World);

        //Parametro para las animaciones
        animatorExp.SetFloat(movementSpeedParameterName, playerMovement.magnitude);

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
        else if (collision.gameObject.tag == "Ground2D") //salto en la plataforma 2D tmb
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
        else if (collision.gameObject.tag == "Ground2D") // salto en la plataforma 2D tmb
        {
            isGrounded = false;
        }
    }
}
