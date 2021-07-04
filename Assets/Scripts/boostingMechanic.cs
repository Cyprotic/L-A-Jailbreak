using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boostingMechanic : MonoBehaviour
{
    [SerializeField]
    private GameObject Armstrong;
    [SerializeField]
    private BoxCollider2D Longshanks;
    [SerializeField]
    Player2Movement Longshanksmovement;
    [SerializeField]
    PlayerMovement Armstrongmovement;
    public bool cantJump = false;
    private bool release = false;
    [SerializeField]
    private float boost;
    [SerializeField]
    private float time;
    [SerializeField]
    private Collider2D boost_colider;
    public bool held;

    private float DefaultRunSpeed = 0;

    private void Start()
    {
        DefaultRunSpeed = Armstrongmovement.runSpeed;
        
    }

    IEnumerator timeToDefaults()
    {
        yield return new WaitForSeconds(time);
        cantJump = false;
        release = false;
        Armstrongmovement.runSpeed = DefaultRunSpeed;
        boost_colider.enabled = true;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Boost")
        {
            //Longshanksmovement.runSpeed = 40f;
            Armstrongmovement.runSpeed = DefaultRunSpeed;
            held = Input.GetKey(KeyCode.E);
            if (held)
            {
                cantJump = true;
                if (!release)
                    Longshanks.transform.position = Armstrong.transform.position;
                //Longshanksmovement.runSpeed = 8f;
                Armstrongmovement.runSpeed *= 0.4f;
                bool jump = Input.GetButtonUp("Jump2");
                if (jump)
                {
                    release = true;
                    Armstrongmovement.boostAnimation();
                    boost_colider.enabled = false;
                    StartCoroutine("timeToDefaults");
                    other.attachedRigidbody.AddForce(transform.up * boost);
                }
            }
        }
    }
    
}
