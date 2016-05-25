using UnityEngine;
using System.Collections;

public class Moving : MonoBehaviour {

	public bool isAlive = true;
	public float speed;
	public Rigidbody2D rbody;
	void Start()
	{
		
	}
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
		if (isAlive)
			transform.Translate (Vector2.right * speed * Time.deltaTime);
			//rbody = GetComponent<Rigidbody2D> ();
		//rbody.AddForce (Vector2.right * speed*100, ForceMode2D.Force);
	}
	public void Jump(){
		rbody = GetComponent<Rigidbody2D> ();
		float height = rbody.velocity.y * -8.5f;
		if (height > 130.0f)
			height = 130.0f;
		rbody.velocity.Set (0, 0);
		rbody.AddForce (new Vector2 (speed * 12, height), ForceMode2D.Impulse);
	}

	public void boardJump(){
		rbody = GetComponent<Rigidbody2D> ();
		rbody.velocity.Set (0, 0);
		rbody.AddForce (new Vector2 (speed * 18, 40), ForceMode2D.Impulse);
	}
}
