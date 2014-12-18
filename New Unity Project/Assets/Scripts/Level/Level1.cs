using UnityEngine;
using System.Collections;

public class Level1 : MonoBehaviour {

	public GameObject waechter; //Prefab Wächter
	public GameObject[] listeWaechterPunkte0; //Alle Patrouillenkordinaten der jeweiligen Wächter1-9
	public GameObject[] listeWaechterPunkte1;
	public GameObject[] listeWaechterPunkte2;
	public GameObject[] listeWaechterPunkte3;
	public GameObject[] listeWaechterPunkte4;
	public GameObject[] listeWaechterPunkte5;
	public GameObject[] listeWaechterPunkte6;
	public GameObject[] listeWaechterPunkte7;
	public GameObject[] listeWaechterPunkte8;
	public GameObject[] listeWaechterPunkte9;
	public GameObject level; //level
	public GameObject kamera; //Prefab Kamera
	public GameObject[] kameraPositionen; //Alle Kamera Positionen
	private GameObject[] listeKameras; //Array mit allen Kameras als GameObjects
	private GameObject[] listeWaechter; //Array mit allen Wächtern als GameObjects
	private static bool canSeePlayer; //ob der Spieler gesehen wird
	private static bool first;
	private static bool complete;
	private static bool enemysEnabeled;

	//Initialisierung der Wächter und Kameras und der Parameter für das Level1 Skript selbst
	void Awake ()
	{
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
			listeKameras[i] = newKamera;
		}
		complete = false;
	}

	//Ladet bei Escape das Menü
	//übergibt dem BodyNotPlayer Skript des jeweiligen Wächters den isGrounded Parameter des WaechterMovement2 Skripts
	//überprüft ob der Spieler gesehen wird, ladet das Level neu bei true und nachdem eingedunkelt wurde
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
				StartCoroutine(GameOverTimer());
			}
		}
		canSeePlayer = false;

		if(EindunkelnScript.returnDone())
		{
			Application.LoadLevel(1);
		}
	}

	//Timer um das Neuladen des Levels zu verzögern und zeit für das Eindunkeln zu geben
	IEnumerator GameOverTimer()
	{
		first = false;
		yield return new WaitForSeconds(3);
		GameOver(1);
	}

	//Level Complete! anzeige bei beendung eds Spiels
	void OnGUI()
	{
		if(complete)
		{
			GUI.Label (new Rect ((Screen.width/2-75),Screen.width/2-25,150,50),"Level Complete!");
		}
	}

	//ladet das Level neu
	void GameOver(int cause)
	{
		Application.LoadLevel(2);
	}

	//setzt canSeePlayer
	public static void setCanSeePlayer(bool newCanSeePlayer)
	{
		canSeePlayer = newCanSeePlayer;
	}

	//startet das Eindunkeln und die "Level Complete!" Anzeige
	public static void levelDone()
	{
		GameObject.Find("Level").GetComponent<EindunkelnScript>().darken();
		complete = true;
	}

	//gibt das Array mit den Wächtern zurück
	public GameObject returnListeWaechterElement(int i)
	{
		return listeWaechter[i];
	}

	//gibt zurück ob die Gegner "eingeschaltet" sind (für Exploration Mode)
	public static bool returnEnemysEnabeled()
	{
		return enemysEnabeled;
	}

	//setzt ob die Gegner "eingeschaltet" sind (für Exploration Mode)
	public static void setEnemysEnabeled(bool newEnemysEnabeled)
	{
		enemysEnabeled = newEnemysEnabeled;
	}
}
