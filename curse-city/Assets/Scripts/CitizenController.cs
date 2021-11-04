using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CitizenController : MonoBehaviour
{

    public bool cop;

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
    [HideInInspector]
    public float timer;

    public bool blownAway;

    public GameObject niceMessage;

    private float niceMessagetimer;

    public string[] niceMessages;

    private Canvas mainCanv;

    private GameObject currentNiceMessage;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mainCanv = GameObject.Find("Canvas").GetComponent<Canvas>();

        timer = moveStateTimer;
        
        state = movementState.walk;
        moveDir = getRandomDir();

        niceMessagetimer = Random.Range(3, 12);
    }

    public void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        } else
        {
            if (PlayerController.gameLost == false)
            {
                PickNewState();
            }
        }

        if (cop == false)
        {
            if (niceMessagetimer > 0)
            {
                niceMessagetimer -= Time.deltaTime;
            }
            else if (blownAway == false && PlayerController.gameLost == false)
            {
                SayNiceMessage();
                niceMessagetimer = Random.Range(3, 12);
            }
        }

        if (PlayerController.gameLost == true && cop == false)
        {
            state = movementState.flee;
        }

        if (currentNiceMessage != null)
        {
            currentNiceMessage.transform.position = Camera.main.WorldToScreenPoint(new Vector3(transform.position.x, transform.position.y + 2, 0));
        }
    }

    public void SayNiceMessage()
    {
        GameObject newMessage = niceMessage;
        GameObject spawnedMessage = Instantiate(newMessage);

        spawnedMessage.transform.SetParent(mainCanv.transform);
        spawnedMessage.transform.GetChild(0).GetComponent<Text>().text = niceMessages[Random.Range(0, niceMessages.Length)];

        currentNiceMessage = spawnedMessage;

        //spawnedMessage.transform.position = Camera.main.WorldToScreenPoint(new Vector3(transform.position.x, transform.position.y + 2, 0));
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
                case movementState.flee:
                    movementSpeed = 10;
                    rb.velocity = new Vector2(movementSpeed * moveDir, rb.velocity.y);
                    break;
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Wall" && state != movementState.flee)
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
    stop,
    flee
}
