﻿using UnityEngine;
using System.Collections;

public class AnimationController : MonoBehaviour {

	//private AnimationState idle;
	//private AnimationState walk;

	void Start () {
		//idle = animation["idle1"];
		//walk = animation["walk3"];

		animation.wrapMode = WrapMode.Loop;

		//setup für jump, wrapMode nur Once und layer 1 damit es walk3 und idle1 nicht unterbricht
		animation["jumpStart"].wrapMode = WrapMode.Once;
		animation["jumpStart"].layer = 1;
		animation["jumpEnd"].wrapMode = WrapMode.Once;
		animation["jumpEnd"].layer = 1;
	}
	
	// Update is called once per frame
	void Update () {
		animation.CrossFade("idle1");

		if (PlayerControllerFauxGravity.walking)
		{
			animation.Play("walk3");
		}
		if (PlayerControllerFauxGravity.jumping)
		{
			PlayerControllerFauxGravity.jumping = false;
			animation.Play ("jumpStart");
		}
	}
}
