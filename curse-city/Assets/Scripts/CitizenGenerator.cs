using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CitizenGenerator : MonoBehaviour
{
    public int startingCitizenCount;
    public GameObject citizen;

    void Start()
    {
        float XIncrement = 30 / (float) (startingCitizenCount + 1);

        //spreads starting citizens out evenly
        for (int i = 1; i < (startingCitizenCount + 1); i++)
        {
            GameObject newCitizen = Instantiate(citizen, gameObject.transform);
            float newX = (i * XIncrement) - 15;
            newCitizen.transform.localPosition = new Vector2(newX, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
