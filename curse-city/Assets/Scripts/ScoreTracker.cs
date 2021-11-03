using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTracker : MonoBehaviour
{
    public static int score = 0;
    private Text textBox;

    void Start()
    {
        textBox = gameObject.GetComponent<Text>();
    }

    void Update()
    {
        textBox.text = score.ToString();
    }
}
