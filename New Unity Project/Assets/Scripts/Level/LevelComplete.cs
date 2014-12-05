using UnityEngine;
using System.Collections;

public class LevelComplete : MonoBehaviour {
	void OnTriggerEnter (Collider other) 
	{
		if (other.gameObject.tag == "Player")
		{
			Level1.levelDone();
		}
	}
}
