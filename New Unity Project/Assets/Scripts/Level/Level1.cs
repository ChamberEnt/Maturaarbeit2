using UnityEngine;
using System.Collections;

public class Level1 : MonoBehaviour {
	public GameObject waechter;
	public GameObject[] listeWaechterPunkte1;
	public GameObject[] listeWaechterPunkte2;
	public GameObject[] listeWaechterPunkte3;
	public GameObject[] listeWaechterPunkte4;
	public GameObject[] listeWaechterPunkte5;
	public GameObject[] listeWaechterPunkte6;
	public GameObject level;
	private GameObject[] listeWaechter;
	
	void Awake () {
		GameObject[][] listenWaechterPunkte = new GameObject[][]{listeWaechterPunkte1,listeWaechterPunkte2,listeWaechterPunkte3,listeWaechterPunkte4,listeWaechterPunkte5, listeWaechterPunkte6};
		listeWaechter = new GameObject[6];

		for(int i=0; i < listenWaechterPunkte.GetLength(0); i++)
		{
			GameObject newWaechter = (GameObject) Instantiate(waechter, transform.position, transform.rotation);
			newWaechter.GetComponent<BodyNotPlayer>().setAttractor(level.GetComponent<Attractor>());
			newWaechter.GetComponent<WachterMovement2>().setPunkte(listenWaechterPunkte[i]);
			listeWaechter[i] = newWaechter;
		}

//		GameObject waechter1 = (GameObject) Instantiate(waechter, transform.position+ new Vector3(5,55,0), transform.rotation);
//
//		waechter1.GetComponent<BodyNotPlayer>().setAttractor(level.GetComponent<Attractor>());
//		waechter1.GetComponent<WachterMovement2>().setPunkte(listeWaechter1);

	}
}
