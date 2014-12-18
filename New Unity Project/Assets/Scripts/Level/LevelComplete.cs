using UnityEngine;
using System.Collections;

public class LevelComplete : MonoBehaviour {

	//beendet bei berührung das Level über das Level1 Skript mit der Methode levelDone()
	void OnTriggerEnter (Collider other) 
	{
		if (other.gameObject.tag == "Player")
		{
			Level1.levelDone();
		}
	}
}
