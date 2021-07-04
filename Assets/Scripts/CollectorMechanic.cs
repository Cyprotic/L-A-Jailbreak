using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectorMechanic : MonoBehaviour
{

    [SerializeField]
    private GameObject UIEnable;
    [SerializeField]
    private GameObject door;
    [SerializeField]
    private GameObject door1;
    [SerializeField]
    private GameObject door2;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float time;
    [SerializeField]
    private Vector2 target;
    [SerializeField]
    private Vector2 target1;
    [SerializeField]
    private Vector2 target2;
    private bool unlock = false;

    IEnumerator timeToEnd()
    {
        yield return new WaitForSeconds(time);
        if (door.activeSelf)
        {
            door.SetActive(false);
            Debug.Log("Door");
            unlock = false;
        }
    }
    IEnumerator timeToEnd1()
    {
        yield return new WaitForSeconds(time);
        if (door1.activeSelf && !door.activeSelf)
        {
            door1.SetActive(false);
            Debug.Log("Door1");
            unlock = false;
        }
    }

    IEnumerator timeToEnd2()
    {
        yield return new WaitForSeconds(time);
        if (door2.activeSelf && !door1.activeSelf)
        {
            door2.SetActive(false);
            Debug.Log("Door2");
            unlock = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Key"))
        {
            Destroy(other.gameObject);
            UIEnable.SetActive(true);
        }
        if (other.CompareTag("Door") && UIEnable.activeSelf)
        {
            UIEnable.SetActive(false);
            unlock = true;
        }
    }

    void Update()
    {
        if (unlock)
        {
            float slide = speed * Time.deltaTime;
            if (door.activeSelf)
            {
                door.transform.position = Vector2.MoveTowards(door.transform.position, target, slide);
                StartCoroutine("timeToEnd");
            }
            else if (door1.activeSelf && !door.activeSelf)
            {
                door1.transform.position = Vector2.MoveTowards(door1.transform.position, target1, slide);
                StartCoroutine("timeToEnd1");
            }
            else if (door2.activeSelf && !door1.activeSelf)
            {
                door2.transform.position = Vector2.MoveTowards(door2.transform.position, target2, slide);
                StartCoroutine("timeToEnd2");
            }
        }  
    }
}
