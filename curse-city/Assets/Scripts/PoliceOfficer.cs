using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceOfficer : MonoBehaviour
{
    private Transform player;
    private Rigidbody2D rb;

    private SoundManager soundManager;

    private float spawnCooldown;
    private bool onCooldown;

    private void Start()
    {
        player = GameObject.Find("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
    }

    public void Awake()
    {
        spawnCooldown = 2;
        onCooldown = true;
    }

    public void FixedUpdate()
    {
        if (spawnCooldown > 0)
        {
            spawnCooldown -= Time.deltaTime;
        } else
        {
            onCooldown = false;
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (Input.GetKey(KeyCode.Space) && onCooldown == false) 
        {
            player.GetComponent<PlayerController>().GetCaught();
            GetComponent<CitizenController>().state = movementState.stop;
            GetComponent<CitizenController>().timer = 1000;

            soundManager.Play("Down");
        }
    }

}
