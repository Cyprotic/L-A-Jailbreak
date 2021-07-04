using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderMechanics : MonoBehaviour
{

	[SerializeField]
	private float speed;
	[SerializeField]
	private float timeSliding;
	[SerializeField]
	private float decayDown;
	[SerializeField]
	private float force;
	[SerializeField]
	private PlayerMovement isNotCharging;
	[SerializeField]
	private GameObject ArmStrong;
	[SerializeField]
	private Collider2D Collider;


	IEnumerator timeColiderActivated()
	{
		yield return new WaitForSeconds(timeSliding);
		Collider.enabled = false;
		Collider.attachedRigidbody.velocity = Vector3.zero;
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if (other.CompareTag("Player2"))
		{
			if (Input.GetKey(KeyCode.W))
			{
				other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);
			}
			else if (Input.GetKey(KeyCode.S))
			{
				other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -speed);
			}
			else
			{
				other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, decayDown);
			}
		}
	}
}
