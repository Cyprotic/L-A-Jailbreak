using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trowingMechanic : MonoBehaviour
{
    [SerializeField]
    private float boost;
    [SerializeField]
    private float boostup;
    [SerializeField]
    private CharacterController2D LongShanks;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private boostingMechanic boosting;

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player" && !boosting.held)
        {
            bool trow = Input.GetKeyDown(KeyCode.F);
            if (trow)
            {
                animator.Play("LS Boosted", 0);
                if (LongShanks.m_FacingRight)
                {
                    other.attachedRigidbody.AddForce(transform.up * boostup);
                    other.attachedRigidbody.AddForce(transform.right * boost);
                }  
                else if (!LongShanks.m_FacingRight)
                {
                    other.attachedRigidbody.AddForce(transform.up * boostup);
                    other.attachedRigidbody.AddForce((transform.right * -1) * boost);
                }
            }
        }
    }
}
