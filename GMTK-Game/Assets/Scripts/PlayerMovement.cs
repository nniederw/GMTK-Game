﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float MoveSpeed = 5f;
    public Rigidbody2D rb;
    Vector2 movement;

    void Update()
    {//Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {//Movement
        rb.MovePosition(rb.position + movement * MoveSpeed * Time.fixedDeltaTime);
    }

}
