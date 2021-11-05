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

    public void Start()
    {
        Destroy(gameObject, 15);

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
