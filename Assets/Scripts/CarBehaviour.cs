using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBehaviour : MonoBehaviour {
	public float forwardSpeed = 20;
	public float turnSpeed = 150;
	[Range(0,1)]
	public float drift = 0.9f;
	public float maxGripSpeed = 2.5f;
	Rigidbody2D body;
	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		float forwardInput = Input.GetAxis ("Vertical");
		float turnInput = Input.GetAxis ("Horizontal");
		float driftAmount = 1;
		if (RightVelocity().magnitude > maxGripSpeed) 
		{
			driftAmount = drift;
		}
		body.velocity = ForwardVelocity() + RightVelocity() * driftAmount;

		if (forwardInput > 0) 
		{
			body.AddForce (transform.up * forwardSpeed * forwardInput);
		}
		float tf = Mathf.Lerp (0, -turnSpeed, body.velocity.magnitude * 0.5f);
		body.angularVelocity = turnInput * tf;
	}
	Vector2 ForwardVelocity()
	{
		return transform.up * Vector2.Dot(body.velocity, transform.up);
	}
	Vector2 RightVelocity() {
		return transform.right * Vector2.Dot(body.velocity, transform.right);
	}
}
