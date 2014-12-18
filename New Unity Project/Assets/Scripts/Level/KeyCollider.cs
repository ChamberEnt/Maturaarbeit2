using UnityEngine;
using System.Collections;

public class KeyCollider : MonoBehaviour {

	//Zerstört bei berührung des Spielers den Schlüssel und im PlayerController wird hasKey auf true gesetzt
	void OnTriggerEnter (Collider other) 
	{
		if (other.gameObject.tag == "Player")
		{
			GameObject level = GameObject.Find ("Level");
			level.GetComponent<Level1>().returnListeWaechterElement(0).transform.RotateAround(level.GetComponent<Level1>().returnListeWaechterElement(0).transform.position, level.GetComponent<Level1>().returnListeWaechterElement(0).transform.position, 180);
			PlayerController.setHasKey(true);
			Destroy(this.gameObject);
		}
	}
}
