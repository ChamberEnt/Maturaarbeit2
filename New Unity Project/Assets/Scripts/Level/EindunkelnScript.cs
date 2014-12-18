using UnityEngine;
using System.Collections;

public class EindunkelnScript : MonoBehaviour {

	private float speed; //geschwindigkeit mir der eingedunkelt wird
	private bool eindunkeln; //ob Eingedunkelt wird
	private static bool done; //ob das Eindunkeln beendet wurde

	//Initialisierung
	void Start()
	{
		speed = 5;
		eindunkeln = false;
		done = false;
	}

	//Führt bei (eindunkeln == true) das Eindunkeln aus
	void Update()
	{
		if (eindunkeln)
		{
			RenderSettings.fogStartDistance = RenderSettings.fogStartDistance - Time.deltaTime*speed*5;
			RenderSettings.fogEndDistance = RenderSettings.fogEndDistance - Time.deltaTime*speed;
		}
	}

	//Timer für das Ausführen des Eindunkelns, sobald abgelaufen done = true
	IEnumerator darkenTimer()
	{
		yield return new WaitForSeconds(7);
		eindunkeln = false;
		done = true;
	}

	//begin des Eindunkelns, wird von verschiedenen Skripts benutzt um das Eindunkeln zu starten
	public void darken()
	{
		if (!eindunkeln)
		{
			StartCoroutine(darkenTimer());
			eindunkeln = true;
			RenderSettings.fogEndDistance = 30.5f;
		}
	}

	//gibt zurück ob das Eindunkeln fertig ist, wird benutzt um eine neue Szene zu laden
	public static bool returnDone()
	{
		return done;
	}
}
