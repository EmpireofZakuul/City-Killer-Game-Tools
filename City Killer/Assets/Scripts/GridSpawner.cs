using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GridSpawner : MonoBehaviour
{
    public int theXGrid = 4;
    public int theYGrid = 4;
    public GameObject spawnPrefab;
    public Vector3 gridOrigin = Vector3.zero;
    public float spaceBetweenTheBuildings = 2f;
    public bool generateOnEnable;
    public GameObject NavMeshSurface;


    void OnEnable()
    {
        if (generateOnEnable)
        {
            Generate();
            
        }
    }

    public void Generate()
    {
        SpawnGrid();
    }


    void SpawnGrid()
    {
        for (int x = 0; x < theXGrid; x++)
        {
            for (int z = 0; z < theYGrid; z++)
            {
                GameObject clone = Instantiate(spawnPrefab,
                    transform.position + gridOrigin + new Vector3(spaceBetweenTheBuildings * x, 0, spaceBetweenTheBuildings * z), transform.rotation);
                clone.transform.SetParent(this.transform);
            }
        }
    }
}
