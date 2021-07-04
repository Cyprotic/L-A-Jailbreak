using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.Events;

public class UIButton : MonoBehaviour
{
    private bool hovering = false;
    private SpriteRenderer renderer;
    public Light2D highlight;
    public AudioSource highlightSound;
    public AudioSource pressSound;
    [Header("Event")]
    [Space]
    public UnityEvent OnPressEvent;
    private void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
    }
    public void OnMouseEnter()
    {  
        //Debug.Log("Enter");
        highlightSound.Play();
        highlight.enabled = true;
        hovering = true;
    }
    public void OnMouseExit()
    {
        //Debug.Log("Exit");
        highlight.enabled = false;
        hovering = false;;
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && hovering)
        {
            //Debug.Log("clicked");
            pressSound.Play();
            OnPressEvent.Invoke();
        }
    }

}