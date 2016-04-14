using UnityEngine;
using System.Collections;

public class Moving : MonoBehaviour {
	public float speed;
	public Rigidbody2D rbody;
	public void MovingFunc(){
		transform.Translate (Vector2.right * speed * Time.deltaTime);
	}
	public void Jump(){
		rbody = GetComponent<Rigidbody2D> ();
		rbody.AddForce(new Vector2(10,50), ForceMode2D.Impulse);
	}
}
