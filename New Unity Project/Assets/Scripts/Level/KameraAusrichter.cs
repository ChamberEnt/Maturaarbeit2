using UnityEngine;
using System.Collections;

public class KameraAusrichter : MonoBehaviour {

	void Start () {

		Quaternion targetRotation = Quaternion.FromToRotation(transform.up,transform.position) * transform.rotation;
		transform.rotation = Quaternion.Slerp(transform.rotation,targetRotation,50);
	}

	public void kameraAusrichten1(int kamera)
	{
		Debug.Log ("kamera ausgerichtet: "+kamera);
		switch (kamera)
		{
		case 0:
			Debug.Log (transform.forward);
			Debug.Log (transform.right);
			Debug.Log (transform.up);
			//transform.RotateAround(transform.position, transform.right, 180);
			//transform.RotateAround(transform.position, transform.position, 180);
			break;
		case 1:
			transform.RotateAround(transform.position, -transform.right, 90);
			break;
		default:
			Debug.Log("Kamera nicht gefunden");
			break;
		}
	}
}
