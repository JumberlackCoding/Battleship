using UnityEngine;
using System.Collections;

public class GameStart : MonoBehaviour {

    [SerializeField]
    private GameObject WhitePegPreFab;
    [SerializeField]
    private GameObject RedPegPreFab;

    [SerializeField]
    private Vector3 WhitePegSpawn;
    [SerializeField]
    private Vector3 RedPegSpawn;

    [SerializeField]
    private GameObject[] WhitePegs;
    [SerializeField]
    private GameObject[] RedPegs;

    [SerializeField]
    private int NumberOfPegs;

    [SerializeField]
    private float PegWidth;
    [SerializeField]
    private float PegHeight;



	// Use this for initialization
	void Start () {
        WhitePegs = new GameObject[NumberOfPegs];
        RedPegs = new GameObject[NumberOfPegs];

        // spawn and position the pegs
        for( int i = 0; i < RedPegs.Length; i++ )
        {
            if( ( RedPegSpawn.z + i * PegWidth ) >= -10.5 )
            {
                RedPegSpawn.y += PegHeight;
                RedPegSpawn.z -= 2;
            }
            RedPegs[i] = (GameObject)Instantiate( RedPegPreFab, new Vector3( RedPegSpawn.x, RedPegSpawn.y, RedPegSpawn.z + i * PegWidth ), Quaternion.identity );
            RedPegs[i].transform.Rotate( 0f, 0f, -90 );
        }
        for( int i = 0; i < WhitePegs.Length; i++ )
        {
            if( ( WhitePegSpawn.z + i * PegWidth ) >= -10.5 )
            {
                WhitePegSpawn.y += PegHeight;
                WhitePegSpawn.z -= 2;
            }
            WhitePegs[i] = (GameObject)Instantiate( WhitePegPreFab, new Vector3( WhitePegSpawn.x, WhitePegSpawn.y, WhitePegSpawn.z + i * PegWidth ), Quaternion.identity );
            WhitePegs[i].transform.Rotate( 0f, 0f, 90 );
        }
    }
	
	// Update is called once per frame
	void Update () {
	    
	}
}
