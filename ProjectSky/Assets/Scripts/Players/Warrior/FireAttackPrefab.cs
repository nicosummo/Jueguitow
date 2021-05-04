using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAttackPrefab : MonoBehaviour
{
    public float _speed = 1f;
    float _duracion = 3f;

    void Update()
    {
        this.transform.Translate(Vector3.forward * _speed * Time.deltaTime);
        _duracion -= Time.deltaTime;
        if (_duracion <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
}
