using UnityEngine;
using System.Collections;

public class TempMoveScript : MonoBehaviour {

    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float rotateSpeed;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if( Input.GetKey( KeyCode.W ) )
        {
            transform.Translate( 0f, 0f, moveSpeed, Space.Self );
        }
        if( Input.GetKey( KeyCode.A ) )
        {
            transform.Translate( -moveSpeed, 0f, 0f, Space.Self );
        }
        if( Input.GetKey( KeyCode.S ) )
        {
            transform.Translate( 0f, 0f, -moveSpeed, Space.Self );
        }
        if( Input.GetKey( KeyCode.D ) )
        {
            transform.Translate( moveSpeed, 0f, 0f, Space.Self );
        }
        if( Input.GetKey( KeyCode.Q ) )
        {
            transform.Rotate( 0f, -rotateSpeed, 0f, Space.Self );
        }
        if( Input.GetKey( KeyCode.E ) )
        {
            transform.Rotate( 0f, rotateSpeed, 0f, Space.Self );
        }
    }
}
