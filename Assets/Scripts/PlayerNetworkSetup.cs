using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerNetworkSetup : NetworkBehaviour {

    [SerializeField]
    public GameObject FPSCamera;
    [SerializeField]
    public AudioListener FPSCamAudioListener;

	// Use this for initialization
	void Start () {
	    if( isLocalPlayer )
        {
            GameObject.Find( "Main Camera" ).SetActive( false );

            GetComponent<TempMoveScript>().enabled = true;
            FPSCamera.SetActive( true );
            GameObject.Find( "Main Camera Temp" ).SetActive( true );
            FPSCamAudioListener.enabled = true;
        }
	}
}
