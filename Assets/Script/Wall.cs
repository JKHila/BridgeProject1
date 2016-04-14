using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour {
	public void moveBack(Collider2D coll){
		coll.GetComponent<Moving> ().speed *= -1;
		/*if (coll.transform.localRotation.y < 1) {
			coll.transform.localRotation = new Quaternion (0, 180, 0, 0);
		} else {
			coll.transform.localRotation = new Quaternion (0, 0, 0, 0);
		}*/

		bool check = coll.GetComponent<SpriteRenderer> ().flipX;
		if (check) {
			coll.GetComponent<SpriteRenderer> ().flipX = false;
		} else {
			coll.GetComponent<SpriteRenderer> ().flipX = true;
		}
	}
	void OnTriggerEnter2D(Collider2D coll){
		moveBack (coll);
	}
}
