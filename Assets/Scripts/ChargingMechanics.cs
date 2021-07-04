using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargingMechanics : MonoBehaviour
{
    [SerializeField]
    private float force = 200;
    [SerializeField]
    private float chargeSeconds;
    [SerializeField]
    private PlayerMovement movement;
    [SerializeField]
    private Collider2D Collider;
    [SerializeField]
    private CharacterController2D ArmsStrong;

    IEnumerator ChargeLeft()
    {
        Collider.attachedRigidbody.AddForce((transform.right * -1) * force);
        // suspend execution for 2 seconds
        yield return new WaitForSeconds(chargeSeconds);
        movement.enabled = true;
    }

    IEnumerator ChargeRight()
    {
        Collider.attachedRigidbody.AddForce(transform.right * force);
        // suspend execution for 2 seconds
        yield return new WaitForSeconds(chargeSeconds);
        movement.enabled = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (ArmsStrong.m_FacingRight)
            {
                GetComponent<Animator>().Play("Arm Charge");
                movement.enabled = false;
                StartCoroutine("ChargeRight");
            }
            else if (!ArmsStrong.m_FacingRight)
            {
                GetComponent<Animator>().Play("Arm Charge");
                movement.enabled = false;
                StartCoroutine("ChargeLeft");
            }
        }
    }
}
