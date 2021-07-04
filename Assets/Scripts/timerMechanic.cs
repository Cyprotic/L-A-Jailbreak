using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class timerMechanic : MonoBehaviour
{
    [SerializeField]
    public float targetTime = 300.0f;
    [SerializeField]
    private TextMeshProUGUI timerText;
    [SerializeField]
    private getMiddleCharacters characters;
    [SerializeField]
    private AudioSource audio;
    [SerializeField]
    private AudioSource audio1;
    [SerializeField]
    private AudioSource audio2;
    [SerializeField]
    private AudioSource audio3;
    [SerializeField]
    private AudioSource audio4;

    private void Start()
    {
        audio.Play();
        audio1.Play();
        audio1.volume = 0f;
        audio2.Play();
        audio2.volume = 0f;
        audio3.Play();
        audio3.volume = 0f;
        audio4.Play();
        audio4.volume = 0f;
        Debug.Log("Song 1");
    }

    void Update()
    {
        if (targetTime >= 0)
            targetTime -= Time.deltaTime;
        timerText.text = targetTime.ToString("F1");

        if (targetTime < 240.0f && targetTime > 160.0f)
        {
            audio.volume = 0f;
            audio1.volume = 100f;
        }
        else if (targetTime <= 160.0f && targetTime > 120.0f)
        {
            audio1.volume = 0f;
            audio2.volume = 100f;
        }
        else if (targetTime <= 120.0f && targetTime > 60.0f)
        {
            audio2.volume = 0f;
            audio3.volume = 100f;
        }
        else if (targetTime <= 60.0f && targetTime > 30.0f)
        {
            audio3.volume = 0f;
            audio4.volume = 100f;
            timerText.color = Color.yellow;
        }
        else if (targetTime <= 30.0f && targetTime > 0.0f)
        {
            timerText.color = Color.red;
        }
        else if (targetTime <= 0.0f)
        {
            timerEnded();
        }

    }

    void timerEnded()
    {
        characters.Dead();
    }
}
