using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    public SceneFader SceneFader;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CreditsPlayAnimation());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator CreditsPlayAnimation()
    {
        yield return new WaitForSeconds(18.0f);
        SceneFader.FadTo("Menu");
    }
}
