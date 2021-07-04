using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallOffLevel : MonoBehaviour
{
    // On trigger, check if object is player
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Player2"))
        {
            ResetPlayer();
        }
    }

    public void ResetPlayer()
    {
        SceneManager.LoadScene(1);
    }
}
