using UnityEngine;
using System.Collections;

public class CharacterScaler : MonoBehaviour {
	
	private Transform myTransform; //Position + Rotation + Grösse
	private static float multiplyer; //Multiplikator an dem die Skalierung des Spielcharakters angepasst wird
	private float startMagnitude; //Startwert für myTransform.position.magnitude

	//Initialisierung
	void Start ()
	{
		myTransform = transform;
		startMagnitude = myTransform.position.magnitude;
		multiplyer = 1;
	}

	//Anpassung der Skalierung
	void FixedUpdate ()
	{
		float xyz = myTransform.position.magnitude/startMagnitude;
		myTransform.localScale = new Vector3(xyz, 1, xyz);
	}

	//Gibt den momentanen Multiplikator zurück
	public static float returnMultiplyer()
	{
		return multiplyer;
	}
}