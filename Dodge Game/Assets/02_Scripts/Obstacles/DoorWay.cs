using UnityEngine;
using System.Collections;

public class DoorWay : MonoBehaviour {

    /*
     *  TESTING CODE <THROWAWAY>
     *  MOVES THE 2 BLOCKS By sliding them in and out
     * 
     **/

    public GameObject leftBlock, rightBlock;

    public float initValue;

    private MathExt.Interpolate inter;
    private Vector2 xBoundaries;

	// Use this for initialization
	void Start () {
        xBoundaries = new Vector2(2, 6);
        inter = new MathExt.Interpolate();
        inter.value = initValue;
        inter.ascending = true;
    }
	
	// Update is called once per frame
	void Update () {
        inter.Rebound();
        inter.Slide();        

        leftBlock.transform.localPosition = new Vector3(Mathf.Lerp(-xBoundaries.x, -xBoundaries.y, inter.getValue()), leftBlock.transform.localPosition.y, leftBlock.transform.localPosition.z);
        rightBlock.transform.localPosition = new Vector3(Mathf.Lerp(xBoundaries.x, xBoundaries.y, inter.getValue()), leftBlock.transform.localPosition.y, leftBlock.transform.localPosition.z);


    }
}
