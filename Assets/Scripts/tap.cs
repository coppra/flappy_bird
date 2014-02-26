using UnityEngine;
using System.Collections;

public class tap : MonoBehaviour {

	// Use this for initialization
	void Start () {
		renderer.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (GameManager.gameStart)
						renderer.enabled = false;
	
	}
}
