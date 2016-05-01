using UnityEngine;
using System.Collections;

public class Moving : MonoBehaviour {

	public bool isAlive = true;
	public float speed;
	public Rigidbody2D rbody;
	public void moveBack(){
		if (isAlive) {
			speed *= -1;
			bool check = GetComponent<SpriteRenderer> ().flipX;
			if (check) {
				GetComponent<SpriteRenderer> ().flipX = false;
			} else {
				GetComponent<SpriteRenderer> ().flipX = true;
			}
		}
	}
	public void MovingFunc(){
		if(isAlive)
			transform.Translate (Vector2.right * speed * Time.deltaTime);
	}
	public void Jump(){
		rbody = GetComponent<Rigidbody2D> ();
		Debug.Log (rbody.velocity);
		if (rbody.velocity.y < 0.1f) {
			rbody.AddForce (new Vector2 (speed * 12, rbody.velocity.y*-8.5f), ForceMode2D.Impulse);
		}
	}
}
