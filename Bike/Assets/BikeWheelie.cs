using UnityEngine;
using System.Collections;

public class BikeWheelie : MonoBehaviour {

	public Rigidbody frontFrame;
	public float force;

	// Update is called once per frame
	void FixedUpdate () {
	
		if (Input.GetKey (KeyCode.E)) {
			frontFrame.AddForce (new Vector3 (0, force, 0));
		}
			

	}


}
