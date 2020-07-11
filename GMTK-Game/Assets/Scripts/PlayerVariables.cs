using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVariables : MonoBehaviour
{

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
        Debug.Log("ciao");
        //todo löscht tiles
        Water = false;
    }
    private void Burn()
    {
        if (Input.GetKeyDown("w"))
        {
            Counter ++;
            Debug.Log("de niels isch blöd");
        }
    }
}
