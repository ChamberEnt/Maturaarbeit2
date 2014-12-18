using UnityEngine;
using System.Collections;

public class DeathSphere : MonoBehaviour {

	//Bei zusammenstoss mit dem Spielcharakter wird eingedunkelt (EindunkelnScript.darken()) und das Level nach 3 Sekunden neu geladen (Level.GameOver())
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			GameObject.Find("Level").GetComponent<EindunkelnScript>().darken();
			StartCoroutine(GameOverTimer());
		}
	}

	IEnumerator GameOverTimer()
	{
		yield return new WaitForSeconds(3);
		GameObject.Find("Level").SendMessage("GameOver", 0, SendMessageOptions.DontRequireReceiver);
	}
}
