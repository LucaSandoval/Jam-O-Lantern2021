using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTracker : MonoBehaviour
{
    public static int score = 0;
    public static int highScore;
    private Text textBox;
    public Text highScoreText;

    public static float scale;

    void Start()
    {
        score = 0;
        scale = 1;
        textBox = gameObject.GetComponent<Text>();
        //highScoreText.text = "test";
    }

    void Update()
    {
        if (score > highScore)
        {
            highScore = score;
        }


        textBox.text = score.ToString();
        highScoreText.text = "Highscore: " + highScore.ToString();

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
