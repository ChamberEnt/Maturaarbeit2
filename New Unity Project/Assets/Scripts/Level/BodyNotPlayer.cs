using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody))]
public class BodyNotPlayer : MonoBehaviour {
	
	private Attractor attractor; //Planet/Level
	private Transform myTransform; //Position + Rotation + Grösse
	private bool isGrounded;

	
	void Awake () {

		rigidbody.useGravity = false;
		rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
		myTransform = this.transform;
		//attractor = GameObject.Find ("Level").GetComponent<Attractor>();
	}
	
	void FixedUpdate () {
		//aus: https://www.youtube.com/watch?v=gHeQ8Hr92P4)
		if (attractor)
		{
			attractor.Attract(myTransform, isGrounded);
		}
	}
	public void setIsGrounded(bool newIsGrounded)
	{
		isGrounded = newIsGrounded;
	}
	public void setAttractor(Attractor newAttractor)
	{
		attractor = newAttractor;
	}
	
}