using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour {
	public static bool tutoCheck;
	void Start(){
		StartCoroutine (checkDelay ());
	}
	IEnumerator checkDelay(){
		yield return new WaitForSeconds (0.1f);
		if (!tutoCheck) {
			Destroy (this.gameObject);
			GameObject.Find("Main Camera").SendMessage("canceledItem");
		} else {
			Tutorial.isCushionCo = false;
		}
	}
	public void moveBack(Collider2D coll){
		if (coll.GetComponent<Moving> ().isAlive) {
			coll.GetComponent<Moving> ().speed *= -1;
			bool check = coll.GetComponent<SpriteRenderer> ().flipX;
			if (check) {
				coll.GetComponent<SpriteRenderer> ().flipX = false;
			} else {
				coll.GetComponent<SpriteRenderer> ().flipX = true;
			}
		}
	}
	void OnCollisionEnter2D(Collision2D coll){
		if (Handler.isTuto && coll.gameObject.name == "WallCheck") {
			tutoCheck = true;
		} else {
			moveBack (coll.collider);
		}
	}
}
