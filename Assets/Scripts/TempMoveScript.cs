using UnityEngine;
using System.Collections;

public class TempMoveScript : MonoBehaviour {

    [SerializeField]
    private float moveSpeed;
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if( Input.GetKey( KeyCode.W ) )
        {
            transform.Translate( 0f, moveSpeed, 0f );
        }
        if( Input.GetKey( KeyCode.A ) )
        {
            transform.Translate( -moveSpeed, 0f, 0f );
        }
        if( Input.GetKey( KeyCode.S ) )
        {
            transform.Translate( 0f, -moveSpeed, 0f );
        }
        if( Input.GetKey( KeyCode.D ) )
        {
            transform.Translate( moveSpeed, 0f, 0f );
        }
    }
}
