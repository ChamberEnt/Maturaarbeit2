using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody))]
public class BodyNotPlayer : MonoBehaviour {
	
	private Attractor attractor; //Planet/Level
	public Transform myTransform; //Position + Rotation + Grösse
	private bool isGrounded;

	
	void Awake () {

		rigidbody.useGravity = false;
		rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
		myTransform = this.transform;
		//attractor = GameObject.Find ("Level").GetComponent<Attractor>();
	}
	
	void Update()
	{
		//isGrounded update: (teils aus: http://answers.unity3d.com/questions/155907/basic-movement-walking-on-walls.html)
		Ray ray;
		RaycastHit hit;
		ray = new Ray(myTransform.position, -myTransform.position); // origin, direction of ray
		Physics.Raycast(ray, out hit); // cast ray downwards
		
		//Debug.Log ("hit.distance "+hit.distance);
		Debug.DrawLine (transform.position, hit.point, Color.cyan);
		
		if (hit.distance <= 0.1f)
		{
			isGrounded = true;
			//rigidbody.velocity = Vector3.zero;
			//rigidbody.angularVelocity = Vector3.zero;
			//Debug.Log (""+isGrounded);
		}
		else
		{
			isGrounded = false;
		}
		//Debug.Log (""+hit.distance);
	}
	
	void FixedUpdate () {
		//aus: https://www.youtube.com/watch?v=gHeQ8Hr92P4)
		if (attractor)
		{
			attractor.Attract(myTransform, isGrounded);
		}
	}
	public bool returnIsGrounded()
	{
		return isGrounded;
	}
	public void setAttractor(Attractor newAttractor)
	{
		attractor = newAttractor;
		Debug.Log(""+attractor);
	}
	
}