using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;

public class PauseMenuScript : MonoBehaviour
{
    AudioSource audio;
    void Start()
    {
        audio = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioSource>();    
    }
    public void SetVolume(float volume)
    {
        audio.volume = volume;
    }

}
