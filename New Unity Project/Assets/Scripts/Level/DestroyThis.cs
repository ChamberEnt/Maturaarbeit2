using UnityEngine;
using System.Collections;

public class DestroyThis : MonoBehaviour {
	public GameObject toDestroy;

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player")
		{
			if(PlayerController.returnHasKey())
			{
				Destroy(toDestroy);
			}
			if(this.gameObject.tag == "FogAnpassen")
			{
				Debug.Log ("HEYHOOOO!!");
				RenderSettings.fogEndDistance = 150;
			}
		}
	}
}
