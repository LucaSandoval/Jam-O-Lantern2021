using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonEffect : MonoBehaviour
{
    private Image icon;
    public Sprite[] sprites;
    private RectTransform textComponent;
    private SoundManager soundManager;

    void Start()
    {
        soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
        icon = GetComponent<Image>();
        textComponent = transform.GetChild(0).GetComponent<RectTransform>();
        textComponent.transform.position = new Vector3(transform.position.x, transform.position.y + 10, 0);
    }

    public void HighLight()
    {
        soundManager.PlayRandPitch("Blip", 1, 0.5f);
        icon.sprite = sprites[1];
        textComponent.transform.position = new Vector3(transform.position.x, transform.position.y - 10, 0);
    }

    public void Unhighlight()
    {
        icon.sprite = sprites[0];
        textComponent.transform.position = transform.position;
        textComponent.transform.position = new Vector3(transform.position.x, transform.position.y + 10, 0);
    }
}
