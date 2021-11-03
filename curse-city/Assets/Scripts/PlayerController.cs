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
    public GameObject swearEffect;

    private SoundManager soundManager;
    public string[] swears;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();

        swearSlider.maxValue = swearBarMax;
        swearAmmount = swearBarMax / 2;

        soundManager.Play("Theme");
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

        if (Input.GetKeyDown(KeyCode.Space) && gameLost == false)
        {
            ammountToAdd += 20;

            StartCoroutine(SpawnSwearEffect());

            soundManager.Play(swears[Random.Range(0, swears.Length)]);
        }

        swearSlider.value = swearAmmount;
    }

    public IEnumerator SpawnSwearEffect()
    {
        GameObject newExplosion = swearEffect;

        GameObject spawnedExplosion = Instantiate(newExplosion);
        spawnedExplosion.transform.position = transform.position;

        yield return new WaitForSeconds(0.1f);

        spawnedExplosion = Instantiate(newExplosion);
        spawnedExplosion.transform.position = transform.position;

        yield return new WaitForSeconds(0.1f);

        spawnedExplosion = Instantiate(newExplosion);
        spawnedExplosion.transform.position = transform.position;

    }

    private void FixedUpdate()
    {
        if (gameLost == false)
        {
            rb.velocity = new Vector2(Input.GetAxis("Horizontal") * walkSpeed, rb.velocity.y);


            if (swearAmmount > 0)
            {
                swearAmmount -= Time.deltaTime * 15;
            }

            if (ammountToAdd > 0)
            {
                ammountToAdd -= Time.deltaTime * 100;
                swearAmmount += Time.deltaTime * 100;
            }

            if (swearAmmount > swearBarMax)
            {
                DieFromSwearing();
            } else if (swearAmmount < 1)
            {
                DieFromNotSwearing();
            }
        } else
        {
            rb.velocity = Vector2.zero;
        }
    }

    public void GetCaught()
    {
        soundManager.Pause("Theme");
        gameLost = true;
        gameOverText.GetComponent<Text>().text = "CAUGHT FOR SWEARING";
        gameOverText.SetActive(true);
    }

    public void DieFromSwearing()
    {
        // there has to be a better name for this
        soundManager.Pause("Theme");
        gameLost = true;
        gameOverText.GetComponent<Text>().text = "YOU DIED FROM THE EXCITEMENT OF SWEARING";
        gameOverText.SetActive(true);
    }

    public void DieFromNotSwearing()
    {
        soundManager.Pause("Theme");
        gameLost = true;
        gameOverText.GetComponent<Text>().text = "YOU DIED FROM A LACK OF SWEARING";
        gameOverText.SetActive(true);
    }
}

public enum playerState
{
    idle,
    walking,
}
