using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(PlayerVariables))]
public class SplashEffect : MonoBehaviour
{
    [SerializeField] private GameObject SplashSprite;
    private SpriteRenderer Sprite = null;
    private byte MaxAlpha = 127;
    private byte Alpha = 0;
    private float MaxTime = 0.5f;
    private float Time = 0f;
    private readonly Color32 WaterColor = new Color32(63, 102, 250, 127);
    void Start()
    {
        GetComponent<PlayerVariables>().OnSplash += OnSplash;
        if (SplashSprite == null) throw new System.Exception();
    }
    void Update()
    {
        Time -= UnityEngine.Time.deltaTime;
        if (Time < 0f) { Time = 0f; }
        var frac = Time / MaxTime;
        Alpha = (byte)(MaxAlpha * frac);
        if (Sprite != null)
        {
            UpdateColor();
            if (Alpha == 0)
            {
                Sprite.enabled = false;
            }
        }
        
    }
    private void OnSplash(object obj, SplashArgs args)
    {
        Time = MaxTime;
        if (Sprite == null)
        {
            var gobj = Instantiate(SplashSprite, transform);
            Sprite = gobj.GetComponent<SpriteRenderer>();
            if (Sprite == null) { throw new System.Exception(); }
        }
        Sprite.enabled = true;
        var trans = Sprite.transform;
        trans.localPosition = args.Position;
        trans.localScale = args.SplashBox;
        trans.localRotation = Quaternion.Euler(0, 0, args.Rotation);
    }
    private void UpdateColor()
    {
        var c = WaterColor;
        Sprite.color = new Color32(c.r, c.g, c.b, Alpha);
    }
}