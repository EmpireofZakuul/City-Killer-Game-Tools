using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingGeneratorNoiseInput : MonoBehaviour
{
    public int maxNumberOfPieces = 20;
    public float perlinScale = 2f;

    public int randomMin = -5;
    public int randomMax = 10;
    public GameObject[] baseBuildingParts;
    public GameObject[] middleBuildingParts;
    public GameObject[] topBuildingParts;

    void Start()
    {
        BuildCity();
    }


    public void BuildCity()
    {
        float sampledValue = PerlinNoise.instance.Perlin(transform.position);

        int Pieces = Mathf.FloorToInt(maxNumberOfPieces * (sampledValue));
        Pieces += Random.Range(randomMin, randomMax);

        if (Pieces <= 0)
        {
            return;
        }

        float heightBuildings = 0;
        heightBuildings += SpawnLayout(baseBuildingParts, heightBuildings);

        for (int i = 2; i < Pieces; i++)
        {
            heightBuildings += SpawnLayout(middleBuildingParts, heightBuildings);
        }

        SpawnLayout(topBuildingParts, heightBuildings);
    }

    float SpawnLayout(GameObject[] ArrayPieces, float inputHeight)
    {
        Transform randomTransform = ArrayPieces[Random.Range(0, ArrayPieces.Length)].transform;
        GameObject cloneSpawn = Instantiate(randomTransform.gameObject, this.transform.position + new Vector3(0, inputHeight, 0), transform.rotation) as GameObject;
        Mesh cloneMesh = cloneSpawn.GetComponentInChildren<MeshFilter>().mesh;
        Bounds baseBounds = cloneMesh.bounds;
        float OffsetHeight = baseBounds.size.y;

        cloneSpawn.transform.SetParent(this.transform);

        GeneratedObjectControl.instance.AddObject(cloneSpawn);

        return OffsetHeight;
    }
}
