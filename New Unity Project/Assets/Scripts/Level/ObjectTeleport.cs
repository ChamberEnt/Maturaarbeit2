using UnityEngine;
using System.Collections;

public class ObjectTeleport : MonoBehaviour {

	private Transform myTransform; //Position + Rotation + Grösse

	//Iniitialisierung
	void Start ()
	{
		myTransform = transform;
	}

	//wird von DoorTeleporter bei Berührung ausgeführt
	void Teleport(GameObject newPos)
	{
		myTransform.position = newPos.transform.position;
	}
}
