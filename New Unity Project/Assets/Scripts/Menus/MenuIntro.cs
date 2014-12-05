using UnityEngine;
using System.Collections;

public class MenuIntro : MonoBehaviour {

	//private static bool enemysEnabeled;

	void OnGUI()
	{
		GUI.Label (new Rect(Screen.width/2-75,20,150,30),"Welcome to MAVERICK");

		if (GUI.Button (new Rect(Screen.width/2-75,90,150,30),"Start Level 1"))
		{
			Application.LoadLevel(2);
		}
		if (GUI.Button (new Rect(Screen.width/2-75,140,150,30),"Exploration mode"))
		{
			DontDestroyOnLoad(GameObject.Find("ExplorationMode"));
			Application.LoadLevel(2);
		}
		if (GUI.Button (new Rect(Screen.width/2-75,190,150,30),"Story"))
		{
			Application.LoadLevel(0);
		}
		if (GUI.Button (new Rect(Screen.width/2-75,240,150,30),"Exit"))
		{
			Application.Quit();
		}
	}
}
