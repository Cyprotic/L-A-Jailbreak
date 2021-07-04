using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.SceneManagement;


public class getMiddleCharacters : MonoBehaviour
{
    [SerializeField]
    private GameObject Character1;
    [SerializeField]
    private GameObject Character2;
    private float newPosX;
    private float newPosY;
    [SerializeField]
    private Light2D collarLight;
    [SerializeField]
    private Light2D collarLight2;
    [SerializeField]
    private AudioSource DeathSound;
    [SerializeField]
    AudioSource beepSound;


    // Update is called once per frame
    void Update()
    {
        newPosX = Character1.transform.position.x + (Character2.transform.position.x - Character1.transform.position.x) / 2;
        newPosY = Character1.transform.position.y + (Character2.transform.position.y - Character1.transform.position.y) / 2;
        this.transform.position = new Vector2(newPosX, newPosY);
        float dist = Vector2.Distance(Character1.transform.position, Character2.transform.position);
        //Debug.Log(dist);
        if (dist > 8)
        {
            //DEAD
            Dead();
        }
        else if (dist < 8 && dist > 6)
        {
            //RED
            if (!beepSound.isPlaying)
                beepSound.Play();
            collarLight.color = new Color(255, 0, 0, 1);
            collarLight2.color = new Color(255, 0, 0, 1);
            
            beepSound.pitch = 2f;
        }
        else if (dist < 6 && dist > 3)
        {
            //Amber
            if (!beepSound.isPlaying)
                beepSound.Play();
            collarLight.color = new Color(255, 191, 0, 1);
            collarLight2.color = new Color(255, 191, 0, 1);
            beepSound.pitch = 0.25f;
        }
        else if (dist < 3)
        {
            //Green
            beepSound.Stop();
            collarLight.color = new Color(0, 128, 0, 1);
            collarLight2.color = new Color(0, 128, 0, 1);
        }
    }
    IEnumerator WaitForDeath()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(1);
    }

    public void Dead()
    {
        Character1.GetComponent<Animator>().Play("Death");
        Character2.GetComponent<Animator>().Play("Death");
        beepSound.Stop();
        DeathSound.Play();
        Character1.GetComponent<PlayerMovement>().enabled = false;
        Character2.GetComponent<Player2Movement>().enabled = false;
        Character1.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        Character2.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        Character1.GetComponentInChildren<Light2D>().enabled = false;
        Character2.GetComponentInChildren<Light2D>().enabled = false;
        StartCoroutine(WaitForDeath());
    }
}
