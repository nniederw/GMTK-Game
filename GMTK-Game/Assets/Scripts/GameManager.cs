using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject BurnableObjs = null;
    private List<float> timers = new List<float>();
    private bool Won = false;
    public void SpreadFire()
    {
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
        //todo
        Won = true;
        Debug.Log("You Win !");
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