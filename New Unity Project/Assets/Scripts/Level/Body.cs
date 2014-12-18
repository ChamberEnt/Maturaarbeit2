using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody))]
public class Body : MonoBehaviour {
	
	public Attractor attractor; //Das Attractor Skript des Levels
	public static Transform myTransform; //Position + Rotation + Grösse

	//Initialisierung
	void Start ()
	{
		rigidbody.useGravity = false;
		rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
		myTransform = transform;
	}

	//ausführung des Attract() Methode des Attractor Skripts
	void FixedUpdate ()
	{
		//aus: https://www.youtube.com/watch?v=gHeQ8Hr92P4)
		if (attractor)
		{
			attractor.Attract(myTransform, PlayerController.isGrounded);
		}
	}
}