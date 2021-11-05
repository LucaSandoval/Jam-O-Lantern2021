using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{

    private SoundManager soundManager;

    public void Start()
    {
        soundManager = GetComponent<SoundManager>();
        soundManager.Play("Title");
    }


    public void Play()
    {
        SceneManager.LoadScene(1);
    }
}
