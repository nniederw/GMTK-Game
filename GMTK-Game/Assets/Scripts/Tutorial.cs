using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] GameObject StartExplanation = null;// put out fire
    [SerializeField] GameObject MovementExpl = null;//wasd stones
    [SerializeField] GameObject WaterExpl = null;//can pick up water on well and splash in view direction
    [SerializeField] GameObject BurningExpl = null;// burnable stuff will burn down in 30 seconds try extinglishing all fires
    [SerializeField] GameObject FireSpreadingExpl = null;//sometimes the fire will spread but you cant controll that (can you?)
    public void ActStartExplanation()
    {

    }
    public void Act()
    {

    }
    private void DeactivateAll()
    {
        StartExplanation.SetActive(false);
        MovementExpl.SetActive(false);
        WaterExpl.SetActive(false);
        BurningExpl.SetActive(false);
        FireSpreadingExpl.SetActive(false);
    }
}
