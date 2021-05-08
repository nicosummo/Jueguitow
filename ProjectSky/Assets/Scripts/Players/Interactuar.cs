using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactuar : MonoBehaviour
{
    public GameObject Interactuable;
    public GameObject Reaccion;
    private void Start()
    {
        Interactuable.SetActive(true);
        Reaccion.SetActive(false);
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.T) && other.gameObject.CompareTag("Player"))
        {
            PlayAccion();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.T) && other.gameObject.CompareTag("Player"))
        {
            PlayAccion();
        }
    }

    public void PlayAccion()
    {
        Interactuable.SetActive(false);
        Reaccion.SetActive(true);
    }
}
