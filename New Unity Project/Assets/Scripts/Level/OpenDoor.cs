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
				Debug.Log ("Door open");
				Destroy(this.GetComponentInParent<MeshCollider>());
				Destroy(this.GetComponentInParent<MeshRenderer>());
			}
		}
	}
}
