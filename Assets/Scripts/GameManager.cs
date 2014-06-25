using UnityEngine;
using System.Collections;
using KiiCorp.Cloud.Storage;
using KiiCorp.Cloud.Analytics;
using System;

public class GameManager : MonoBehaviour {
	public static bool gameOver=false;
	public static bool gameStart=false;
	public static int score=0;
	public static float startTime = 0;
	public static float appStartTime = 0;
	public static int clickTimes = 0;
	public static int totalGames = 0;
	// Use this for initialization
	void Start () {
		score=0;
		gameOver = false;
		gameStart = false;
		if (appStartTime < 1) {
			appStartTime = Time.time;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (!gameStart) {

				if(Input.GetMouseButtonDown(0)){
				//At the game start time, clear clickTimes and record start time
				//And increase the total games count
					startTime = Time.time;
					clickTimes = 0;
					totalGames++;
					gameStart=true;
			}
				}
		if (gameStart)
				if (Input.GetKeyUp (KeyCode.Escape)) {
						saveDataToKiiCloud ();
						Application.Quit ();
				}
	}

	void saveDataToKiiCloud ()
	{
		
		KiiObject obj = Kii.Bucket("QuitGame").NewKiiObject();
		float appTime = Time.time - appStartTime;
		obj ["totalGames"] = totalGames;
		obj ["appTime"] = appTime;
		obj["deviceID"] = SystemInfo.deviceUniqueIdentifier;
		
		// Save the object
		obj.Save((KiiObject savedObj, Exception e) => {
			if (e != null)
			{
				// Handle error
				string message = "Failed to upload QuitGame data " + e.ToString();
				Debug.Log (message);
				return;
			}
			Debug.Log ("QuitGame save succeeded");
		});
	}
}
