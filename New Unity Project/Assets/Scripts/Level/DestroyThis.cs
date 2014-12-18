using UnityEngine;
using System.Collections;

public class DestroyThis : MonoBehaviour {

	public GameObject toDestroy; //zu zerstörendes GameObject

	//zerstört bei Zusammenstoss mit dem Collider des GameObjects welchem das Skript hinzugefügt wurde das zu zerstörende GameObject
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			if(PlayerController.returnHasKey())
			{
				Destroy(toDestroy);
			}
			//Passt den Nebel in der Szene an um den Spielcharakter auch weiter unten noch zu sehen
			if(this.gameObject.tag == "FogAnpassen")
			{
				RenderSettings.fogEndDistance = 150;
			}
		}
	}
}
