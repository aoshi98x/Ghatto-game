using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public PoolManager poolManager;
    public GameObject mainWallDespawner;
    public GameObject floorSpawner;
    public GameObject houseSpawner;
    // Start is called before the first frame update
    void Start()
    {
        AssignWallDespawner(mainWallDespawner,poolManager.floorList);
        AssignWallDespawner(mainWallDespawner,poolManager.houseList);
        InvokeRepeating("SpawnScenaryTile",3f,5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AssignWallDespawner(GameObject wallDespawner, List<PoolableObject> poolableObjects)
    {
        foreach(PoolableObject obj in poolableObjects){
            obj.GetComponent<SpawnableObject>().wallDespawner=wallDespawner;
            obj.GetComponent<SpawnableObject>().ableToSpawn=true;
        }
    }
    void SpawnScenaryTile()
    {
        SpawnItemOnSpawner(floorSpawner,poolManager.floorList);
        SpawnItemOnSpawner(houseSpawner,poolManager.houseList);
    }
    void SpawnItemOnSpawner(GameObject spawnerObject, List<PoolableObject> poolableObjects)
    {
        foreach(PoolableObject obj in poolableObjects){
            if(obj.GetComponent<SpawnableObject>().ableToSpawn==true)
            {
                obj.GetComponent<SpawnableObject>().SpawnObject(spawnerObject.transform.position);
                break;
            }
        }
    }
}
