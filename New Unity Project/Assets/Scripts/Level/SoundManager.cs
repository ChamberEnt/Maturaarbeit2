using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

	private AudioSource scream;
	float time;
	void Start () {
		AudioSource[] audioSources = GetComponents<AudioSource>();
		scream = audioSources[2];
		time = Time.time;
	
	}

	// Update is called once per frame
	void Update () {
		//Debug.Log (""+Random.value);
		if(!scream.isPlaying)
		{
			if (Random.value > 0.99f)
			{
				time = Time.time - time;
				//Debug.Log (""+time);
				scream.Play();
				time = Time.time;
			}
		}
	}
}
