using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingGeneratorNoiseInput : MonoBehaviour
{
    public int maxNumberOfPieces = 20;
    public float perlinScaleFactor = 2f;

    public int randomVariationMin = -5;
    public int randomVariationMax = 10;
    public GameObject[] baseBuildingParts;
    public GameObject[] middleBuildingParts;
    public GameObject[] topBuildingParts;

    void Start()
    {
        Build();
    }


    public void Build()
    {
        float sampledValue = PerlinNoise.instance.PerlinSteppedPosition(transform.position);

        int targetPieces = Mathf.FloorToInt(maxNumberOfPieces * (sampledValue));
        targetPieces += Random.Range(randomVariationMin, randomVariationMax);

        if (targetPieces <= 0)
        {
            return;
        }

        float heightOffset = 0;
        heightOffset += SpawnPieceLayer(baseBuildingParts, heightOffset);

        for (int i = 2; i < targetPieces; i++)
        {
            heightOffset += SpawnPieceLayer(middleBuildingParts, heightOffset);
        }

        SpawnPieceLayer(topBuildingParts, heightOffset);
    }

    float SpawnPieceLayer(GameObject[] pieceArray, float inputHeight)
    {
        Transform randomTransform = pieceArray[Random.Range(0, pieceArray.Length)].transform;
        GameObject clone = Instantiate(randomTransform.gameObject, this.transform.position + new Vector3(0, inputHeight, 0), transform.rotation) as GameObject;
        Mesh cloneMesh = clone.GetComponentInChildren<MeshFilter>().mesh;
        Bounds baseBounds = cloneMesh.bounds;
        float heightOffset = baseBounds.size.y;

        clone.transform.SetParent(this.transform);

        GeneratedObjectControl.instance.AddObject(clone);

        return heightOffset;
    }
}
