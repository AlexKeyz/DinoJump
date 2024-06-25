using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusiicPlay : MonoBehaviour
{
    //GameObject BackgraundMusic;
    //GameObject AudioSourse;
    public AudioSource ad;
    public AudioSource bm;

    void Start()
    {
        
    }

    
    void Update()
    {
        if (MusicControll.isOn == true)
        {
            ad.enabled = true;
            bm.enabled = true;
        }
        if (MusicControll.isOn == false)
        {
            ad.enabled = false;
            bm.enabled = false;
        }
    }
}
