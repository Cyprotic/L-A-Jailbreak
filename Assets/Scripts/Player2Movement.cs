using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Player2Movement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    public Rigidbody2D body;
    public AudioSource walkSound;
    public AudioSource jumpSound;
    [SerializeField]
    boostingMechanic jumpMechanic;


    public float runSpeed = 15f;

    float horizontalMove = 0f;

    bool jump = false;
    bool crouch = false;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        InputControls();
    }


    private void InputControls()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal2") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump2") && (!jumpMechanic.cantJump))
        {
            //Debug.Log("Jumped");
            jump = true;
            animator.SetBool("IsJumping", true);
            jumpSound.Play();
        }

        if (Input.GetButtonDown("Crouch2"))
        {
            crouch = true;
            animator.SetBool("IsCrouching", true);
        } else if (Input.GetButtonUp("Crouch2"))
        {
            crouch = false;
            animator.SetBool("IsCrouching", false);
        }
    }
    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;

        if (horizontalMove == 0 || animator.GetBool("IsJumping"))
        {
            walkSound.Pause();
        } else
        {
            walkSound.UnPause();
        }

        if (body.velocity.y == 0)
        {
            StartCoroutine(Wait());
        }


    }
    public void OnLanding()
    {
        if (body.velocity.y < 0)
        {
            animator.SetBool("IsJumping", false);
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.4f);
        if (body.velocity.y == 0)
        {
            animator.SetBool("IsJumping", false);
        }
    }

}
