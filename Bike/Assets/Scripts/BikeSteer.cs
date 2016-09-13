using UnityEngine;
using System.Collections;

public class BikeSteer : MonoBehaviour {

	private Rigidbody steerFrame;

	public Transform pivotObject, backFrame;
	public Transform turningWheel;
	public float rotationRate,turningRange;

	void Start() {
		steerFrame = GetComponent<Rigidbody> ();
	}

	// Update is called once per frame
	void FixedUpdate () {
		steerFrame.angularVelocity = Vector3.zero;

		float angle = Input.GetAxis ("Horizontal") * rotationRate;
		angle *= Time.deltaTime;

		float lbOne = backFrame.rotation.eulerAngles.y - turningRange, ubOne = backFrame.rotation.eulerAngles.y + turningRange;
		float lbTwo, ubTwo;

		float posDist, negDist;

		if (transform.rotation.eulerAngles.y < backFrame.rotation.eulerAngles.y) {
			posDist = backFrame.rotation.eulerAngles.y - transform.rotation.eulerAngles.y;
			negDist = transform.rotation.eulerAngles.y + 360 - backFrame.rotation.eulerAngles.y;
		} else {
			posDist = 360 -  transform.rotation.eulerAngles.y + backFrame.rotation.eulerAngles.y;
			negDist = transform.rotation.eulerAngles.y - backFrame.rotation.eulerAngles.y;
		}

		if (lbOne < 0) {
			lbOne = 0;
			ubTwo = 360;
			lbTwo = (360-turningRange) + backFrame.rotation.eulerAngles.y;
		} else if (ubOne > 360) {
			ubOne = 360;
			lbTwo = 0;
			ubTwo = backFrame.rotation.eulerAngles.y - (360-turningRange);
		}
		else{
			lbTwo = -1;
			ubTwo = -1;
		}

		bool meetsBounds = ((transform.rotation.eulerAngles.y > lbOne && transform.rotation.eulerAngles.y < ubOne) ||
			(transform.rotation.eulerAngles.y > lbTwo && transform.rotation.eulerAngles.y < ubTwo));


			if( meetsBounds || (angle > 0 && (posDist < negDist)) || (angle < 0 && (negDist < posDist)) ){
				transform.RotateAround (pivotObject.position, pivotObject.up, angle);
				turningWheel.RotateAround (pivotObject.position, pivotObject.up, angle);
			}
	}
}


