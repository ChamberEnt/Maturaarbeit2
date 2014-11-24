using UnityEngine;
using System.Collections;

public class EnemyAwareness2 : MonoBehaviour {
	
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			other.gameObject.SendMessage("GameOver", 1, SendMessageOptions.DontRequireReceiver);
		}
	}
}
