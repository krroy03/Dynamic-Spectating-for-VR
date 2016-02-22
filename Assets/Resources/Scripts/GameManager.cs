using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public bool VR = false;

	public GameObject spectatorCam; 

	public GameObject star; 

	private static GameManager instance;
	public static GameManager Instance
	{
		get
		{
			return instance;
		}
	}

	void Awake() {
		instance = this;
	}
	// Use this for initialization
	void Start () {
		if (!VR) {
			spectatorCam.SetActive (true);
			Camera.main.gameObject.SetActive (false);
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey (KeyCode.Escape)) {
			Application.Quit ();
		}

	}
}
