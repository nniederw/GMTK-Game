using System;
using UnityEngine;

[Serializable]
public class BurnGlowArgs : EventArgs
{
    public int Radius = 4;
    public byte Alpha = 30;
    public Color32 Color = new Color32(255, 56, 0,30);
    public BurnGlowArgs(int radius, byte alpha, Color32 color)
    {
        Radius = radius;
        Alpha = alpha;
        Color = color;
    }
}