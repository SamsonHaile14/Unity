using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public Transform target;
	public float distanceX = 2f, distanceY = 2f, distanceZ = -2.5f;
	public bool followBack = true;

	// Update is called once per frame
	void Update () {
		if (followBack) {
			Vector3 dest = target.position + target.right * distanceX +
				target.up * distanceY + target.forward * distanceZ;

			dest.y = distanceY + target.position.y;

			transform.position = dest;
			transform.LookAt (target);
		} else {
			transform.position = target.position + (new Vector3 (distanceX, distanceY, distanceZ));
			transform.LookAt (target);
		}
	}
}
