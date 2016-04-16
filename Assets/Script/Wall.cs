using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour {
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
		moveBack (coll.collider);
	}
}
