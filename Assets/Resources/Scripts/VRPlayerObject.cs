using UnityEngine;
using System.Collections;

public class VRPlayerObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
		NetworkManager.Instance.player = this.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
