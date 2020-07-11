using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVariables : MonoBehaviour
{

    public bool Water = false;

    private void Update()
    {
        if (Water)
        {
            if (Input.GetKey("e"))
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
    
}
