using UnityEngine;
using System.Collections;

public class DoorTeleporter : MonoBehaviour {

	public GameObject newPos; //endposition des Teleporters

	//Teleport (ObjectTeleport.Teleport) bei Berührung des Spielers
	void OnTriggerEnter (Collider other) 
	{
		if (other.gameObject.tag == "Player")
		{
			other.gameObject.SendMessage("Teleport", newPos, SendMessageOptions.DontRequireReceiver);
			//Idee: eventuell noch rotation des Charakters anpassen, dass er "aus" der Türe kommt und nicht einfach "bei" der Türe steht.
		}
	}
}
