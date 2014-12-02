using UnityEngine;
using System.Collections;

public class CharacterScaler : MonoBehaviour {
	
	private Transform myTransform;
	private float multiplyer;
	private static float currentMultiplyer;
	private float startMagnitude;

	void Start () {
		myTransform = transform;
		startMagnitude = myTransform.position.magnitude;
		currentMultiplyer = 1;
	}

	void FixedUpdate () {
		multiplyer = myTransform.position.magnitude/startMagnitude;
		if(currentMultiplyer >= multiplyer*1.1 || currentMultiplyer <= multiplyer*0.9)
		{
			Debug.Log ("new currentMultiplyer set: "+multiplyer);
			currentMultiplyer = multiplyer;
			PlayerController.multiplyAll(multiplyer);
		}
	}

	public static float returnMultiplyer()
	{
		return currentMultiplyer;
	}
}
