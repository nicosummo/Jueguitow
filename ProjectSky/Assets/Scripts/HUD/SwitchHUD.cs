using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchHUD : MonoBehaviour
{
    public GameObject panelExplorador;
    public GameObject panelGuerrero;

    public GameObject managerScript;

    private void Start()
    {
        panelExplorador.SetActive(true);
        panelGuerrero.SetActive(false);
        
    }

    private void Update()
    {
        if (managerScript.GetComponent<CamAndControlsSwitch>().explorador)
        {
            panelExplorador.SetActive(true);
            panelGuerrero.SetActive(false);
        }
        else if (!managerScript.GetComponent<CamAndControlsSwitch>().explorador)
        {
            panelGuerrero.SetActive(true);
            panelExplorador.SetActive(false);
        }
    }
}
