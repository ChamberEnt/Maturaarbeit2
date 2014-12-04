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
	public GameObject kamera;
	public GameObject[] kameraPositionen;
	private GameObject[] listeKameras;
	private GameObject[] listeWaechter;
	private static bool canSeePlayer;
	private bool first;
	
	void OnGUI()
	{
		GUI.Label (new Rect ((Screen.width - 160),30,150,50),"Press Shift to roll");
	}
	
	void Awake () {
		first = true;
		GameObject[][] listenWaechterPunkte = new GameObject[][]{listeWaechterPunkte1,listeWaechterPunkte2,listeWaechterPunkte3,listeWaechterPunkte4,listeWaechterPunkte5, listeWaechterPunkte6};
		//evt. statt 6 listenWaechterPunkte.GetLength(x) x = dimension 0 oder 1?
		listeWaechter = new GameObject[6];
		listeKameras = new GameObject[kameraPositionen.GetLength(0)];

		for(int i=0; i < listenWaechterPunkte.GetLength(0); i++)
		{
			GameObject newWaechter = (GameObject) Instantiate(waechter, transform.position, transform.rotation);
			newWaechter.GetComponent<BodyNotPlayer>().setAttractor(level.GetComponent<Attractor>());
			newWaechter.GetComponent<WaechterMovement2>().setPunkte(listenWaechterPunkte[i]);
			listeWaechter[i] = newWaechter;
		}
		/*
		for(int i=0; i < kameraPositionen.GetLength(0); i++)
		{
			GameObject newKamera = (GameObject) Instantiate(kamera, kameraPositionen[i].transform.position, kameraPositionen[i].transform.rotation);
			listeKameras[i] = newKamera;
		}
		*/
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
			if (first)
			{
				GameObject.Find("Level").GetComponent<EindunkelnScript>().darken();
				StartCoroutine(GameOverTimer());
			}
			//GameOver (1);
		}
		canSeePlayer = false;
	}
	public static void setCanSeePlayer(bool newCanSeePlayer)
	{
		canSeePlayer = newCanSeePlayer;
	}
	IEnumerator GameOverTimer()
	{
		first = false;
		yield return new WaitForSeconds(3);
		GameOver(1);
	}
	void GameOver(int cause)
	{
		MenuGameOver.setCause(cause);
		Application.LoadLevel(3);
	}
}
