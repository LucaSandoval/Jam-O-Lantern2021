using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceOfficer : MonoBehaviour
{
    private Transform player;
    private Rigidbody2D rb;

    private SoundManager soundManager;

    private void Start()
    {
        player = GameObject.Find("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (Input.GetKey(KeyCode.Space)) 
        {
            player.GetComponent<PlayerController>().GetCaught();
            GetComponent<CitizenController>().state = movementState.stop;
            GetComponent<CitizenController>().timer = 1000;

            soundManager.Play("Down");
        }
    }

}
