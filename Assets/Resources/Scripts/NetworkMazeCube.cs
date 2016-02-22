using UnityEngine;
using System.Collections;

public class NetworkMazeCube : Photon.MonoBehaviour {

	Vector3 correctPlayerPos;
	Quaternion correctPlayerRot; 


	// Use this for initialization
	void Start () {
		GameObject par = GameObject.Find ("Maze");
		this.transform.SetParent (par.transform);
	}
	
	// Update is called once per frame
	void Update () {
		if (!photonView.isMine) {
			transform.position = Vector3.Lerp (transform.position, this.correctPlayerPos, Time.deltaTime * 5);
			transform.rotation = Quaternion.Lerp (transform.rotation, this.correctPlayerRot, Time.deltaTime * 5);
		}
	}

	void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		if (stream.isWriting)
		{
			//We own this player: send the others our data
			stream.SendNext(this.transform.position);
			stream.SendNext(this.transform.rotation);
		}
		else
		{
			//Network player, receive data
			correctPlayerPos = (Vector3)stream.ReceiveNext();
			correctPlayerRot = (Quaternion)stream.ReceiveNext();
		}
	}
}
