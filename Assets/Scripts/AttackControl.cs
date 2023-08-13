using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackControl : PlayerController
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other != null)
        { 
            Destroy(other.gameObject);
        }
    }
}
