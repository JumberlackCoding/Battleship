﻿using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PlayerSyncPosition : NetworkBehaviour
{

    [SerializeField]
    private Transform myTransform;

    [SerializeField]
    private float lerpRate = 15;
    [SerializeField]
    private float threshold = 0.4f;

    [SerializeField]
    private NetworkManager nManager;

    [SerializeField]
    private Text latencyText;

    private NetworkClient nClient;

    private int latency;

    [SyncVar] // Tells server to take this value and synchronize it among the clients
    private Vector3 syncPos;

    private Vector3 lastPos;

    void Awake()
    {
        nClient = nManager.client;
    }

    void Update()
    {
        LerpPosition();
        ShowLatency();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        TransmitPosition();
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
        // print( "hi" );
    }

    [ClientCallback] // Won't generate warnings
    void TransmitPosition()
    {
        if( isLocalPlayer && ( Vector3.Distance( myTransform.position, lastPos ) > threshold ) )
        {
            CmdProvidePositionToSever( myTransform.position );
            lastPos = myTransform.position;
        }
    }

    void ShowLatency()
    {
        if( isLocalPlayer )
        {
            latency = nClient.GetRTT();
            latencyText.text = latency.ToString();
        }
    }

}
