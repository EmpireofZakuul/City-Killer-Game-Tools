using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerSwitchAnimation : MonoBehaviour
{
   //  public Transform Player;
    public Camera FirstPersonCam, ThirdPersonCam;
    //public KeyCode TKey;
    public bool camSwitch = false;
    public bool Camera = true;


    public void Start()
    {
        //camSwitch = !camSwitch;
        //FirstPersonCam.gameObject.SetActive(!camSwitch);
        //ThirdPersonCam.gameObject.SetActive(camSwitch);
        FirstPersonCam.enabled = true;
        ThirdPersonCam.enabled = false;
        StartCoroutine(SwitchCamera());
    }
    public IEnumerator SwitchCamera()
    {
        camSwitch = !camSwitch;
        yield return new WaitForSeconds(6.0f);
        FirstPersonCam.enabled = false;
        ThirdPersonCam.enabled = true;
    }
    void Update()
    {
        //if (Input.GetKeyDown(TKey))
        //{
            //camSwitch = !camSwitch;
           // FirstPersonCam.gameObject.SetActive(camSwitch);
            //ThirdPersonCam.gameObject.SetActive(!camSwitch);
        //}
    }
}

