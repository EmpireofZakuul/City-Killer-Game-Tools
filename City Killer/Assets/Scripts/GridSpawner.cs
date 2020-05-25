using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GridSpawner : MonoBehaviour
{
    public int theXAxisGrid = 4;
    public int theYAxisGrid = 4;
    public GameObject spawnBuildingPrefab;
    public Vector3 OriginOfTheGrid = Vector3.zero;


   //wall grid and prefabs
  //public int theXGridWall = 4;
   //public int theYGridWall = 4;
    //public GameObject spawnPrefabWall;
   // public Vector3 gridOriginWall = Vector3.zero;

    public float spaceBetweenTheBuildings = 2f;
    public bool generateOnEnableGame;
    public GameObject NavMeshSurface;


    void OnEnable()
    {
        if (generateOnEnableGame)
        {
            GeneratePlay();

        }
    }

    public void GeneratePlay()
    {
        SpawnGridCity();
        //SpawnGridWalls();
    }


    void SpawnGridCity()
    {
        for (int x = 0; x < theXAxisGrid; x++)
        {
            for (int z = 0; z < theYAxisGrid; z++)
            {
                GameObject Prefabclone = Instantiate(spawnBuildingPrefab,
                    transform.position + OriginOfTheGrid + new Vector3(spaceBetweenTheBuildings * x, 0, spaceBetweenTheBuildings * z), transform.rotation);
                Prefabclone.transform.SetParent(this.transform);
            }
        }


    }

    //void SpawnGridWalls()
   // {
       // for (int x = 0; x < theXGridWall; x++)
       // {
        // for (int z = 0; z < theYGridWall; z++)
       // {
        // GameObject clone = Instantiate(spawnPrefabWall,
        // transform.position + gridOriginWall + new Vector3( 0, 0, 0), transform.rotation);
       // clone.transform.SetParent(this.transform);


      //  }
       // }

      /* for (int i = -7; i < 8; i += 14)
        {
            for (int j = -7; j < 8; j += 1)
            {
                //GameObject clone = Instantiate(spawnPrefabWall,
        //transform.position + gridOriginWall + new Vector3(i, 0, j), transform.rotation);
               // clone.transform.SetParent(this.transform);

                Instantiate(spawnPrefabWall, new Vector3(i, 0.05f, j), Quaternion.identity);
            }
            for (int j = -6; j < 7; j += 1)
            {
               // GameObject clone = Instantiate(spawnPrefabWall,
       //  transform.position + gridOriginWall + new Vector3(j, 0, i), transform.rotation);
              //  clone.transform.SetParent(this.transform);

                Instantiate(spawnPrefabWall, new Vector3(i, 0.05f, j), Quaternion.identity);
            }
        }


    }
    */
    
    
}
