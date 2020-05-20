using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    public SceneFader SceneFader;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GameLoading());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator GameLoading()
    {
        yield return new WaitForSeconds(9f);
        SceneFader.FadTo("GameLevel");
    }
}
