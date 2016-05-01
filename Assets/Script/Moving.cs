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
		rbody.AddForce(new Vector2(speed*7,50), ForceMode2D.Impulse);
	}
}
