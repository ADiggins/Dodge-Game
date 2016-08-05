using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GamePlayControls : MonoBehaviour {

    Text scoreText;

	// Use this for initialization
	void Start () {
        scoreText = GameObject.Find(transform.name + "/Score/Text").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        scoreText.text = HighScoreSystem.GetScore().ToString();
	
	}
}
