using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPExplorador : MonoBehaviour
{
    public float vida = 100;

    public Image BarraHP;

    void Update()
    {
        vida = Mathf.Clamp(vida, 0, 100);

        BarraHP.fillAmount = vida / 100;
    }
}

