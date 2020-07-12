using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetWater : MonoBehaviour
{
<<<<<<< HEAD
    [SerializeField] PlayerVariables playerVariables;
=======
    [SerializeField] PlayerVariables playerVariables = null;
>>>>>>> f5492d87c1902104657671461d045f38ceb5b24c
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
<<<<<<< HEAD
                Debug.Log("e");
                playerVariables.Water = true;
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
=======
                playerVariables.Water = true;
            }
        }
    }    
>>>>>>> f5492d87c1902104657671461d045f38ceb5b24c
}
