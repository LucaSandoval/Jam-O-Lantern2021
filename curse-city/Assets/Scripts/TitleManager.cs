using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{

    private SoundManager soundManager;
    public GameObject tutorial;

    public void Start()
    {
        soundManager = GetComponent<SoundManager>();
        soundManager.Play("Title");
        tutorial.SetActive(false);
    }


    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void TutorialOpen()
    {
        tutorial.SetActive(true);
    }
}
