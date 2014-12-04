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
	private static bool canSeePlayer;
	
	void OnGUI()
	{
		GUI.Label (new Rect ((Screen.width - 160),30,150,50),"Press Shift to roll");
	}
	
	void Awake () {
		GameObject[][] listenWaechterPunkte = new GameObject[][]{listeWaechterPunkte1,listeWaechterPunkte2,listeWaechterPunkte3,listeWaechterPunkte4,listeWaechterPunkte5, listeWaechterPunkte6};
		//evt. statt 6 listenWaechterPunkte.GetLength(x) x = dimension 0 oder 1?
		listeWaechter = new GameObject[6];

		for(int i=0; i < listenWaechterPunkte.GetLength(0); i++)
		{
			GameObject newWaechter = (GameObject) Instantiate(waechter, transform.position, transform.rotation);
			newWaechter.GetComponent<BodyNotPlayer>().setAttractor(level.GetComponent<Attractor>());
			newWaechter.GetComponent<WaechterMovement2>().setPunkte(listenWaechterPunkte[i]);
			listeWaechter[i] = newWaechter;
		}
	}

	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Application.LoadLevel(0);
		}
		for(int i=0; i < listeWaechter.GetLength(0); i++)
		{
			listeWaechter[i].GetComponent<BodyNotPlayer>().setIsGrounded(listeWaechter[i].GetComponent<WaechterMovement2>().returnIsGrounded());
		}
		if (canSeePlayer)
		{
			GameOver (1);
		}
		canSeePlayer = false;
	}
	public static void setCanSeePlayer(bool newCanSeePlayer)
	{
		canSeePlayer = newCanSeePlayer;
	}

	void GameOver(int cause)
	{
		MenuGameOver.setCause(cause);
		Application.LoadLevel(3);
	}
}
