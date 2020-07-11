﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVariables : MonoBehaviour
{
    [SerializeField] GameManager GameManager = null;
    public bool Water = false;
    public int Counter = 0;

    private void Update()
    {
        Burn();
        if (Water)
        {
            if (Input.GetKey("r"))
            {
                Splash();
            }
        }
    }
    private void Splash()
    {
        Debug.Log("Splash");
        //todo löscht tiles
        Water = false;
    }
    private void Burn()
    {
        if (Input.GetKeyDown("w"))
        {
            Counter++;
            if (Counter == 3)
            {
                GameManager.SpreadFire(1);
                Counter = 0;
            }
        }
    }
}
