using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject BurnableObjs = null;
    private List<float> timers = new List<float>();
    public void SpreadFire()
    {
        BurnableObjs.GetComponentsInChildren<BurnableSprite>().Foreach(i => i.SpreadFire());
    }
    public void SpreadFire(float delay)
    {
        timers.Add(delay);
    }
    private void Update()
    {
        float deltaTime = Time.deltaTime;
        timers.ForEach(i => i -= deltaTime);
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