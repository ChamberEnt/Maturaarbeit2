using UnityEngine;
using System.Collections;

public class OpenDoor : MonoBehaviour {

	//"öfffnet" bei Berührung die Türe, zerstört 
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			if (PlayerController.returnHasKey())
			{
				Destroy(this.GetComponentInParent<MeshCollider>());
				Destroy(this.GetComponentInParent<MeshRenderer>());
			}
		}
	}
}