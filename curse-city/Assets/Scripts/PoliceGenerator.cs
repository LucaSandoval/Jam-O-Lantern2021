using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceGenerator : MonoBehaviour
{
    public float initialSpawnDelay; 
    public GameObject police;

    public GameObject policeCar;
    private SoundManager soundManager;

    // 0 - Top lane
    // 1 - Bottom lane
    public Vector2[] spawnPos;

    void Start()
    {
        GameObject newPolice = Instantiate(police, gameObject.transform);
        newPolice.transform.localPosition = new Vector2(-10, 0);

        soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();

        StartCoroutine(PoliceSpawning());
    }

    IEnumerator PoliceSpawning()
    {
        float spawnDelay = initialSpawnDelay;

        while (true)
        {
            yield return new WaitForSeconds(spawnDelay);
            GameObject newPolice = Instantiate(police, gameObject.transform);
            newPolice.transform.localPosition = new Vector2(Random.Range(-25, 25), 0);

            GameObject newCar = Instantiate(policeCar);

            int dice = Random.Range(0, 2);
            if (dice == 0)
            {
                newCar.transform.position = new Vector3(spawnPos[0].x, spawnPos[0].y, 0);
                newCar.GetComponent<PoliceCar>().direction = 0;
                newCar.GetComponent<PoliceCar>().ren.sortingOrder = 9;
            } else
            {
                newCar.transform.position = new Vector3(spawnPos[1].x, spawnPos[1].y, 0);
                newCar.GetComponent<PoliceCar>().direction = 1;
                newCar.GetComponent<PoliceCar>().ren.sortingOrder = 10;
            }


            if (spawnDelay > 3)
            {
                spawnDelay *= 0.9f;
            }
        }
    }
}
