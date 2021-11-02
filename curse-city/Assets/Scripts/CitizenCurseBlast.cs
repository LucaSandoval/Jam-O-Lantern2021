using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CitizenCurseBlast : MonoBehaviour
{
    private Transform player;
    private Rigidbody2D rb;

    private void Start()
    {
        //-! I usually don't like to use "find," but I thought it was safer than assigning a public variable in this case
        //   in case we generate citizens with this script (you can delete this comment once you read it)
        player = GameObject.Find("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    void OnTriggerStay2D(Collider2D col)
    {
        //-! I use this weird workaround compared to GetKeyDown because OnTriggerStay2D is called on Fixed Update so it goes stupid otherwise
        if (Input.GetKey(KeyCode.Space) && !GetComponent<CitizenController>().blownAway)
        {
            GetComponent<CitizenController>().blownAway = true;

            //generates new velocity based on position relative to player
            float blastBase = 40;
            float blastX = Mathf.Clamp((blastBase / (transform.position.x - player.transform.position.x)), -60, 60);
            float blastY = Mathf.Clamp((blastBase / Mathf.Abs(transform.position.x - player.transform.position.x)), -60, 60);
            rb.velocity = new Vector2(blastX, blastY);

            //spins citizen as they fly
            rb.constraints = RigidbodyConstraints2D.None;
            rb.AddTorque(blastX, ForceMode2D.Impulse);

            //allows citizen to fall through bounds (and then be destroyed)
            GetComponent<CapsuleCollider2D>().enabled = false;
        }
    }

    private void Update()
    {
        if(transform.position.y < -4)
        {
            Destroy(gameObject);
        }
    }
}