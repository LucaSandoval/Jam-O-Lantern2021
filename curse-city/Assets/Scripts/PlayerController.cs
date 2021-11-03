using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public float walkSpeed;
    public float slowSpeed;

    public playerState state;

    private Rigidbody2D rb;

    public float swearAmmount;
    private float swearBarMax = 100;

    public Slider swearSlider;

    private float ammountToAdd;

    public static bool gameLost;

    public GameObject gameOverText;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        swearSlider.maxValue = swearBarMax;
        swearAmmount = swearBarMax / 2;
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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ammountToAdd += 20;
        }

        swearSlider.value = swearAmmount;
    }

    private void FixedUpdate()
    {
        if (gameLost == false)
        {
            rb.velocity = new Vector2(Input.GetAxis("Horizontal") * walkSpeed, rb.velocity.y);


            if (swearAmmount > 0)
            {
                swearAmmount -= Time.deltaTime * 5;
            }

            if (ammountToAdd > 0)
            {
                ammountToAdd -= Time.deltaTime * 100;
                swearAmmount += Time.deltaTime * 100;
            }
        } 
    }

    public void GetCaught()
    {
        gameLost = true;
        gameOverText.GetComponent<Text>().text = "CAUGHT FOR SWEARING";
        gameOverText.SetActive(true);
    }
}

public enum playerState
{
    idle,
    walking
}
