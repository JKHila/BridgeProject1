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
		/*float height = rbody.velocity.y * -10f;
		Debug.Log (height);
		if (height > 300.0f)*/
		float height = 300.0f;
		rbody.velocity = transform.up*15 + transform.right*2*speed;
		//rbody.AddForce (new Vector2 (speed * 30f, height), ForceMode2D.Impulse);
	}

	public void boardJump(){
		rbody = GetComponent<Rigidbody2D> ();
		rbody.velocity.Set (0, 0);
		//Debug.Log (rbody.gameObject.GetComponent<Slime> ().getJump ());
		if (!rbody.gameObject.GetComponent<Slime> ().getJump()) {
			
			rbody.AddForce (new Vector2 (speed * 25f, 180), ForceMode2D.Impulse);
		}
	}
}
