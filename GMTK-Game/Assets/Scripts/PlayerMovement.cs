using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float MoveSpeed = 5f;
    private Camera MainCam;
    private Rigidbody2D rb;
    private Vector2 Movement;
    public Vector2 ViewDirection = new Vector2(0, 1); //todo implement for water splash
    private void Start()
    {
        MainCam = Camera.main;
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    void Update()
    {//Input
        Movement.x = Input.GetAxisRaw("Horizontal");
        Movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {//Movement
        rb.MovePosition(rb.position + Movement * MoveSpeed * Time.fixedDeltaTime);
        MainCam.transform.position = transform.position + new Vector3(0, 0, -10);
    }

}
