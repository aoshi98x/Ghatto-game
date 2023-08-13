using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackControl : PlayerController
{
    void Start()
    {

    }

    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Food") || other.gameObject.CompareTag("Obstacle"))
        {
            //Destroy(other.gameObject);
            other.gameObject.GetComponent<SpawnableObject>().DespawnObject();
        }
    }
}
