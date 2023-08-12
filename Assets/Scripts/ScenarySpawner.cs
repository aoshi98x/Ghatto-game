using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarySpawner : MonoBehaviour
{
    [SerializeField] Vector3 frontBound;
    [SerializeField] Vector3 backBound;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObject",0.5f,10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnObject()
    {

    }
}
