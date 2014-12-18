using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody))]
public class BodyNotPlayer : MonoBehaviour {
	
	private Attractor attractor; //Attractor Skript des Level, wird bei der Initialisierung durch das Level1 Skript gesetzt
	private Transform myTransform; //Position + Rotation + Grösse
	private bool isGrounded; //Ob der Gegner sich am Boden befindet, wird von Waechter Movement gesetzt

	//Initialisierung
	void Awake ()
	{
		rigidbody.useGravity = false;
		rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
		myTransform = this.transform;
	}

	//ausführung des Attract() Methode des Attractor Skripts
	void FixedUpdate ()
	{
		//aus: https://www.youtube.com/watch?v=gHeQ8Hr92P4)
		if (attractor)
		{
			attractor.Attract(myTransform, isGrounded);
		}
	}

	//Settermethode für isGrounded, wird von WaechterMovement verwendet
	public void setIsGrounded(bool newIsGrounded)
	{
		isGrounded = newIsGrounded;
	}

	//Settermethode für den Attractor, wird bei der Initialisierung durch das Level1 Skript verwendet
	public void setAttractor(Attractor newAttractor)
	{
		attractor = newAttractor;
	}
	
}