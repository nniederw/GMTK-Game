using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    //this code is very badly written

    [SerializeField] GameManager GameManager = null;
    [SerializeField] GameObject StartExpl = null;// put out fire
    [SerializeField] GameObject MovementExpl = null;//wasd stones
    [SerializeField] GameObject WaterExpl = null;//can pick up water on well and splash in view direction
    [SerializeField] GameObject BurningExpl = null;// burnable stuff will burn down in 30 seconds try extinglishing all fires
    [SerializeField] GameObject FireSpreadingExpl = null;//sometimes the fire will spread but you cant controll that can you?
    private List<GameObject> Explanations = new List<GameObject>();
    private List<bool> ExplanationsShown = new List<bool>();
    private float timer = 0;
    private void LoadExpl(int index)
    {
        GameManager.Pause();
        DeactivateAll();
        Explanations[index].SetActive(true);
    }
    private int GetActiveExpl()
    {
        return Explanations.FindIndex(i => i.activeSelf);
    }
    public void OKButton()
    {
        int i = GetActiveExpl();
        ExplanationsShown[i] = true;
        GameManager.UnPause();
        if (i == 1) { timer = 2f; }
        if (i == 2) { timer = 4f; }
        if (i == 3) { timer = 4f; }
        Explanations[i].SetActive(false);
    }
    private void DeactivateAll()
    {
        for (int i = 0; i < Explanations.Count; i++)
        {
            Explanations[i].SetActive(false);
        }
    }
    private void Start()
    {
        Explanations.Add(StartExpl);
        Explanations.Add(MovementExpl);
        Explanations.Add(WaterExpl);
        Explanations.Add(BurningExpl);
        Explanations.Add(FireSpreadingExpl);
        Explanations.ForEach(i => ExplanationsShown.Add(false));
        LoadExpl(0);
    }
    private void Update()
    {
        timer -= Time.deltaTime;
        if (!GameManager.IsPaused && ExplanationsShown[0] && !ExplanationsShown[1])
        {
            LoadExpl(1);
        }
        if (timer <= 0 && ExplanationsShown[1] && !ExplanationsShown[2])
        {
            LoadExpl(2);
        }
        if (timer <= 0 && ExplanationsShown[2] && !ExplanationsShown[3])
        {
            LoadExpl(3);
        }
        if (timer <= 0 && ExplanationsShown[3] && !ExplanationsShown[4])
        {
            GameManager.SpreadFire();
            Invoke("LoadLastExpl", 3);
        }
    }
    private void LoadLastExpl()
    {
        LoadExpl(4);
    }
    public void GoBack()
    {
        GameManager.LoadMenu();
    }
}