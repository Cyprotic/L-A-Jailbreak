using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public int nextScene;
    public AudioSource sound;
    public void LoadLevel()
    {
        Debug.Log("loading level..." + nextScene);
        SceneManager.LoadScene(nextScene);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            sound.Play();
            StartCoroutine(WaitForSound());
        }
    }

    IEnumerator WaitForSound()
    {
        yield return new WaitForSeconds(2);
        LoadLevel();
    }
}
