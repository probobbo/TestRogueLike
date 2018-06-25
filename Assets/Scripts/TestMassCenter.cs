using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMassCenter : MonoBehaviour
{

	public Transform World,CenterOfMass;
	public float GravityIntensity, MoveSpeed;
	private Rigidbody RB;
	private float Hor, Ver;
	private Vector3 MovementDirection;

	// Use this for initialization
	void Start()
	{

		RB = GetComponent<Rigidbody>();
		RB.centerOfMass = CenterOfMass.transform.position;
	}

	private void Update()
	{
		Hor = Input.GetAxis("Horizontal");
		Ver = Input.GetAxis("Vertical");
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		Physics.gravity = (World.position - transform.position).normalized * GravityIntensity;
		MovementDirection = (transform.forward * Ver) + (transform.right * Hor);
		RB.AddForce(MovementDirection * Time.fixedDeltaTime * MoveSpeed, ForceMode.VelocityChange);
	}
}
