using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class VolumeControl : MonoBehaviour
{
    public float MusicVolume = 0.5f;
    public float EffectsVolume = 0.5f;
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
    public void SetMusicVolume(float newVolume)
    {
        MusicVolume = newVolume;
    }
    private void FixedUpdate()
    {
        GameObject.Find("Music").GetComponent<AudioSource>().volume = MusicVolume;
    }
}
