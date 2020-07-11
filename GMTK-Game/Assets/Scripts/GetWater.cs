using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetWater : MonoBehaviour
{
    [SerializeField] PlayerVariables playerVariables = null;
    private List<GameObject> gObjects = new List<GameObject>();
    void Update()
    {
        gObjects.ForEach(OnStay);
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        gObjects.Add(col.gameObject);
    }
    void OnTriggerExit2D(Collider2D col)
    {
        gObjects.Remove(col.gameObject);
    }
    void OnStay(GameObject gameObject)
    {
        if (gameObject.tag == "Player")
        {
            if (Input.GetKeyDown("e"))
            {
                Debug.Log("e");
                playerVariables.Water = true;
            }
        }
    }    
}
