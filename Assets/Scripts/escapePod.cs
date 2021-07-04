using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Experimental.Rendering.Universal;

public class escapePod : MonoBehaviour
{

    [SerializeField]
    private PlayerMovement movementArmsStrong;
    [SerializeField]
    private Player2Movement movementLongShanks;
    [SerializeField]
    private SpriteRenderer spriteLongShanks;
    [SerializeField]
    private SpriteRenderer spriteArmsStrong;
    [SerializeField]
    private CharacterController2D controllerArmsStrong;
    [SerializeField]
    private CharacterController2D controllerLongShanks;
    [SerializeField]
    private Rigidbody2D rigidbodyArmsStrong;
    [SerializeField]
    private Rigidbody2D rigidbodyLongShanks;
    [SerializeField]
    private Light2D lightArmsStrong;
    [SerializeField]
    private Light2D lightLongShanks;
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private Sprite newSprite;
    [SerializeField]
    private float time;
    private bool activate = false;
    [SerializeField]
    private float speed;
    [SerializeField]
    private Vector2 targetPosition;
    [SerializeField]
    private UnityStandardAssets._2D.Camera2DFollow camera;

    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    IEnumerator timeToEnd()
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(2);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        rigidbodyArmsStrong.velocity = Vector2.zero;
        rigidbodyLongShanks.velocity = Vector2.zero;
        movementArmsStrong.enabled = false;
        movementLongShanks.enabled = false;
        spriteRenderer.sprite = newSprite;
        controllerArmsStrong.enabled = false;
        controllerLongShanks.enabled = false;
        spriteArmsStrong.enabled = false;
        spriteLongShanks.enabled = false;
        lightArmsStrong.enabled = false;
        lightLongShanks.enabled = false;
        activate = true;
        camera.target = this.transform;
        StartCoroutine("timeToEnd");
    }
    void Update()
    {
        if (activate)
        {
            float slide = speed * Time.deltaTime;
            this.transform.position = Vector2.MoveTowards(this.transform.position, targetPosition, slide);
        }
    }
}
