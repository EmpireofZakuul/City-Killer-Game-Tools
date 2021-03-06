﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwap : MonoBehaviour
{
    public GameObject cameraOne;
    public GameObject cameraTwo;

    AudioListener cameraOneAudioLis;
    AudioListener cameraTwoAudioLis;

    // Use this for initialization
    void Start()
    {
       // cameraOne.SetActive(true);
        //Get Camera Listeners
        cameraOneAudioLis = cameraOne.GetComponent<AudioListener>();
        cameraTwoAudioLis = cameraTwo.GetComponent<AudioListener>();

        //Camera Position Set
        cameraPositionChange(PlayerPrefs.GetInt("CameraPosition"));

        StartCoroutine(SwitchCamera());
    }

    // Update is called once per frame
    void Update()
    {
        //Change Camera Keyboard
        
    }

    //UI JoyStick Method
    public void cameraPositonM()
    {
        cameraChangeCounter();
    }

    //Change Camera Keyboard
    public IEnumerator SwitchCamera()
    {
        yield return new WaitForSeconds(6.0f);
        cameraChangeCounter();
        
    }

    //Camera Counter
    void cameraChangeCounter()
    {
        int cameraPositionCounter = PlayerPrefs.GetInt("CameraPosition");
        cameraPositionCounter++;
        cameraPositionChange(cameraPositionCounter);
    }

    //Camera change Logic
    void cameraPositionChange(int camPosition)
    {
        if (camPosition > 1)
        {
            camPosition = 0;
        }

        //Set camera position database
        PlayerPrefs.SetInt("CameraPosition", camPosition);

        //Set camera position 1
        if (camPosition == 0)
        {
            cameraOne.SetActive(true);
            cameraOneAudioLis.enabled = true;

            cameraTwoAudioLis.enabled = false;
            cameraTwo.SetActive(false);
        }

        //Set camera position 2
        if (camPosition == 1)
        {
            cameraTwo.SetActive(true);
            cameraTwoAudioLis.enabled = true;

            cameraOneAudioLis.enabled = false;
            cameraOne.SetActive(false);
        }

    }
}

