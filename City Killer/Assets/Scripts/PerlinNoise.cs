using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PerlinNoise : MonoBehaviour
{
    public static PerlinNoise instance = null;

    public int perlinTextureXAxis;
    public int perlinTextureYAxis;
    public bool randomizeNoise;
    public Vector2 offsetOfThePerlin;
    public float scaleOfTheNoise = 1f;
    public int perlinGridSizeXAxis = 4;
    public int perlinGridSizeYAxis = 4;

    public bool visualizeGrid = false;
    public GameObject visualizationCube;
    public float visualizationHeightScale = 5f;
    public RawImage visualizationUI;


    private Texture2D perlinTexture;

    void Awake()
    {
       
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void Generate()
    {
        GenerateNoise();
        if (visualizeGrid)
        {
            VisualizeGrid();
        }
    }

    void GenerateNoise()
    {
        if (randomizeNoise)
        {
            offsetOfThePerlin = new Vector2(Random.Range(0, 99999), Random.Range(0, 99999));
        }

        perlinTexture = new Texture2D(perlinTextureXAxis, perlinTextureYAxis);

        for (int x = 0; x < perlinTextureXAxis; x++)
        {
            for (int y = 0; y < perlinTextureYAxis; y++)
            {
                perlinTexture.SetPixel(x, y, SampleNoise(x, y));
            }
        }

        perlinTexture.Apply();
        visualizationUI.texture = perlinTexture;
    }

    Color SampleNoise(int x, int y)
    {
        float xCoord = (float)x / perlinTextureXAxis * scaleOfTheNoise + offsetOfThePerlin.x;
        float yCoord = (float)y / perlinTextureYAxis * scaleOfTheNoise + offsetOfThePerlin.y;

        float sample = Mathf.PerlinNoise(xCoord, yCoord);
        Color perlinColor = new Color(sample, sample, sample);

        return perlinColor;
    }

    public float SampleStepped(int x, int y)
    {
        int gridStepSizeX = perlinTextureXAxis / perlinGridSizeXAxis;
        int gridStepSizeY = perlinTextureYAxis / perlinGridSizeYAxis;

        float sampledFloat = perlinTexture.GetPixel
                   ((Mathf.FloorToInt(x * gridStepSizeX)), (Mathf.FloorToInt(y * gridStepSizeX))).grayscale;

        return sampledFloat;
    }

    public float PerlinSteppedPosition(Vector3 worldPosition)
    {
        int xToSample = Mathf.FloorToInt(worldPosition.x + perlinGridSizeXAxis * .5f);
        int yToSample = Mathf.FloorToInt(worldPosition.z + perlinGridSizeYAxis * .5f);

        xToSample = xToSample % perlinGridSizeXAxis;
        yToSample = yToSample % perlinGridSizeYAxis;

        float sampledValue = SampleStepped(xToSample, yToSample);

        return sampledValue;
    }

    void VisualizeGrid()
    {
        GameObject visualizationParent = new GameObject("VisualizationParent");
        visualizationParent.transform.SetParent(this.transform);

        for (int x = 0; x < perlinGridSizeXAxis; x++)
        {
            for (int y = 0; y < perlinGridSizeYAxis; y++)
            {
                GameObject clone = Instantiate(visualizationCube,
                    new Vector3(x, SampleStepped(x, y) * visualizationHeightScale, y)
                    + transform.position, transform.rotation);

                clone.transform.SetParent(visualizationParent.transform);
                GeneratedObjectControl.instance.AddObject(clone);
            }
        }

        visualizationParent.transform.position =
            new Vector3(-perlinGridSizeXAxis * .5f, -visualizationHeightScale * .5f, -perlinGridSizeYAxis * .5f);
    }

    public void SetscaleOfTheNoiseFromSlider(Slider slider)
    {
        scaleOfTheNoise = slider.value;
    }

}

