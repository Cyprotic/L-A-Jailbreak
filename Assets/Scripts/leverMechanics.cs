using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class leverMechanics : MonoBehaviour
{
    private bool unlock = false;
    [SerializeField]
    private float speed;
    [SerializeField]
    private GameObject targetObject;
    [SerializeField]
    private Vector2 startPosition;
    [SerializeField]
    private Vector2 targetPosition;
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private Sprite newSprite;
    [SerializeField]
    private Sprite originalSprite;

    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (other.CompareTag("Player2") && !unlock)
            {
                spriteRenderer.sprite = newSprite;
                unlock = true;
            }  
            else if (other.CompareTag("Player2") && unlock)
            {
                spriteRenderer.sprite = originalSprite;
                unlock = false;
            }
        }      
    }
    void Update()
    {
        if (unlock)
        {
            float slide = speed * Time.deltaTime;
            targetObject.transform.position = Vector2.MoveTowards(targetObject.transform.position, targetPosition, slide);
        }
        else if (!unlock)
        {
            float slide = speed * Time.deltaTime;
            targetObject.transform.position = Vector2.MoveTowards(targetObject.transform.position, startPosition, slide);
        }
    }
}
