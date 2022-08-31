using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnableSprite : MonoBehaviour
{
    public static Dictionary<BurnableObject, int> BurntObjects = new Dictionary<BurnableObject, int>();
    private static HashSet<BurnableSprite> BurnableSprites = new HashSet<BurnableSprite>();
    private SpriteRenderer MySRenderer;
    private Collider2D MyCollider;
    public bool Burning
    {
        get => _Burning;
        set
        {
            if (value) { StartBurningCall(); }
            else { StopBurningCall(); }
            _Burning = value;
        }
    }
    [SerializeField] private bool _Burning = false;
    [SerializeField] private BurnableObject Type;
    public bool BurntDown = false;
    public event EventHandler<BurnGlowArgs> StartBurning;
    public event EventHandler StopBurning;
    [SerializeField] private Sprite BurningSprite = null;
    [SerializeField] private Sprite NotBurningSprite = null;
    [SerializeField] private double BurnTime = 60;
    [SerializeField] private double TimeTillBurned;
    [SerializeField] private float SpreadRadius = 1;
    [SerializeField] private BurnGlowArgs BurnGlowArgs = new BurnGlowArgs(5, 30, new Color32(255, 56, 0, 30));
    private void Start()
    {
        TimeTillBurned = BurnTime;
        MySRenderer = gameObject.GetComponent<SpriteRenderer>();
        MyCollider = gameObject.GetComponent<Collider2D>();
        Burning = Burning; //Call events
        BurnableSprites.Add(this);
    }
    private void StartBurningCall() => StartBurning?.Invoke(this, BurnGlowArgs);
    private void StopBurningCall() => StopBurning?.Invoke(this, new EventArgs());
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
                    AddBurntObject(Type);
                    //this.enabled = false;
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
    public float BurnFraction() => 1f - Convert.ToSingle(TimeTillBurned / BurnTime);
    private static void AddBurntObject(BurnableObject type)
    {
        if (BurntObjects.ContainsKey(type))
        {
            BurntObjects[type]++;
        }
        else
        {
            BurntObjects.Add(type, 1);
        }
    }
    public static bool BurningFinished()
    {
        foreach (var obj in BurnableSprites)
        {
            if (obj.Burning)
            {
                return false;
            }
        }
        return true;
    }
    private void OnDestroy()
    {
        BurnableSprites.Remove(this);
    }
}