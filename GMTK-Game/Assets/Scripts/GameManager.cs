using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject objs;
    public void SpreadFire()
    {
        var s = objs.name;
        objs.GetComponentsInChildren<BurnableSprite>().Foreach(i=>SpreadFire());
        //todo 
        Debug.Log("Spread Fire");
    }
}
