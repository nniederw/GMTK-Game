using System;
using UnityEngine;
[RequireComponent(typeof(BurnableSprite))]
public class BurnGlowEffect : MonoBehaviour
{
    [SerializeField] private GameObject FadedCirclePrefab;
    private SpriteRenderer FadedCircle;
    private void Start()
    {
        var bs = GetComponent<BurnableSprite>();
        bs.StartBurning += StartBurning;
        bs.StopBurning += StopBurning;
    }
    private void StartBurning(object obj, BurnGlowArgs args)
    {
        if (FadedCircle == null)
        {
            var go = Instantiate(FadedCirclePrefab, transform);
            go.transform.localScale = new Vector3(args.Radius, args.Radius);
            FadedCircle = go.GetComponent<SpriteRenderer>();
        }
        var c = args.Color;
        FadedCircle.color = new Color32(c.r, c.g, c.b, args.Alpha);
        FadedCircle.gameObject.SetActive(true);
    }
    private void StopBurning(object obj, EventArgs args)
    {
        if (FadedCircle != null) { FadedCircle.gameObject.SetActive(false); }
    }
}