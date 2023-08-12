using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public GameObject floorPoolContainer;
    public GameObject housePoolContainer;

    public PoolableObject floorPrefab;
    public PoolableObject housePrefab;

    public int floorListQuantity;
    public int houseListQuantity;

    public List<PoolableObject> floorList;
    public List<PoolableObject> houseList;




    void Awake()
    {
        FillPoolContainer(floorPoolContainer,floorPrefab,floorListQuantity,floorList);        
        FillPoolContainer(housePoolContainer,housePrefab,houseListQuantity,houseList);        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FillPoolContainer(GameObject poolContainer,PoolableObject prefabToPool, int quantityToPool, List<PoolableObject> poolList )
    {
        for(int i=0;i<quantityToPool;i++){

            poolList.Add(Instantiate(prefabToPool,poolContainer.transform));
            poolList[i].ableToPool=true;
        }
    }
}
