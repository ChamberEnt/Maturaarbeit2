using UnityEngine;
using System.Collections;

public class ObjectTeleport : MonoBehaviour {
	private Transform myTransform;

	void Start ()
	{
		myTransform = transform;
	}

	void Teleport(GameObject newPos)
	{
		myTransform.position = newPos.transform.position;
	}
}
