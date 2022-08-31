using System;
using UnityEngine;
[RequireComponent(typeof(BurnableSprite))]
public class BurnParticleEffect : MonoBehaviour
{
    FireParticles[] FireParticles;
    private void Awake()
    {
        BurnableSprite bs = GetComponent<BurnableSprite>();
        var objs = GetComponentsInChildren<FireParticles>();
        foreach (var obj in objs)
        {
            obj.PartBurned = bs.BurnFraction;
            bs.StartBurning += obj.StartBurning;
            bs.StopBurning += obj.StopBurning;
        }
        FireParticles = objs;
    }
}