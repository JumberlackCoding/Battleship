using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerSyncRotation : NetworkBehaviour
{
    [SerializeField]
    private Transform myTransform;
    [SerializeField]
    private Transform camTransform;

    [SerializeField]
    private float lerpRate = 15;
    [SerializeField]
    private float threshold = 0.1f;

    [SyncVar] // Tells server to take this value and synchronize it among the clients
    private Quaternion syncRot;
    [SyncVar]
    private Quaternion syncCamRot;

    private Quaternion lastPlayerRot;
    private Quaternion lastCamRot;

    // Update is called once per frame
    void FixedUpdate()
    {
        TransmitRotations();
        LerpRotations();
    }

    void LerpRotations()
    {
        if( !isLocalPlayer )
        {
            myTransform.rotation = Quaternion.Lerp( myTransform.rotation, syncRot, Time.deltaTime * lerpRate );
            camTransform.rotation = Quaternion.Lerp( camTransform.rotation, syncCamRot, Time.deltaTime * lerpRate );
        }
    }

    [Command] // Sent to server.. Client is telling server to run this 
    void CmdProvideRotationsToSever( Quaternion playerRot, Quaternion camRot ) // must be called Cmd*
    {
        syncRot = playerRot;
        syncCamRot = camRot;
       // print( "bye" );
    }

    [ClientCallback] // Won't generate warnings
    void TransmitRotations()
    {
        if( isLocalPlayer )
        {
            if( ( Quaternion.Angle( myTransform.rotation, lastPlayerRot ) > threshold ) || ( Quaternion.Angle( camTransform.rotation, lastCamRot ) > threshold ) )
            {
                CmdProvideRotationsToSever( myTransform.rotation, camTransform.rotation );
                lastPlayerRot = myTransform.rotation;
                lastCamRot = myTransform.rotation;
            }
        }
    }
}
