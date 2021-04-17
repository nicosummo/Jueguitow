using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamAndControlsSwitch : MonoBehaviour
{
    bool                        explorador;

    public GameObject           camExplorador;
    public GameObject           camGuerrero;
    public GameObject           camSideScroller;

    public GameObject           exploradorScript;
    public GameObject           guerreroScript;
    public bool                 Exp3d;
    public bool                 war3d;

    public Transform            transformExplorador;
    public Transform            transformGuerrero;

    public GameObject           es3d;

    public CinemachineVirtualCamera vcam;
    
    private void Start()
    {
        explorador = true;
        
    }

    void Update()
    {
        if (explorador)
        {
            if (es3d.GetComponent<CamaraPerspectivas>().es3d)
            {
                camExplorador.SetActive(true);
                camGuerrero.SetActive(false);
            }
            else if (!es3d.GetComponent<CamaraPerspectivas>().es3d)
            {
                camExplorador.SetActive(false);
                camGuerrero.SetActive(false);
                camSideScroller.SetActive(true);
                
                vcam.LookAt = transformExplorador;
                vcam.Follow = transformExplorador;

            }
            
            //exploradorScript.GetComponent<MovimientoExplorador>().enabled = true;
            //guerreroScript.GetComponent<MovimientoPJ>().enabled = false;
            Exp3d = true;
            war3d = false;

            
        }
        else if (!explorador)
        {
            if (es3d.GetComponent<CamaraPerspectivas>().es3d)
            {
                camExplorador.SetActive(false);
                camGuerrero.SetActive(true);
            }
            else if (!es3d.GetComponent<CamaraPerspectivas>().es3d)
            {
                camExplorador.SetActive(false);
                camGuerrero.SetActive(false);
                camSideScroller.SetActive(true);
                
                vcam.LookAt = transformGuerrero;
                vcam.Follow = transformGuerrero;

            }
            
            //exploradorScript.GetComponent<MovimientoExplorador>().enabled = false;
            //guerreroScript.GetComponent<MovimientoPJ>().enabled = true;
            war3d = true;
            Exp3d = false;
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
