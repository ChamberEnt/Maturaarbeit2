using UnityEngine;
using System.Collections;

public class MenuGameOver : MonoBehaviour {
	private static int cause = 0;
	private string deathText;

	void OnGUI()
	{
		switch(cause)
		{
		case 0:
			deathText = "you fell from a roof...";
			break;
		case 1:
			deathText = "you where seen by a robot...";
			break;
		default:
			deathText = "you are dead and broke the game...";
			break;
		}

		GUI.Label (new Rect(20,20,150,70),"Don't punch the Screen! But we have to tell you, "+ deathText);

		if (GUI.Button (new Rect(20,110,150,50),"Retry"))
		{
			Application.LoadLevel(2);
		}
		
		if (GUI.Button (new Rect(20,180,150,50),"Menu"))
		{
			Application.LoadLevel(1);
		}
	}

	public static void setCause(int newCause)
	{
		cause = newCause;
	}
}
