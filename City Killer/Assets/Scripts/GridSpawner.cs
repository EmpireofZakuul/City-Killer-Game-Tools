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
    //wall grid and prefabs
    public int theXGridWall = 4;
    public int theYGridWall = 4;
    public GameObject spawnPrefabWall;
    public Vector3 gridOriginWall = Vector3.zero;

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
        //SpawnGridWalls();
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

    /*void SpawnGridWalls()
    {
        for (int x = 0; x < theXGridWall; x++)
        {
            for (int z = 0; z < theYGridWall; z++)
            {
                GameObject clone = Instantiate(spawnPrefabWall,
                    transform.position + gridOriginWall + new Vector3( 0, 0, 0), transform.rotation);
                clone.transform.SetParent(this.transform);
            }
        }


    }
    */




}
