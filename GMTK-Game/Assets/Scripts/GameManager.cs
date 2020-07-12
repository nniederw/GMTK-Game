using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject BurnableObjs = null;
    [SerializeField] private GameObject FireSpreadsUI = null;
    [SerializeField] private GameObject WinUI = null;
    private List<float> timers = new List<float>();
    private float FSpreadsUITimer = 0;
    private float UITime = 1;
    private bool Won = false;
    public void SpreadFire()
    {
        FSpreadsUITimer = UITime;
        var burningObjs = new List<BurnableSprite>();
        BurnableObjs.GetComponentsInChildren<BurnableSprite>().Foreach(i => { if (i.Burning) { burningObjs.Add(i); } });
        burningObjs.ForEach(i => i.SpreadFire());
    }
    public void SpreadFire(float delay)
    {
        timers.Add(delay);
    }
    private void Update()
    {
        if (!Won)
        {
            UpdateTimer();
            CheckWinning();
            UpdateUI();
        }
    }
    private void UpdateUI()
    {
        if (FSpreadsUITimer > 0)
        {
            FireSpreadsUI.SetActive(true);
            FSpreadsUITimer -= Time.deltaTime;
        }
        else
        {
            FireSpreadsUI.SetActive(false);
        }
    }
    private void CheckWinning()
    {
        var burningObjs = new List<BurnableSprite>();
        BurnableObjs.GetComponentsInChildren<BurnableSprite>().Foreach(i => { if (i.Burning) { burningObjs.Add(i); } });
        if (!burningObjs.Any()) { Win(); }
    }
    private void Win()
    {
        double score = 100;

        var burntdown = new List<GameObject>();
        //GameObject.FindGameObjectsWithTag("BurnableSprite").Foreach(i=> {if (i.GetComponent<BurnableSprite>().bu) })



            WinUI.SetActive(true);
        Won = true;
    }
    private void UpdateTimer()
    {
        float deltaTime = Time.deltaTime;
        for (int i = 0; i < timers.Count; i++)
        {
            timers[i] -= deltaTime;
        }
        int count = timers.Count;
        for (int i = 0; i < count; i++)
        {
            int ind = count - i - 1;
            if (timers[ind] <= 0)
            {
                SpreadFire();
                timers.RemoveAt(ind);
            }
        }
    }
}