using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnableSprite : MonoBehaviour
{
    private SpriteRenderer MySRenderer;
    public bool Burning = false;
    [SerializeField] private Sprite BurningSprite = null;
    [SerializeField] private Sprite NotBurningSprite = null;
    [SerializeField] private double BurnTime = 60;
    [SerializeField] private double TimeTillBurned;
    [SerializeField] private float SpreadRadius = 1;
    private void Start()
    {
        TimeTillBurned = BurnTime;
        MySRenderer = gameObject.GetComponent<SpriteRenderer>();
    }
    public void SpreadFire()
    {
        if (Burning)
        {
            Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(transform.position, MySRenderer.size + new Vector2(SpreadRadius, SpreadRadius), 0f);
            collider2Ds.Foreach(i =>
            {
                if ((i.gameObject.GetComponent<BurnableSprite>() != null) && i.gameObject != gameObject)
                {
                    i.gameObject.GetComponent<BurnableSprite>().Burning = true;
                }
            });
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
            MySRenderer.sprite = BurningSprite;
        }
        else
        {
            TimeTillBurned = BurnTime;
            MySRenderer.sprite = NotBurningSprite;
        }
    }
    private void Burned()
    {
        enabled = false;
    }
}
