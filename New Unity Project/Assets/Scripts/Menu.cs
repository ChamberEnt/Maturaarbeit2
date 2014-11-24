﻿using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {


	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Application.LoadLevel(0);
		}
		if (Input.GetKeyDown (KeyCode.Keypad0))
		{
			EnemyMovement.startBool = true;
		}
	}

	void OnGUI()
	{
		if (EnemyAwareness.CanSeePlayer()) //(EnemyAwareness.CanSeePlayer()) //kann nur funktionieren solange auch ein EnemyAwareness Script exisitiert ansonsten "null reference exeption"
		{
			GUI.Label(new Rect ((Screen.width - 160),10,150,50),"Seen by Enemy: true");
		}
		else
		{
			GUI.Label(new Rect ((Screen.width - 160),10,150,50),"Seen by Enemy: false");
		}
		GUI.Label (new Rect ((Screen.width - 160),30,150,50),"Press Shift to run");
		//GUI.Label (new Rect(10,10,150,50), "Press 0 to start enemy movement");
	}
}
