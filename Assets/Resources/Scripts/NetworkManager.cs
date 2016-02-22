using UnityEngine;
using System.Collections;
using Photon;

public class NetworkManager : Photon.PunBehaviour {

	private string VRPlayer = "VRPlayer"; 
	public GameObject player; 

	public static string roomName = "Nova";

	private static NetworkManager instance;
	public static NetworkManager Instance
	{
		get
		{
			return instance;
		}
	}

	void Awake()
	{
		instance = this;
	}


	// Use this for initialization
	void Start () {
		PhotonNetwork.ConnectUsingSettings ("v1.0f");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// on joining photonserver, immediately join randomroom 
	public override void OnConnectedToMaster() {
		base.OnConnectedToMaster();
		RoomOptions roomOptions = new RoomOptions() { isVisible = false, maxPlayers = 4 };
		PhotonNetwork.JoinOrCreateRoom (roomName, roomOptions, TypedLobby.Default);


	}

	public override void OnJoinedRoom ()
	{
		base.OnJoinedRoom ();
		SpawnVRPlayer ();
	}
		
	void SpawnVRPlayer() {
		if (GameManager.Instance.VR) {
			// if vr player, send player object to all spectators to be instantiated
			player = PhotonNetwork.Instantiate ("Prefabs/" + VRPlayer, Camera.main.transform.position, Camera.main.transform.rotation, 0);
			// root it to VR cam container, so player moves with it 
			player.transform.SetParent (Camera.main.transform.parent);

		}
	}
		
	public void SpectatorInfluence() {
		if (GameManager.Instance.VR) {
			GameObject spheres = GameObject.Find ("Spheres");
			ParticleSystem[] systems = spheres.transform.GetComponentsInChildren<ParticleSystem> ();
			foreach (ParticleSystem pSystem in systems) {
				pSystem.Emit (10);
			}
		}
		if (player)
			GameObject.Instantiate(GameManager.Instance.star, player.transform.position + player.transform.forward.normalized,player.transform.rotation);
	}


}
