using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float walkSpeed;
    public float slowSpeed;

    public playerState state;

    private Rigidbody2D rb;

    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        if (Mathf.Abs(rb.velocity.x) > 0.05f)
        {
            state = playerState.walking;
        } else
        {
            state = playerState.idle;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * walkSpeed, rb.velocity.y);
    }
}

public enum playerState
{
    idle,
    walking
}
