using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class buttonMechanics : MonoBehaviour
{

    [SerializeField]
    private float speed;
    [SerializeField]
    private GameObject targetObject;
    [SerializeField]
    private Vector2 targetPosition;
    [SerializeField]
    private Vector2 startPosition;
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private Sprite newSprite;
    [SerializeField]
    private Sprite revertSprite;
    private bool unlock = false;


    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        unlock = true;
        spriteRenderer.sprite = newSprite;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        unlock = false;
        spriteRenderer.sprite = revertSprite;
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
