using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetWater : MonoBehaviour
{
    public bool Water = false;
    [SerializeField]GameObject Player;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == Player)
        {

        }
    }

}
