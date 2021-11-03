using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTracker : MonoBehaviour
{
    public static int score = 0;
    private Text textBox;

    public static float scale;

    void Start()
    {
        scale = 1;
        textBox = gameObject.GetComponent<Text>();
    }

    void Update()
    {
        textBox.text = score.ToString();

        textBox.rectTransform.localScale = new Vector3(scale, scale, 1);
    }

    private void FixedUpdate()
    {
        if (scale > 1)
        {
            scale -= Time.deltaTime * 5;
        }
    }
}
