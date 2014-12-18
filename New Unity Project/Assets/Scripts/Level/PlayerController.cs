using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public static float moveSpeed; //Bewegungsgeschwindigkeit
	private static float beginMoveSpeed;
	public static Vector3 moveDirection; //Laufrichtung (vom Spieler aus gesehen, ohne Drehung)
	private static Transform myTransform; //Position + Rotation + Grösse
	private static Vector3 beginMyScale; //Anfangsskalierung des Spielcharakters
	private static float deltaGround; //Gibt an wie weit der abstand zwischen Boden und Objekt sein kann ohne das das Objekt nicht am Boden steht, wichtig bei schrägen Flächen
	private static float beginDeltaGround; //Anfangsdistanz vom Charakter zum Boden
	public static bool isGrounded; //ob das Objekt den Boden berührt
	private static bool jump; //ob leertaste gedrückt wird/gesprollgen wird
	public static float jumpPower; //stärke des sprollgs/höhe
	private static bool jumping; //ob gesprollgen wird, gebraucht um Spring animation zu starten
	private static bool walking; //ob gelaufen wird
	private static float groundLevel; //Auf welche höhe die Kamera eingestellt ist
	private static bool roll; //ob shift gedrückt wird/gerannt wird
	private static bool hasKey; //ob der Schlüssel bereits aufgehoben wurde

	//Initialisierung
	void Start () {
		myTransform = transform;
		jump = false;
		jumping = false;
		walking = false;
		hasKey = false;

		beginMyScale = new Vector3(1,1,1);
		deltaGround = 1.1f;
		beginDeltaGround = 1.1f;
		moveSpeed = 1.5f;
		beginMoveSpeed = 1.5f;
		jumpPower = 200;
	}
	
	//überprüft die Eingaben der Pfeiltasten, Shift und Leertaste
	void Update() {
		moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"),0,Input.GetAxisRaw("Vertical")).normalized;
		if (moveDirection == Vector3.zero)
		{
			walking = false;
		}
		else 
		{
			walking = true;
		}
		
		roll = Input.GetKey(KeyCode.LeftShift);

		if (Input.GetButtonDown("Jump"))
		{
			if (isGrounded)
			{
				jump = true;
			}
		}
	}

	//überprüft ob der Boden berührt wird (isGrounded Update) und setztz isGrounded dem entsprechend
	//überprüft ob gesprungen wird (leertaste/jump) und führt demnach den Sprung aus oder nicht
	void FixedUpdate() {
		//isGrounded update: (teils aus: http://answers.unity3d.com/questions/155907/basic-movement-walking-on-walls.html)
		Ray ray;
		RaycastHit hit;
		ray = new Ray(myTransform.position, -myTransform.position); // direction of ray
		Physics.Raycast(ray, out hit); // cast ray downwards

		Debug.DrawLine (transform.position, hit.point, Color.cyan);
		
		if (hit.distance <= deltaGround)
		{
			isGrounded = true;
			groundLevel = myTransform.position.magnitude;
		}
		else
		{
			isGrounded = false;
		}

		if (moveDirection == Vector3.zero && isGrounded)
		{
			setVelocityToZero();
		}
		else
		{
			// aus: https://www.youtube.com/watch?v=gHeQ8Hr92P4)
			if (roll)
			{
				myTransform.position += transform.TransformDirection(moveDirection)*moveSpeed*Time.deltaTime*7;
			}
			else
			{
				myTransform.position += transform.TransformDirection(moveDirection)*moveSpeed*Time.deltaTime;
			}
		}
		
		if (jump)
		{
			if(roll)
			{
				rigidbody.AddForce(myTransform.position.normalized * jumpPower * 5);
			}
			else
			{
				rigidbody.AddForce(myTransform.position.normalized * jumpPower);
			}
			jumping = true;
			jump = false;
		}
	}

	//gibt den moveDirection Vektor zurück
	public static Vector3 returnMoveDirection()
	{
		return moveDirection;
	}

	//gibt jumping zurück
	public static bool returnJumping()
	{
		return jumping;
	}

	//setzt jumpin neu
	public static void setJumping (bool newJumping)
	{
		jumping = newJumping;
	}

	//gibt roll zurück
	public static bool returnRoll()
	{
		return roll;
	}

	//für Anpassung der Grösse des Charakters
	public static void multiplyAll(float multiplyer)
	{
		myTransform.localScale = beginMyScale;
		moveSpeed = beginMoveSpeed*multiplyer;
		deltaGround = beginDeltaGround*multiplyer;
		jumpPower = jumpPower*multiplyer;
	}

	//gibt groundLevel zurück
	public static float returnGroundLevel()
	{
		return groundLevel;
	}

	//gibt Position zurück
	public static Vector3 returnMyPosition()
	{
		return myTransform.position;
	}

	//gibt walking zurück
	public static bool returnWalking()
	{
		return walking;
	}

	//setzt deltaGround neu
	public static void setDeltaGround(float newDeltaGround)
	{
		deltaGround = newDeltaGround;
	}

	//setzt hasKey neu, bei aufnehmen des Schlüssels auf true
	public static void setHasKey(bool newHasKey)
	{
		hasKey = newHasKey;
	}

	//return hasKey
	public static bool returnHasKey()
	{
		return hasKey;
	}

	//stoppt den Charakter
	public void setVelocityToZero()
	{
		rigidbody.velocity = Vector3.zero;
		rigidbody.angularVelocity = Vector3.zero;
	}
}
