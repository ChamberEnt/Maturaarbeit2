using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {
	private AudioSource scream;
	private AudioSource piano1;
	private AudioSource piano2;

	void Start ()
	{
		AudioSource[] audioSources = GetComponents<AudioSource>();
		piano1 = audioSources[0];
		piano2 = audioSources[1];
		scream = audioSources[2];
		//time = Time.time;
	
	}

//	void Update ()
//	{
//		if(!scream.isPlaying)
//		{
//			if (Random.value > 0.99f)
//			{
//				time = Time.time - time;
//				scream.Play();
//				time = Time.time;
//			}
//		}
//	}
	public void startScream()
	{
		scream.PlayScheduled(Time.time);
		piano1.Stop();
		piano2.Stop ();
		Debug.Log (scream.isPlaying);
	}
}
