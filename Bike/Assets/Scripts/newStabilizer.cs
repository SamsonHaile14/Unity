using UnityEngine;
using System.Collections;

public class newStabilizer : MonoBehaviour {

	public float stabilizingForce;
	public float boostSpeed;

	public Rigidbody backFrame;
	public Rigidbody frontFrame;

	public Transform backT;

	private float stableRotation = 0;

	// Update is called once per frame
	void FixedUpdate () {
		backFrame.angularVelocity = Vector3.zero;
		//frontFrame.angularVelocity = Vector3.zero;

		if (backT.rotation.eulerAngles.z > 180) {
			backFrame.AddRelativeTorque (Vector3.forward * stabilizingForce *
				(backT.rotation.eulerAngles.z - stableRotation));
			frontFrame.AddRelativeTorque (Vector3.forward * stabilizingForce *
				(backT.rotation.eulerAngles.z - stableRotation));
		} else {
			backFrame.AddRelativeTorque (Vector3.forward * -1 * stabilizingForce *
				(backT.rotation.eulerAngles.z - stableRotation));
			frontFrame.AddRelativeTorque (Vector3.forward * -1 * stabilizingForce *
				(backT.rotation.eulerAngles.z - stableRotation));
		}
	}


}
