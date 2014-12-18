using UnityEngine;
using System.Collections;

public class CameraHeight : MonoBehaviour {

	private static float groundLevel; //Abstand zwischen Kamera und Punkt (0/0/0), soll sich nicht ändern bis am schluss des Levels
	private static Transform myTransform; //Position + Rotation + Grösse

	//Initialisierung
	void Start ()
	{
		myTransform = transform;
		groundLevel = myTransform.position.magnitude;
	}

	//Passt die Höhe, die durch die Child-Parent Beziehung mit dem Spielcharakter verändert wird, an
	void Update ()
	{
		myTransform.localPosition = new Vector3(0, groundLevel-PlayerController.returnMyPosition().magnitude, 0);
	}

	//Passt die Höhe der Kamera an, wird am ende des Levels verwendet um den Spielcharakter noch sehen zu können.
	public static void setHeight(float newGroundlevel)
	{
		groundLevel = newGroundlevel;
	}
}