using UnityEngine;
using System.Collections;

public class Slime : Moving {
	private float curY; 

	SpriteRenderer sr;
	public Sprite[] sp = new Sprite[3];
	public Sprite[] die = new Sprite[6];
	public GameObject checkArea;

	// Use this for initialization
	void Start () {
		sr = transform.GetComponent<SpriteRenderer> ();
		curY = transform.position.y;
		StartCoroutine ("moveAction");
	}
	IEnumerator moveAction(){
		while (true) {
			for (int i = 0; i < 3; i++) {
				sr.sprite = sp [i];
				yield return new WaitForSeconds (0.1f);
			}
			sr.sprite = sp [1];
			yield return new WaitForSeconds (0.1f);
		}
	}
	IEnumerator dieAction(){
		base.isAlive = false;
		StopCoroutine ("moveAction");
		for (int i = 0; i < 6; i++) {
			sr.sprite = die [i];
			yield return new WaitForSeconds (0.1f);
		}
		this.gameObject.SetActive (false);
	}
	// Update is called once per frame
	void Update () {
		MovingFunc ();
	}
	void OnCollisionEnter2D (Collision2D coll){
		if (coll.gameObject.tag != "cushion") {
			if (transform.position.y < curY && curY - transform.position.y > 3.2f) {
				base.speed = 0;
				StartCoroutine (dieAction());
			}
			curY = transform.position.y;
		} else {
			curY = transform.position.y;
		}
	}
}
