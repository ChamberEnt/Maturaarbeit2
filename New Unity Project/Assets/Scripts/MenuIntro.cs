using UnityEngine;
using System.Collections;

public class MenuIntro : MonoBehaviour {
	
	//int highscore = Highscore.highscore;
	
	void OnGUI()
	{
		GUI.Label (new Rect(20,20,150,50),"Welcome to MAVERICK");

		if (GUI.Button (new Rect(20,90,150,50),"Start Level 1"))
		{
			//Scorecounter.ClearScore();
			Application.LoadLevel(1);
		}

		if (GUI.Button (new Rect(20,160,150,50),"Exit"))
		{
			Application.Quit();
		}
	}
}
