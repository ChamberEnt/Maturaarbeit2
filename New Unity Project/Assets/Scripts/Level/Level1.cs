using UnityEngine;
using System.Collections;

public class Level1 : MonoBehaviour {
	public GameObject waechter;
	public GameObject[] listeWaechterPunkte0;
	public GameObject[] listeWaechterPunkte1;
	public GameObject[] listeWaechterPunkte2;
	public GameObject[] listeWaechterPunkte3;
	public GameObject[] listeWaechterPunkte4;
	public GameObject[] listeWaechterPunkte5;
	public GameObject[] listeWaechterPunkte6;
	public GameObject[] listeWaechterPunkte7;
	public GameObject[] listeWaechterPunkte8;
	public GameObject[] listeWaechterPunkte9;
	public GameObject level;
	public GameObject kamera;
	public GameObject[] kameraPositionen;
	private GameObject[] listeKameras;
	private GameObject[] listeWaechter;
	private static bool canSeePlayer;
	private static bool first;
	private static bool complete;
	private static bool enemysEnabeled;
	
	void OnGUI()
	{
		if(complete)
		{
			GUI.Label (new Rect ((Screen.width/2-75),Screen.width/2-25,150,50),"Level Complete!");
		}
	}
	
	void Awake () {
		first = true;
		if(GameObject.Find("ExplorationMode"))
		{
			enemysEnabeled = false;
		}
		else
		{
			enemysEnabeled = true;
		}
		GameObject[][] listenWaechterPunkte = new GameObject[][]{listeWaechterPunkte0,listeWaechterPunkte1,listeWaechterPunkte2,listeWaechterPunkte3,listeWaechterPunkte4,listeWaechterPunkte5, listeWaechterPunkte6, listeWaechterPunkte7, listeWaechterPunkte8, listeWaechterPunkte9};
		//evt. statt 6 listenWaechterPunkte.GetLength(x) x = dimension 0 oder 1?
		listeWaechter = new GameObject[10];
		listeKameras = new GameObject[kameraPositionen.GetLength(0)];

		for(int i=0; i < listenWaechterPunkte.GetLength(0); i++)
		{
			GameObject newWaechter = (GameObject) Instantiate(waechter, transform.position, transform.rotation);
			newWaechter.GetComponent<BodyNotPlayer>().setAttractor(level.GetComponent<Attractor>());
			newWaechter.GetComponent<WaechterMovement2>().setPunkte(listenWaechterPunkte[i]);
			listeWaechter[i] = newWaechter;
		}

		for(int i=0; i < kameraPositionen.GetLength(0); i++)
		{
			GameObject newKamera = (GameObject) Instantiate(kamera, kameraPositionen[i].transform.position, kameraPositionen[i].transform.rotation);
			//newKamera.GetComponentInChildren<KameraAusrichter>().kameraAusrichten1(i);
			listeKameras[i] = newKamera;
		}
		complete = false;
	}

	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Application.LoadLevel(1);
		}
		for(int i=0; i < listeWaechter.GetLength(0); i++)
		{
			listeWaechter[i].GetComponent<BodyNotPlayer>().setIsGrounded(listeWaechter[i].GetComponent<WaechterMovement2>().returnIsGrounded());
		}
		if (canSeePlayer)
		{
			if (first)
			{
				GameObject.Find("Level").GetComponent<EindunkelnScript>().darken ();
				GameObject.Find("Player").GetComponent<SoundManager>().startScream();
				//for(){}
				//Gameobject.light.color = Color.red;
				StartCoroutine(GameOverTimer());
			}
		}
		canSeePlayer = false;

		if(EindunkelnScript.returnDone())
		{
			Application.LoadLevel(1);
		}
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
		Application.LoadLevel(2);
	}

	public static void levelDone()
	{
		GameObject.Find("Level").GetComponent<EindunkelnScript>().darken();
		complete = true;
	}

	public GameObject returnListeWaechterElement(int i)
	{
		return listeWaechter[i];
	}

	public static bool returnEnemysEnabeled()
	{
		return enemysEnabeled;
	}

	public static void setEnemysEnabeled(bool newEnemysEnabeled)
	{
		enemysEnabeled = newEnemysEnabeled;
	}
}
