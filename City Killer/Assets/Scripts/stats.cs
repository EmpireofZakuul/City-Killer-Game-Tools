using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stats : MonoBehaviour
{
    public static int Money;
    public int StartMoney = 400;

    public static int Health;
    public int startHealth = 20;

    public static int Rounds;
     void Start()
    {
        Money = StartMoney;
        Health = startHealth;
        Rounds = 0;
    }
}
