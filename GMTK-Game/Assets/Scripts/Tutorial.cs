using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] GameManager GameManager = null;
    [SerializeField] GameObject StartExpl = null;// put out fire
    [SerializeField] GameObject MovementExpl = null;//wasd stones
    [SerializeField] GameObject WaterExpl = null;//can pick up water on well and splash in view direction
    [SerializeField] GameObject BurningExpl = null;// burnable stuff will burn down in 30 seconds try extinglishing all fires
    [SerializeField] GameObject FireSpreadingExpl = null;//sometimes the fire will spread but you cant controll that (can you?)
    private List<GameObject> Explanations = new List<GameObject>();
    private void LoadExpl(int index)
    {
        GameManager.Pause();
        DeactivateAll();
        Explanations[index].SetActive(true);
    }
    public void Disable()
    {
        DeactivateAll();
        GameManager.UnPause();
    }
    private void DeactivateAll()
    {
        StartExpl.SetActive(false);
        MovementExpl.SetActive(false);
        WaterExpl.SetActive(false);
        BurningExpl.SetActive(false);
        FireSpreadingExpl.SetActive(false);
    }
    private void Start()
    {
        Explanations.Add(StartExpl);
        Explanations.Add(MovementExpl);
        Explanations.Add(WaterExpl);
        Explanations.Add(BurningExpl);
        Explanations.Add(FireSpreadingExpl);
    }
}