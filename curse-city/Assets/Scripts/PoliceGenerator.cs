using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceGenerator : MonoBehaviour
{
    public float initialSpawnDelay; 
    public GameObject police;

    void Start()
    {
        GameObject newPolice = Instantiate(police, gameObject.transform);
        newPolice.transform.localPosition = new Vector2(-10, 0);

        StartCoroutine(PoliceSpawning());
    }

    IEnumerator PoliceSpawning()
    {
        float spawnDelay = initialSpawnDelay;

        while (true)
        {
            yield return new WaitForSeconds(spawnDelay);
            GameObject newPolice = Instantiate(police, gameObject.transform);
            newPolice.transform.localPosition = new Vector2(Random.Range(-15, 15), 0);

            spawnDelay *= 0.9f;
        }
    }
}
