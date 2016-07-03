﻿using UnityEngine;
using System.Collections;

public class Drill : MonoBehaviour {
	SpriteRenderer drillSr;
	SpriteRenderer articleSr;

	public GameObject emptyBlock;
	public Sprite[] drillSp;
	public Sprite[] articleSp;
	public bool isAct = false;

	IEnumerator drillAction(){
		GameObject tmp = articleSr.gameObject;
		transform.position = new Vector2 (tmp.transform.position.x, tmp.transform.position.y+1.3f);
		int j;
		for (int i = 0; i < 8; i++) {
			drillSr.sprite = drillSp [i];
			transform.Translate (Vector2.up *-2.3f* Time.deltaTime);
			if (i > 5)
				j = 5;
			else
				j = i;
			articleSr.sprite = articleSp [j];
			yield return new WaitForSeconds (0.1f);
		}
		Destroy (articleSr.gameObject);
		Destroy (this.gameObject);
		isAct = false;
	}

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.tag == "Article" && coll.name =="Land") {
			isAct = true;
			articleSr = coll.GetComponent<SpriteRenderer> ();
			Instantiate (emptyBlock, new Vector2(coll.transform.position.x,coll.transform.position.y + 1),transform.rotation);
			StartCoroutine (drillAction ());
			GetComponent<CircleCollider2D> ().enabled = false;

		}
	}

	IEnumerator checkColl(){
		yield return new WaitForSeconds (0.1f);
		if (!isAct && GetComponent<CircleCollider2D>().isActiveAndEnabled) {
			Destroy (this.gameObject);
            GameObject.Find("Main Camera").SendMessage("canceledItem");
		}
	}
	// Use this for initialization
	void Start () {
		drillSr = GetComponent<SpriteRenderer> ();

	}
	
	// Update is called once per frame
	void Update () {
		if (GetComponent<CircleCollider2D> ().isActiveAndEnabled) {
			StartCoroutine (checkColl ());
		}
	}
}
