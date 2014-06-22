using UnityEngine;
using System.Collections;
using KiiCorp.Cloud.Storage;
using System;

public class GameManager : MonoBehaviour {
	public static bool gameOver=false;
	public static bool gameStart=false;
	public static int score=0;
	public static float startTime = 0;
	public static int clickTimes = 0;
	// Use this for initialization
	void Start () {
		score=0;
		gameOver = false;
		gameStart = false;
		if (KiiUser.CurrentUser == null) {
						KiiUser.LogIn ("evan", "123456", (KiiUser user, Exception e) => {
								if (e != null) {
										// Handle error
										string message = "Failed to login: " + e.ToString ();
										Debug.Log (message);
										return;
								}
								Debug.Log ("Login successfully");
				});
		}

	}
	
	// Update is called once per frame
	void Update () {
		if (!gameStart) {

				if(Input.GetMouseButtonDown(0)){
					startTime = Time.time;
					clickTimes = 0;
					gameStart=true;
			}
				}
		if (gameStart)
		if (Input.GetKeyUp (KeyCode.Escape))
						Application.Quit();
	}
}
