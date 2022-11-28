using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Manager : MonoBehaviour
{
    public AudioSource bgmSource;

    public void SetBGMVolume(float volume)
    {
        bgmSource.volume = volume;
    }
}
