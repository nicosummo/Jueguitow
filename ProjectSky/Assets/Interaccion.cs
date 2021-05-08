using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaccion : MonoBehaviour
{
    public GameObject Interactuable;
    public GameObject Reaccion;

    private void Start()
    {
        Interactuable.SetActive(true);
        Reaccion.SetActive(false);
    }

    public void PlayAccion()
    {
        Interactuable.SetActive(false);
        Reaccion.SetActive(true);
    }
}
