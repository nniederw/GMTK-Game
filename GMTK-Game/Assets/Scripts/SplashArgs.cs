using System;
using UnityEngine;
public class SplashArgs : EventArgs
{
    public Vector2 SplashBox;
    public Vector2 Position;
    public float Rotation;
    public SplashArgs(Vector2 box, Vector2 pos, float rot)
    {
        SplashBox = box;
        Position = pos;
        Rotation = rot;
    }
}