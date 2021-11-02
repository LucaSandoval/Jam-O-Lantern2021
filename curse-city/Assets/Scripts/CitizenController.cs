using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CitizenController : MonoBehaviour
{
    public float movementSpeed;
    private Rigidbody2D rb;

    //Current state of citizen movement
    public movementState state;

    // 1 - Right
    // -1 - Left
    public float moveDir;

    private bool hit;
    //How long before the citizen changes direction/stops
    public float moveStateTimer;

    //actuall tracking timer for internal affairs
    private float timer;

    public bool blownAway;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        timer = moveStateTimer;
        
        state = movementState.walk;
        moveDir = getRandomDir();
    }

    public void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        } else
        {
            
            PickNewState();
        }
    }

    public void PickNewState()
    {
        int dice = Random.Range(0, 100);

        switch (state)
        {
            case movementState.walk:
                
                if (dice > 30)
                {
                    timer = moveStateTimer + Random.Range(-1, 3);
                    state = movementState.walk;
                    moveDir = getRandomDir();

                } else
                {
                    timer = moveStateTimer + Random.Range(-1, -2);
                    state = movementState.stop;
                }

                break;
            case movementState.stop:

                timer = moveStateTimer + Random.Range(-1, 3);
                state = movementState.walk;
                moveDir = getRandomDir();

                break;
        }
    }

    public float getRandomDir()
    {
        int dice = Random.Range(0, 2);

        if (dice == 0)
        {
            return 1;
        } else
        {
            return -1;
        }
    }

    void FixedUpdate()
    {
        //Code to make them fly away funny will probably go here
        if (blownAway == false)
        {
            switch (state)
            {
                case movementState.walk:
                    rb.velocity = new Vector2(movementSpeed * moveDir, rb.velocity.y);
                    break;
                case movementState.stop:
                    rb.velocity = new Vector2(0, 0);
                    break;
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Wall")
        {
            timer = moveStateTimer + Random.Range(-1, 3);
            state = movementState.walk;
            moveDir = moveDir * -1;
        }
    }

}

public enum movementState
{
    walk,
    stop
}
