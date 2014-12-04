using UnityEngine;
using System.Collections;

public class DoorTeleporter : MonoBehaviour {
	public GameObject newPos;

	void OnTriggerEnter (Collider other) 
	{
		if (other.gameObject.tag == "Player")
		{
			other.gameObject.SendMessage("Teleport", newPos, SendMessageOptions.DontRequireReceiver);
			//eventuell noch rotation des Charakters anpassen, dass er "aus" der Türe kommt und nicht einfach "bei" der Türe steht.
		}
	}
}
