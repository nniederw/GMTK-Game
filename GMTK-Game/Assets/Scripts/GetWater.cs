using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetWater : MonoBehaviour
{
    public double test;

    [SerializeField] GameObject Player;

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject == Player)
        {
            if (Input.GetKey("e"))
            {
                Player.GetComponent<PlayerVariables>().Water = true;
            }
        }
    }

}
