using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnableSprite : MonoBehaviour
{
    private SpriteRenderer MySRenderer;
    private Collider2D MyCollider;
    public bool Burning = false;
    public bool BurntDown = false;
    [SerializeField] private Sprite BurningSprite = null;
    [SerializeField] private Sprite NotBurningSprite = null;
    [SerializeField] private double BurnTime = 60;
    [SerializeField] private double TimeTillBurned;
    [SerializeField] private float SpreadRadius = 1;
    private void Start()
    {
        TimeTillBurned = BurnTime;
        MySRenderer = gameObject.GetComponent<SpriteRenderer>();
        MyCollider = gameObject.GetComponent<Collider2D>();
    }
    public void SpreadFire()
    {
        if (Burning && !BurntDown)
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
        if (!BurntDown)
        {
            if (Burning)
            {
                TimeTillBurned -= Time.deltaTime;
                if (TimeTillBurned <= 0.0)
                {
                    Burning = false;
                    BurntDown = true;
                    MySRenderer.enabled = false;
                    MyCollider.enabled = false;
                }
                MySRenderer.sprite = BurningSprite;
            }
            else
            {
                TimeTillBurned = BurnTime;
                MySRenderer.sprite = NotBurningSprite;
            }
        }
    }
}
