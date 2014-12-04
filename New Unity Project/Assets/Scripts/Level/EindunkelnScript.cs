using UnityEngine;
using System.Collections;

public class EindunkelnScript : MonoBehaviour {
	private float speed;
	private bool eindunkeln;
	private static bool done;
	
	void Start()
	{
		speed = 5;
		eindunkeln = false;
		done = false;
	}
	
	void Update()
	{
		if (eindunkeln)
		{
			RenderSettings.fogStartDistance = RenderSettings.fogStartDistance - Time.deltaTime*speed*5;
			RenderSettings.fogEndDistance = RenderSettings.fogEndDistance - Time.deltaTime*speed;
		}
	}

	IEnumerator darkenTimer()
	{
		yield return new WaitForSeconds(5);
		eindunkeln = false;
		done = true;
	}

	public void darken()
	{
		if (!eindunkeln)
		{
			StartCoroutine(darkenTimer());
			eindunkeln = true;
		}
	}

	public static bool returnDone()
	{
		return done;
	}
}
