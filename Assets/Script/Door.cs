﻿using UnityEngine;
using System.Collections;

public class Door : Wall {
	public Handler handler;
	public Sprite[] doorSp = new Sprite[7];
	// Use this for initialization
	void Start () {
		StartCoroutine (openDoor ());
	}
	IEnumerator openDoor(){
		SpriteRenderer sr = GetComponent<SpriteRenderer> ();
		yield return new WaitForSeconds (1.0f);
		for (int i = 0; i < 7; i++) {
			sr.sprite = doorSp [i];
			yield return new WaitForSeconds (0.08f);
		}
	}
	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.name == "Slime(Clone)") {
			handler.addScore ();
			Destroy (coll.gameObject);
		} else {
			base.moveBack(coll.collider);
		}
	}
	// Update is called once per frame
	void Update () {
	
	}
}
