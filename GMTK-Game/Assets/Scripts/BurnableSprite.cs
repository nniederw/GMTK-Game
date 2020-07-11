using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnableSprite : MonoBehaviour
{
    public bool Burning = false;
    [SerializeField] private double BurnTime = 60;
    [SerializeField] private double TimeTillBurned;
    [SerializeField] private float SpreadRadius = 2;
    private void Start()
    {
        TimeTillBurned = BurnTime;        
    }
    public void SpreadFire()
    {
        Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(transform.position, new Vector2(SpreadRadius, SpreadRadius), 0f);
        collider2Ds.Foreach(check);
        void check(Collider2D col)
        {
            if (col.tag == "BurnableTile")
            {
                col.gameObject.GetComponent<BurnableSprite>().Burning = true;
            }
        }
    }
    private void Update()
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
