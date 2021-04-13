using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamAndControlsSwitch : MonoBehaviour
{
    bool                        explorador;

    public GameObject           camExplorador;
    public GameObject           camGuerrero;
    public GameObject           exploradorScript;
    public GameObject           guerreroScript;

    private void Start()
    {
        explorador = true;
        

        
    }

    void Update()
    {
        if (explorador)
        {
            camExplorador.SetActive(true);
            camGuerrero.SetActive(false);
            exploradorScript.GetComponent<MovimientoExplorador>().enabled = true;
            guerreroScript.GetComponent<MovimientoPJ>().enabled = false;
            
        }
        else if (!explorador)
        {
            camExplorador.SetActive(false);
            camGuerrero.SetActive(true);
            exploradorScript.GetComponent<MovimientoExplorador>().enabled = false;
            guerreroScript.GetComponent<MovimientoPJ>().enabled = true;
        }

        Switch();
        
    }

    void Switch()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            explorador = !explorador;
            
        }
    }
}
