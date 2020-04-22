using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   

    public static int Health;
    public int startHealth = 20;

    //public static int Rounds;
    void Start()
    {
     
        Health = startHealth;
       // Rounds = 0;
    }
}
