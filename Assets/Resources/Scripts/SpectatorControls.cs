using UnityEngine;
using System.Collections;

public class SpectatorControls : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButton (0)) {
			SpectatorInfluence ();
		}
	}

	void SpectatorInfluence() {
		this.gameObject.GetComponent<ParticleSystem> ().Emit (50);
	}
}
