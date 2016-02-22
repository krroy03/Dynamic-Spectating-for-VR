using UnityEngine;
using System.Collections;

public class Brush : MonoBehaviour {

	public const bool mouseTest = true;

	// Use this for initialization
	void Start () {
		if (mouseTest) {
			this.transform.parent = null;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (mouseTest) {
			Vector3 screenPos = Input.mousePosition;
			screenPos.z = 0.384f;
			Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
			this.transform.position = worldPos;

			if (Input.GetMouseButtonDown(0)) {
				BroadcastMessage ("ActivateEmitter", true, SendMessageOptions.DontRequireReceiver);
			}

			if (Input.GetMouseButtonUp(0)) {
				BroadcastMessage ("ActivateEmitter", false, SendMessageOptions.DontRequireReceiver);
			}
		}
	}
}
