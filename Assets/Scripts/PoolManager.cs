using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public GameObject floorPoolContainer;
    public GameObject housePoolContainer;
    public GameObject foodPoolContainer;
    public GameObject enemyPoolContainer;

    public List<PoolableObject> floorPrefabs;
    public List<PoolableObject> housePrefabs;
    public List<PoolableObject> foodPrefabs;
    public List<PoolableObject> enemyPrefabs;

    public int floorPrefabQuantity;
    public int housePrefabQuantity;
    public int foodPrefabQuantity;
    public int enemyPrefabQuantity;

    public List<PoolableObject> floorList;
    public List<PoolableObject> houseList;
    public List<PoolableObject> foodList;
    public List<PoolableObject> enemyList;




    void Awake()
    {
        FillPoolContainer(floorPoolContainer,floorPrefabs,floorPrefabQuantity,floorList);
        FillPoolContainer(housePoolContainer,housePrefabs,housePrefabQuantity,houseList);
        FillPoolContainer(foodPoolContainer, foodPrefabs, foodPrefabQuantity, foodList);
        FillPoolContainer(enemyPoolContainer, enemyPrefabs, enemyPrefabQuantity, enemyList);
    }

    void FillPoolContainer(GameObject poolContainer,List<PoolableObject> prefabsList, int quantityPerPrefab, List<PoolableObject> poolList )
    {

        foreach(PoolableObject objectToPool in prefabsList){
            for(int i=0; i<quantityPerPrefab;i++)
            {
                poolList.Add(Instantiate(objectToPool,poolContainer.transform));
                poolList[poolList.Count-1].gameObject.SetActive(false);
            }
        }
    }
}
