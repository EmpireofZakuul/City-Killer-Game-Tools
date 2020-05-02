using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseManager : MonoBehaviour
{
    #region Singleton

    public static BaseManager instance;

    void Awake()
    {
        instance = this;
    }
    #endregion

    public GameObject Base;
}
