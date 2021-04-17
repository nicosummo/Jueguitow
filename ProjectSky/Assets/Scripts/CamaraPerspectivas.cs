using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraPerspectivas : MonoBehaviour
{
    public bool es3d;

    private void Start()
    {
        es3d = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "TriggerSideScroller")
        {
            es3d = false;
        }
        else if (other.gameObject.tag == "Trigger3dPerson")
        {
            es3d = true;
        }
    }


}
