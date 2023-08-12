using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnableObject : MonoBehaviour
{
    public bool ableToSpawn;
    public bool despawnByTrigger;
    private Vector3 voidSpawnPosition=new Vector3(50,0,50);
    public GameObject wallDespawner;
    
    void Awake() 
    {
           
    }

    public void SpawnObject(Vector3 positionToSpawn)
    {
        gameObject.transform.position=positionToSpawn;
        ableToSpawn=false;
        gameObject.SetActive(true);

    }
    
    public void VoidSpawn()
    {
        gameObject.transform.position=voidSpawnPosition;
        gameObject.SetActive(true);
    }

    public void DespawnObject()
    {
        gameObject.SetActive(false);
        gameObject.transform.position=voidSpawnPosition;
        ableToSpawn=true;
        gameObject.GetComponent<SpawnableObject>().ableToSpawn=true;

    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject==wallDespawner)
        {
            DespawnObject();
        }
    }

}
