using UnityEngine;
using System.Collections;

public class EndGameScreen : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			if (PlayerController.returnHasKey())
			{
				Debug.Log ("newGroundLevel: "+GameObject.Find("TeleportEnd_006").transform.position.magnitude+15);
				CameraHeight.setHeight(GameObject.Find("TeleportEnd_006").transform.position.magnitude+15);
			}
		}
	}
}
