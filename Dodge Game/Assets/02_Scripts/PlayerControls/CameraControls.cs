using UnityEngine;
using System.Collections;


//Current gameobject will automatically add this components below
[RequireComponent(typeof(Camera))]

public class CameraControls : MonoBehaviour {

    GameObject player;
    bool newCameraPosSet;

	// Use this for initialization
	void Start () {
        newCameraPosSet = false;
        player = GameObject.FindGameObjectWithTag("Player");
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(player.transform.localPosition.y >= 0)
        {
            //transform.SetParent(player.transform);
            transform.localPosition = new Vector3(0, player.transform.localPosition.y+3,-10);
            newCameraPosSet = true;
        }


	}
}
