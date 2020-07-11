using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetWater : MonoBehaviour
{

    [SerializeField] GameObject Player;
    private List<GameObject> gObjects = new List<GameObject>();
    void Update()
    {
        gObjects.ForEach(OnCollision);
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        gObjects.Add(col.gameObject);
    }
    void OnTriggerExit2D(Collider2D col)
    {
        gObjects.Remove(col.gameObject);
    }
    void OnCollision(GameObject gameObject)
    {
        if (gameObject == Player)
        {
            if (Input.GetKeyDown("e"))
            {
                Debug.Log("e");
                Player.GetComponent<PlayerVariables>().Water = true;
            }
        }
    }
    /*
    public void OnTriggerStay2D(Collider2D collision)
    {

        Debug.Log("called");
        if (collision.gameObject == Player)
        {
            Debug.Log("gameobject found");
            if (Input.GetKey("e"))
            {
                Debug.Log("e");
                Player.GetComponent<PlayerVariables>().Water = true;
            }
        }
    }
    */
}
