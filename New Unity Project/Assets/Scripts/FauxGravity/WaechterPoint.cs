using UnityEngine;
using System.Collections;

public class WaechterPoint : MonoBehaviour {

	private static Vector3 myForward;
	public Vector3 newDirection;
	public GameObject nextPoint;
	private WaechterPoint nextPointScript;
	// Use this for initialization
	void Start () {
		Vector3 gravityUp = transform.position.normalized;
		Vector3 localUp = transform.up;
		Quaternion targetRotation = Quaternion.FromToRotation(localUp,gravityUp) * transform.rotation;
		transform.rotation = Quaternion.Slerp(transform.rotation,targetRotation,50f);

		myForward = transform.TransformDirection(transform.forward);

		nextPointScript = nextPoint.GetComponent<WaechterPoint>();
		//Debug.Log ("Forward: "+myForward);
		
	}
	
	// Update is called once per frame
	void Update () {
		Debug.DrawRay(transform.position, newDirection, Color.black, 0.1f);
	
	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Waechter")
		{
			//Debug.Log ("turnPoint");
			other.gameObject.transform.parent.SendMessage("turn", this, SendMessageOptions.DontRequireReceiver);
		}
	}
	public Vector3 returnPosition()
	{
		return transform.position;
	}
	public WaechterPoint returnNextPoint()
	{
		return nextPointScript;
	}
	public Vector3 returnDirection()
	{
		return newDirection;
	}
}
