using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceCar : MonoBehaviour
{
    public float driveSpeed;


    //0 - Right
    //1 - Left
    public int direction;

    public SpriteRenderer ren;
    private SoundManager soundManager;

    public AudioSource source;

    public void Start()
    {
        //soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
        Destroy(gameObject, 15);

        //soundManager.Play("Siren");
        //source.Play();

        if (direction == 0)
        {
            ren.flipX = false;
        } else
        {
            ren.flipX = true;
        }
    }

    public void FixedUpdate()
    {
        if (direction == 0)
        {
            transform.position += new Vector3(driveSpeed, 0, 0);
        } else
        {
            transform.position += new Vector3(-driveSpeed, 0, 0);
        }
    }
}
