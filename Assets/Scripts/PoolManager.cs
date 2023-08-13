using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public GameObject floorPoolContainer;
    public GameObject housePoolContainer;

    public List<PoolableObject> floorPrefabs;
    public List<PoolableObject> housePrefabs;

    public int floorPrefabQuantity;
    public int housePrefabQuantity;

    public List<PoolableObject> floorList;
    public List<PoolableObject> houseList;




    void Awake()
    {
        FillPoolContainer(floorPoolContainer,floorPrefabs,floorPrefabQuantity,floorList);
        FillPoolContainer(housePoolContainer,housePrefabs,housePrefabQuantity,houseList);
    }

    // Update is called once per frame
    void Update()
    {
        
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
