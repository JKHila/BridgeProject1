using UnityEngine;
using System.Collections;

public class Warrior : Moving {

	SpriteRenderer sr;
	public Sprite[] sp = new Sprite[3];
	public GameObject hitArea;
	GameObject tmpObj;
	void OnTriggerEnter2D(Collider2D coll){
		if (coll.tag == "Slime" && tmpObj != coll.gameObject) {
			coll.GetComponent<Rigidbody2D> ().AddForce (Vector2.right * 100 * GetComponent<Moving> ().speed, ForceMode2D.Impulse);
			coll.GetComponent<Slime> ().StartCoroutine ("dieAction");
			tmpObj = coll.gameObject;
		} else if(coll.tag == "Article"){
			base.moveBack ();
		}
	}
	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "Slime" && tmpObj != coll.gameObject) {
			base.moveBack ();
			coll.gameObject.GetComponent<Rigidbody2D> ().AddForce (Vector2.right * 100 * GetComponent<Moving> ().speed, ForceMode2D.Impulse);
			coll.gameObject.GetComponent<Slime> ().StartCoroutine ("dieAction");
			tmpObj = coll.gameObject;
		}
	}
	// Use this for initialization
	void Start () {
		sr = transform.GetComponent<SpriteRenderer> ();
		StartCoroutine (moveAction ());
	}
	IEnumerator moveAction(){
		while (true) {
			for (int i = 0; i < 8; i++) {
				sr.sprite = sp [i];
				yield return new WaitForSeconds (0.1f);
			}
			//sr.sprite = sp [1];
			//yield return new WaitForSeconds (0.1f);
		}
	}
	// Update is called once per frame
	void Update () {
		MovingFunc ();
		if (GetComponent<Moving>().speed > 0) {
			hitArea.GetComponent<CircleCollider2D> ().offset = new Vector2 (0.39f, -0.45f);
		} else {
			hitArea.GetComponent<CircleCollider2D> ().offset = new Vector2 (-0.38f, -0.45f);
		}
	}

}
