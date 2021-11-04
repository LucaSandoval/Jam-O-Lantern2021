using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CitizenGenerator : MonoBehaviour
{
    public int startingCitizenCount;
    public float spawnDelay;
    public GameObject citizen;

    void Start()
    {
        float XIncrement = 50 / (float) (startingCitizenCount + 1);

        //spreads starting citizens out evenly
        for (int i = 1; i < (startingCitizenCount + 1); i++)
        {
            GameObject newCitizen = Instantiate(citizen, gameObject.transform);
            float newX = (i * XIncrement) - 25;
            newCitizen.transform.localPosition = new Vector2(newX, 0);
        }

        StartCoroutine(CitizenSpawning());
    }

    IEnumerator CitizenSpawning()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnDelay);

            if (spawnDelay > 0.2f)
            {
                spawnDelay = spawnDelay * 0.995f;
            }

            if(transform.childCount < startingCitizenCount)
            {
                GameObject newCitizen = Instantiate(citizen, gameObject.transform);
                newCitizen.transform.localPosition = new Vector2(Random.Range(-25, 25), 0);
            }
        }
    }
}
