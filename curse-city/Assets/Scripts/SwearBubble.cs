using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwearBubble : MonoBehaviour
{
    public GameObject swearBubble;
    public Text swear;

    private Vector2 bubbleSize;
    private char[] allSwearChars = {'!', '@', '#', '$', '%', '&', '*'};
    private char[] currentSwearChars = new char[4];

    private void Start()
    {
        bubbleSize = swearBubble.transform.localScale;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            for(int i = 0; i < currentSwearChars.Length; i++)
            {
                currentSwearChars[i] = allSwearChars[Random.Range(0, allSwearChars.Length)];
            }
            StopCoroutine(Swear());
            StartCoroutine(Swear());
        }
    }

    IEnumerator Swear()
    {
        swearBubble.SetActive(true);
        swearBubble.transform.localScale = bubbleSize;
        swear.text = "";
        for (int i = 0; i < currentSwearChars.Length; i++)
        {
            swear.text += currentSwearChars[i];
            swearBubble.transform.localScale = new Vector2(0.02f * (i + 1), 0.02f * (i + 1)) + bubbleSize;
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(0.2f);
        swearBubble.SetActive(false);
    }
}
