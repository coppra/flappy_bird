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
	public static int clickTimes = 0;
	public static int totalGames = 0;
	// Use this for initialization
	void Start () {
		score=0;
		gameOver = false;
		gameStart = false;
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
						
						Application.Quit ();
				}
	}

	void saveDataToKiiCloud ()
	{
		KiiEvent ev = KiiAnalytics.NewEvent("QuitGame");
		ev["totalGames"] = totalGames;
		ev["deviceID"] = SystemInfo.deviceUniqueIdentifier;
		KiiAnalytics.Upload((Exception e) => {
			if (e != null)
			{
				string message = "Failed to upload events " + e.ToString();
				Debug.Log (message);
				return;
			}  
			Debug.Log ("event upload succeeded");
		}, ev);
		KiiObject obj = Kii.Bucket("QuitGame").NewKiiObject();
		
		obj ["totalGames"] = totalGames;
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
