using UnityEngine;
using System.Collections;

public class CharacterScaler : MonoBehaviour {
	
	private Transform myTransform;
	private float multiplyer;
	private float currentMultiplyer;


	void Start () {
		myTransform = transform;
		currentMultiplyer = 1;
	}
	
	// Update is called once per frame
	void Update () {
		multiplyer = myTransform.position.magnitude;
		multiplyer = multiplyer/48.7f;

		if(currentMultiplyer >= multiplyer*1.1 || currentMultiplyer <= multiplyer*0.9)
		{
			Debug.Log ("new currentMultiplyer set: "+multiplyer);
			currentMultiplyer = multiplyer;
			//PlayerControllerFauxGravity player = new PlayerControllerFauxGravity();
			//player.multiplyAll(multiplyer);
			PlayerControllerFauxGravity.multiplyAll(multiplyer);
		}
	}
}
