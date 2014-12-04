using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody))]
public class Body : MonoBehaviour {
	
	public Attractor attractor; //Planet/Level
	public static Transform myTransform; //Position + Rotation + Grösse
	
	void Start () {
		rigidbody.useGravity = false;
		rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
		myTransform = transform;
	}

	void FixedUpdate () {
		//aus: https://www.youtube.com/watch?v=gHeQ8Hr92P4)
		if (attractor)
		{
			attractor.Attract(myTransform, PlayerController.isGrounded);
		}
	}
	
}