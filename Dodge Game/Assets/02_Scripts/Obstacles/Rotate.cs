using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

    /*
     * TESTING CODE <THROWAWAY>
     * Rotates the object
     **/

    public Vector3 rotation;

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(rotation);
	
	}

}
