using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GeneratedObjectControl : MonoBehaviour
{
    public static GeneratedObjectControl instance;
    public List<GameObject> generatedObjects = new List<GameObject>();

    public PerlinNoise perlinTextureGenerator;
    public GridSpawner gridSpawnerLayout;

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

    public void Start()
    {
        GenerateManager();
    }

    public void AddObject(GameObject objectToAdd)
    {
        generatedObjects.Add(objectToAdd);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void GenerateManager()
    {
        perlinTextureGenerator.GenerateOnPlay();
        gridSpawnerLayout.GeneratePlay();
    }


   
}
