using UnityEngine;
using System.Collections;

public class WheelBackMove : MonoBehaviour {

	public float rotationSpeed = 100;

	public bool frontPower = false;
	public Rigidbody frontWheel;

	private Rigidbody wheel;

	void Start(){
		wheel = GetComponent<Rigidbody> ();

	}

	void Update () {

		float rotation = Input.GetAxis ("Vertical") * rotationSpeed * -1;
		rotation *= Time.deltaTime;

		wheel.AddRelativeTorque (Vector3.up * rotation);

		if (frontPower) {
			frontWheel.AddRelativeTorque (Vector3.up * rotation);
			}
	}
		
}
