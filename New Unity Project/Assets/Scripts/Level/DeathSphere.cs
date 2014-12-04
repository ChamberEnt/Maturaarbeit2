using UnityEngine;
using System.Collections;

public class DeathSphere : MonoBehaviour {
	private Collider player;

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			player = other;
			GameObject.Find("Level").GetComponent<EindunkelnScript>().darken();
			StartCoroutine(GameOverTimer());
		}
	}
	IEnumerator GameOverTimer()
	{
		yield return new WaitForSeconds(3);
		player.gameObject.SendMessage("GameOver", 0, SendMessageOptions.DontRequireReceiver);
	}
}
