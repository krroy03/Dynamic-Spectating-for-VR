using UnityEngine;
using System.Collections;

public class SpectatorControls : Photon.MonoBehaviour
{

	private PhotonView myView;
	// Use this for initialization
	void Start ()
	{
		myView = this.gameObject.GetComponent<PhotonView> ();
	}
	
	// Update is called once per frame
	void Update ()
	{

		if (Input.GetMouseButtonUp (0) && !GameManager.Instance.VR) {
			
			myView.RPC ("SpectatorInfluence", PhotonTargets.All);
		}
	}

	[PunRPC]
	void SpectatorInfluence ()
	{
		NetworkManager.Instance.SpectatorInfluence ();
	}
}
