using UnityEngine;
using System.Collections;

public class EndGameScreen : MonoBehaviour {

	//Setztz bei Berührund des Spielcharakters die Höhe der Kamera 15 höher als die Position des Spielcharakters, wird am ende des Levels verwendet
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			if (PlayerController.returnHasKey())
			{
				CameraHeight.setHeight(GameObject.Find("TeleportEnd_006").transform.position.magnitude+15);
			}
		}
	}
}
