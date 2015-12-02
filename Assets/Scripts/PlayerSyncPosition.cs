using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerSyncPosition : NetworkBehaviour {

    [SerializeField]
    private Transform myTransform;

    [SerializeField]
    private float lerpRate = 15;

    [SyncVar] // Tells server to take this value and synchronize it among the clients
    private Vector3 syncPos;



	// Update is called once per frame
	void FixedUpdate () {
        TransmitPosition();
        LerpPosition();
	}

    void LerpPosition()
    {
        if( !isLocalPlayer )
        {
            myTransform.position = Vector3.Lerp( myTransform.position, syncPos, Time.deltaTime * lerpRate );
        }
    }

    [Command] // Sent to server.. Client is telling server to run this 
    void CmdProvidePositionToSever( Vector3 pos ) // must be called Cmd*
    {
        syncPos = pos;
    }

    [ClientCallback] // Won't generate warnings
    void TransmitPosition()
    {
        if( isLocalPlayer )
        {
            CmdProvidePositionToSever( myTransform.position );
        }
    }
}
