using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetWater : MonoBehaviour
{

    [SerializeField] GameObject Player;

    private void OnCollisionStay(Collision collision)
    {   Debug.Log "hallo";
        if (collision.gameObject == Player)
        {
            if (Input.GetKey("e"))
            {
                Player.GetComponent<PlayerVariables>().Water = true;
            }
        }
    }

}
