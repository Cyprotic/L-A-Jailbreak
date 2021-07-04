using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagedDoorMechanic : MonoBehaviour
{

    [SerializeField]
    private float force;
    [SerializeField]
    private PlayerMovement isNotCharging;
    [SerializeField]
    private Rigidbody2D Rigidbody;
    [SerializeField]
    private GameObject ArmStrong;
    [SerializeField]
    private Collider2D Collider;
	[SerializeField]
	private float time;
	private SpriteRenderer spriteRenderer;
	[SerializeField]
	private Sprite newSprite;


	IEnumerator timeToDestroy()
	{
		yield return new WaitForSeconds(time);
		Destroy(gameObject);
	}

	private void Start()
    {
		spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
		Rigidbody.mass = 1000;
    }

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag("Player") && isNotCharging.enabled == false)
		{
			if (transform.position.x > ArmStrong.transform.position.x)
			{
				Debug.Log("Player is colliding on target's right side");
				Rigidbody.mass = 1;
				Collider.attachedRigidbody.AddForce(transform.right * force);
				spriteRenderer.sprite = newSprite;
				StartCoroutine("timeToDestroy");
			}
			else
			{
				Debug.Log("Player is colliding on target's left side");
				Rigidbody.mass = 1;
				Collider.attachedRigidbody.AddForce((transform.right * -1) * force);
				spriteRenderer.sprite = newSprite;
				StartCoroutine("timeToDestroy");
			}
		}
	}
}
