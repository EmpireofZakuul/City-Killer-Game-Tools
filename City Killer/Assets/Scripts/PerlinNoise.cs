using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PerlinNoise : MonoBehaviour
{
    public static PerlinNoise instance = null;

    public int TheXAxisOfThePerlinTextureImage;
    public int TheYAxisOfThePerlinTextureImage;
    public bool randomizeTheNoiseTexture;
    public Vector2 offsetOfThePerlinNoiseTexture;
    public float scaleOfTheNoise = 1f;
    public int TheGridSizePerlinNoiseXAxis = 4;
    public int TheGridSizePerlinNoiseYAxis = 4;

    public bool visualizeGrid = false;
    public GameObject Cube;
    public float TheHieghtOfThePerlinNoiseTexture = 5f;


    public RawImage visualizationUI;


    private Texture2D perlinTextureImage;

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

    public void GenerateOnPlay()
    {
        GenerateTextureNoise();
        if (visualizeGrid)
        {
            Grid();
        }
    }

    void GenerateTextureNoise()
    {
        if (randomizeTheNoiseTexture)
        {
            offsetOfThePerlinNoiseTexture = new Vector2(Random.Range(0, 99999), Random.Range(0, 99999));
        }

        perlinTextureImage = new Texture2D(TheXAxisOfThePerlinTextureImage, TheYAxisOfThePerlinTextureImage);

        for (int x = 0; x < TheXAxisOfThePerlinTextureImage; x++)
        {
            for (int y = 0; y < TheYAxisOfThePerlinTextureImage; y++)
            {
                perlinTextureImage.SetPixel(x, y, NoiseSample(x, y));
            }
        }

        perlinTextureImage.Apply();
        visualizationUI.texture = perlinTextureImage;
    }

    Color NoiseSample(int x, int y)
    {
        float XCoordinate = (float)x / TheXAxisOfThePerlinTextureImage * scaleOfTheNoise + offsetOfThePerlinNoiseTexture.x;
        float YCoordinate = (float)y / TheYAxisOfThePerlinTextureImage * scaleOfTheNoise + offsetOfThePerlinNoiseTexture.y;

        float sampled = Mathf.PerlinNoise(XCoordinate, YCoordinate);
        Color ColorOfThePerlin = new Color(sampled, sampled, sampled);

        return ColorOfThePerlin;
    }

    public float SampleStepped(int x, int y)
    {
        int gridStepSizeX = TheXAxisOfThePerlinTextureImage / TheGridSizePerlinNoiseXAxis;
        int gridStepSizeY = TheYAxisOfThePerlinTextureImage / TheGridSizePerlinNoiseYAxis;

        float sampledFloat = perlinTextureImage.GetPixel
                   ((Mathf.FloorToInt(x * gridStepSizeX)), (Mathf.FloorToInt(y * gridStepSizeX))).grayscale;

        return sampledFloat;
    }

    public float PerlinSteppedPosition(Vector3 worldPosition)
    {
        int SampleTheX = Mathf.FloorToInt(worldPosition.x + TheGridSizePerlinNoiseXAxis * .5f);
        int SampleTheY = Mathf.FloorToInt(worldPosition.z + TheGridSizePerlinNoiseYAxis * .5f);

        SampleTheX = SampleTheX % TheGridSizePerlinNoiseXAxis;
        SampleTheY = SampleTheY % TheGridSizePerlinNoiseYAxis;

        float sampledValue = SampleStepped(SampleTheX, SampleTheY);

        return sampledValue;
    }

    void Grid()
    {
        GameObject visualGrid = new GameObject("VisualizationParent");
        visualGrid.transform.SetParent(this.transform);

        for (int x = 0; x < TheGridSizePerlinNoiseXAxis; x++)
        {
            for (int y = 0; y < TheGridSizePerlinNoiseYAxis; y++)
            {
                GameObject clonePrefab = Instantiate(Cube,
                    new Vector3(x, SampleStepped(x, y) * TheHieghtOfThePerlinNoiseTexture, y)
                    + transform.position, transform.rotation);

                clonePrefab.transform.SetParent(visualGrid.transform);
                GeneratedObjectControl.instance.AddObject(clonePrefab);
            }
        }

        visualGrid.transform.position =
            new Vector3(-TheGridSizePerlinNoiseXAxis * .5f, -TheHieghtOfThePerlinNoiseTexture * .5f, -TheGridSizePerlinNoiseYAxis * .5f);
    }

    public void NoiseScale(Slider slider)
    {
        scaleOfTheNoise = slider.value;
    }

}

