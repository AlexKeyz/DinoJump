using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;
using UnityEngine.UI;

public class MusicControll : MonoBehaviour
{
    public Sprite onMusic;
    public Sprite offMusic;

    public Image MusicButton;
    public static bool isOn;
    public AudioSource ad;
    // Start is called before the first frame update
    void Start()
    {
        isOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("music") == 0)
        {
            MusicButton.GetComponent<Image>().sprite = onMusic;
            ad.enabled = true;
            isOn = true;
        }
        else if (PlayerPrefs.GetInt("music") == 1)
        {
            MusicButton.GetComponent<Image>().sprite = offMusic;
            ad.enabled = false;
            isOn = false;
        }
    }
    public void offSaund()
    {
        if (!isOn)
        {
            PlayerPrefs.SetInt("music", 0);
            YandexGame.savesData.money = 0;
        }
        else if (isOn)
        {
            PlayerPrefs.SetInt("music", 1);
            YandexGame.savesData.money = 1;
        }
    }
}
