using UnityEngine;
using System.Collections;

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
