using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float MoveSpeed = 5f;
    [SerializeField] private Sprite LookDown = null;
    [SerializeField] private Sprite LookUp = null;
    [SerializeField] private Sprite LookRight = null;
    [SerializeField] private Sprite LookLeft = null;
    private Camera MainCam;
    private Rigidbody2D rb;
    private SpriteRenderer MySRenderer;
    private Vector2 MovementV2D;
    public Vector2 ViewDirection = new Vector2(0, 1); //todo implement for water splash
    Vector2 down = Vector2.down; Vector2 up = Vector2.up; Vector2 left = Vector2.left; Vector2 right = Vector2.right;
    private void Start()
    {
        MainCam = Camera.main;
        rb = gameObject.GetComponent<Rigidbody2D>();
        MySRenderer = gameObject.GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        InputMovement();
    }

    void FixedUpdate()
    {
        Movement();
        UpdateSprite();
    }
    private void InputMovement()
    {
        MovementV2D.x = Input.GetAxisRaw("Horizontal");
        MovementV2D.y = Input.GetAxisRaw("Vertical");
    }
    private void Movement()
    {
        var x = MovementV2D.x;
        var y = MovementV2D.y;
        if (x * x > y * y)
        {
            if (x > 0) { ViewDirection = right; }
            else { ViewDirection = left; }
        }
        else if (x * x < y * y)
        {
            if (y > 0) { ViewDirection = up; }
            else { ViewDirection = down; }
        }
        rb.MovePosition(rb.position + MovementV2D * MoveSpeed * Time.fixedDeltaTime);
        MainCam.transform.position = transform.position + new Vector3(0, 0, -10);
    }
    private void UpdateSprite()
    {
        if (ViewDirection == down) { MySRenderer.sprite = LookDown; }
        else if (ViewDirection == up) { MySRenderer.sprite = LookUp; }
        else if (ViewDirection == left) { MySRenderer.sprite = LookLeft; }
        else if (ViewDirection == right) { MySRenderer.sprite = LookRight; }
    }
}
