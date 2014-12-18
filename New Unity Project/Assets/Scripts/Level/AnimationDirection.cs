using UnityEngine;
using System.Collections;

public class AnimationDirection : MonoBehaviour {

	private float degreesToRotate; //Gibt an wo hin gedreht werden muss, immer vom Spieler aus aber ohne dessen eigene Drehung (um die eigene Achse) zu berücksichtigen
	public float turnSpeed; //Drehgeschwindigkeit

	//Initialisierung der Variabeln
	void Start()
	{
		degreesToRotate = 0;
	}

	//überprüft die Laufrichtung und passt die blickrichtugn des Spielcharakters an
	void Update ()
	{
		if (PlayerController.moveDirection != Vector3.zero)
		{
			Quaternion targetRotation = transform.localRotation;
			//rechts
			if (Input.GetAxisRaw("Horizontal") == 1)
			{
				degreesToRotate = 270;
				targetRotation = new Quaternion(0, -0.7f, 0, -0.7f);
			}
			//links
			else if (Input.GetAxisRaw("Horizontal") == -1)
			{
				degreesToRotate = 90;
				targetRotation = new Quaternion(0, -0.7f, 0, 0.7f);
			}

			if (Input.GetAxisRaw("Vertical") == 1)
			{
				//hoch
				if (degreesToRotate == 0)
				{
					degreesToRotate = 360;
					targetRotation = new Quaternion(0, 0, 0, -1f);
				}
				//hoch + links
				else if (degreesToRotate == 90)
				{
					degreesToRotate = 45;
					targetRotation = new Quaternion(0, -0.4f, 0, 0.9f);
				}
				//hoch + rechts
				else if (degreesToRotate == 270)
				{
					degreesToRotate = 315;
					targetRotation = new Quaternion(0, -0.4f, 0, -0.9f);
				}
			}
			else if (Input.GetAxisRaw("Vertical") == -1)
			{
				//nach unten
				if (degreesToRotate == 0)
				{
					degreesToRotate = 180;
					targetRotation = new Quaternion(0, -1f, 0, 0);
				}
				//nach unten links
				else if (degreesToRotate == 90)
				{
					degreesToRotate = 135;
					targetRotation = new Quaternion(0, -0.9f, 0, 0.4f);
				}
				//nach unten rechts
				else if (degreesToRotate == 270)
				{
					degreesToRotate = 225;
					targetRotation = new Quaternion(0, -0.9f, 0, -0.4f);
				}
			}
			//Derehung des Modells
			if (targetRotation != transform.localRotation)
			{
				if (PlayerController.returnRoll())
				{
					transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, turnSpeed * Time.deltaTime * 3);
				}
				else
				{
					transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, turnSpeed * Time.deltaTime );
				}
			}
			degreesToRotate = 0;
		}
	}
}
