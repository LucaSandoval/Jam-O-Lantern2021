using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{

    private SoundManager soundManager;
    public GameObject tutorial;
    public GameObject credits;

    public void Start()
    {
        soundManager = GetComponent<SoundManager>();
        soundManager.Play("Title");
        tutorial.SetActive(false);
        credits.SetActive(false);
    }


    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void TutorialOpen()
    {
        tutorial.SetActive(true);
    }

    public void CreditsOpen()
    {
        credits.SetActive(true);
    }
}
