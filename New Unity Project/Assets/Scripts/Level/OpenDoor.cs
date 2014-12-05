using UnityEngine;
using System.Collections;

public class OpenDoor : MonoBehaviour {
	
	void Start () {
	
	}
	void OnTriggerStay(Collider other) {
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
