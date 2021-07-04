using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeScript : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            //Debug.Log("escape was pressed");
            LoadLevel();
        }
    }
    public void LoadLevel()
    {
        SceneManager.LoadScene(0);
    }
}
