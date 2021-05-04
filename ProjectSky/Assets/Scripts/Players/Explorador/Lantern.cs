using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lantern : MonoBehaviour
{
    public GameObject lightSource;
    public bool isOn = false;

    public void Flashlight()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!isOn)
            {
                lightSource.SetActive(true);
                isOn = true;
            }
            else if (isOn)
            {
                lightSource.SetActive(false);
                isOn = false;
            }
        }
    }
}
