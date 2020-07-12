using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVariables : MonoBehaviour
{
    [SerializeField] GameManager GameManager = null;
    [SerializeField] Vector2 SplashBox = Vector2.zero;
    private PlayerMovement PlayerMovement;
    public bool Water = false;
    [SerializeField] private int Counter = 0;
    [SerializeField] private int MaxCounter = 30;
    private void Start()
    {
        PlayerMovement = gameObject.GetComponent<PlayerMovement>();
    }
    private void Update()
    {
        Burn();
        if (Water)
        {
            if (Input.GetKeyDown("r"))
            {
                Splash();
            }
        }
    }
    private void Splash()
    {
        Vector2 pos = new Vector2(transform.position.x, transform.position.y) + PlayerMovement.ViewDirection * transform.localScale * 1f / 2f + PlayerMovement.ViewDirection * SplashBox.y * 1f / 2f; //It just works
        float rot = Vector2.Angle(new Vector2(0, 1), PlayerMovement.ViewDirection);
        Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(pos, SplashBox, rot);
        collider2Ds.Foreach(i =>
        {
            if ((i.gameObject.GetComponent<BurnableSprite>() != null))
            {
                i.gameObject.GetComponent<BurnableSprite>().Burning = false;
            }
        });
        Water = false;
    }
    private void Burn()
    {
        if (Input.GetKeyDown("w"))
        { Counter += 10; }
        if (Input.GetKeyDown("d"))
        { Counter += 4; }
        if (Input.GetKeyDown("s"))
        { Counter += 2; }
        if (Input.GetKeyDown("a"))
        { Counter += 1; }
        if (Counter >= MaxCounter)
        {
            GameManager.SpreadFire(1);
            Counter -= MaxCounter;
        }
    }
}