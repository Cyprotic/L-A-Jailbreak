using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class buttonMechanics : MonoBehaviour
{

    [SerializeField]
    private float speed;
    [SerializeField]
    private GameObject leverAction;
    [SerializeField]
    private Vector2 target;
    [SerializeField]
    private Vector2 originalPOS;
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
        spriteRenderer.sprite = newSprite;
        unlock = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        spriteRenderer.sprite = revertSprite;
        unlock = false;
    }

    void Update()
    {
        if (unlock)
        {
            float slide = speed * Time.deltaTime;
            leverAction.transform.position = Vector2.MoveTowards(leverAction.transform.position, target, slide);
        }
        else if (!unlock)
        {
            float slide = speed * Time.deltaTime;
            leverAction.transform.position = Vector2.MoveTowards(leverAction.transform.position, originalPOS, slide);
        }
    }
}
