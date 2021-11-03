using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceCar : MonoBehaviour
{
    public float driveSpeed;


    //0 - Right
    //1 - Left
    public int direction;

    private SpriteRenderer ren;

    public void Start()
    {
        ren = GetComponent<SpriteRenderer>();
        Destroy(gameObject, 15);
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
