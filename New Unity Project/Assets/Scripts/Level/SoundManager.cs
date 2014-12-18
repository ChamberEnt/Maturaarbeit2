using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

	private AudioSource scream; //geräusch der Wächter bei Entdeckeung
	private AudioSource piano1; //Tonspur 1
	private AudioSource piano2; //Tonspur 2

	//Initialisierung
	void Start ()
	{
		AudioSource[] audioSources = GetComponents<AudioSource>();
		piano1 = audioSources[0];
		piano2 = audioSources[1];
		scream = audioSources[2];
	}

	//stoppt die beiden Tonspuren und löst den scream aus
	public void startScream()
	{
		scream.PlayScheduled(Time.time);
		piano1.Stop();
		piano2.Stop ();
		Debug.Log (scream.isPlaying);
	}
}
