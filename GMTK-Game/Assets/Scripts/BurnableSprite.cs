using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnableSprite : MonoBehaviour
{
    public bool Burning = false;
    [SerializeField] private double BurnTime = 60;
    [SerializeField] private double TimeTillBurned;

    void Start()
    {
        TimeTillBurned = BurnTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (Burning)
        {
            TimeTillBurned -= Time.deltaTime;
            if (TimeTillBurned <= 0.0)
            {
                Burned();
            }
        }
        else
        {
            TimeTillBurned = BurnTime;
        }
    }
    private void Burned()
    {
        enabled = false;
    }
}
