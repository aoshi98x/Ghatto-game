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
    private GameObject lastHouseSpawned;

    private float timeRunning=0;
    private float timeToSpawn;
    // Start is called before the first frame update
    void Start()
    {
        AssignWallDespawner(mainWallDespawner,poolManager.floorList);
        AssignWallDespawner(mainWallDespawner,poolManager.houseList);
        timeToSpawn = 10f;
    	SetFirstScenario();
    }
	void Update()
	{
        timeRunning+= Time.deltaTime;
        if(timeRunning >= timeToSpawn) 
        {
            SpawnScenaryTileFunc();
            timeRunning=0;

		}
	}
	void AssignWallDespawner(GameObject wallDespawner, List<PoolableObject> poolableObjects)
    {
        foreach (PoolableObject obj in poolableObjects)
        {
            obj.GetComponent<SpawnableObject>().wallDespawner = wallDespawner;
            obj.GetComponent<SpawnableObject>().ableToSpawn = true;
        }
    }

	IEnumerator SpawnScenaryTile()
    {
        SpawnItemOnSpawner(floorSpawner,poolManager.floorList);
        SpawnItemOnSpawner(houseSpawner,poolManager.houseList);

        yield return null;
    }
    void SpawnScenaryTileFunc()
    {
        SpawnItemOnSpawner(floorSpawner,poolManager.floorList);
        lastHouseSpawned= SpawnItemOnSpawner(houseSpawner,poolManager.houseList).gameObject;
    }

    void SetFirstScenario()
    {
        PoolableObject spawnedHouse=null;
        PoolableObject spawnedStreet = null;
        for (int i = -1; i <= 2; i++)
        {
			spawnedStreet=SpawnItemOnSpawner(floorSpawner, poolManager.floorList);
			spawnedHouse=SpawnItemOnSpawner(houseSpawner, poolManager.houseList);

            spawnedStreet.transform.position=new Vector3 (i*20f, spawnedStreet.transform.position.y, spawnedStreet.transform.position.z);
			spawnedHouse.transform.position= new Vector3(i*20f,spawnedHouse.transform.position.y,spawnedHouse.transform.position.z);
		}
        lastHouseSpawned = spawnedHouse.gameObject;
    }

    PoolableObject SpawnItemOnSpawner(GameObject spawnerObject, List<PoolableObject> poolableObjects)
    {
        ShuffleList(poolableObjects);
        foreach(PoolableObject obj in poolableObjects){
            if(obj.GetComponent<SpawnableObject>().ableToSpawn==true)
            {
                obj.GetComponent<SpawnableObject>().SpawnObject(spawnerObject.transform.position);
				return obj;                
            }

        }
        return null;
    }

    void ShuffleList(List<PoolableObject> listToShuffle) {
		PoolableObject tempObject;
		for (int i = 0; i < listToShuffle.Count; i++)
		{
			int randomIndex = Random.Range(0, listToShuffle.Count);
			tempObject = listToShuffle[randomIndex];
			listToShuffle.RemoveAt(randomIndex);
			listToShuffle.Add(tempObject);
		}
	}
}
