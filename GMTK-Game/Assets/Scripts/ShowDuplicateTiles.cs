using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowDuplicateTiles : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Collider2D[] overlap = Physics2D.OverlapBoxAll(transform.position, new Vector2(0.01f, 0.01f), 0);
        if (overlap.Length > 1)
        {
            overlap.Foreach(i =>
            {
                if (i.gameObject.name == name && i.gameObject != gameObject)
                {
                    Debug.Log("a overlap at position:" + transform.position);
                }
            });
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
